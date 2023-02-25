﻿using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario.Enums;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Inventario
{
    public class InventarioGeneral : IDisposable, IEliminable
    {
        private Cuenta cuenta;
        private ConcurrentDictionary<uint, ObjetosInventario> _objetos;
        private bool disposed;

        //Propiedades
        public int kamas { get; private set; }
        public short pods_actuales { get; set; }
        public short pods_maximos { get; set; }

        public IEnumerable<ObjetosInventario> objetos => _objetos.Values;
        public IEnumerable<ObjetosInventario> equipamiento => objetos.Where(o => o.tipo_inventario == TipoObjetosInventario.EQUIPAMIENTO);
        public IEnumerable<ObjetosInventario> varios => objetos.Where(o => o.tipo_inventario == TipoObjetosInventario.VARIOS);
        public IEnumerable<ObjetosInventario> recursos => objetos.Where(o => o.tipo_inventario == TipoObjetosInventario.RECURSOS);
        public IEnumerable<ObjetosInventario> mision => objetos.Where(o => o.tipo_inventario == TipoObjetosInventario.OBJETOS_MISION);
        public int porcentaje_pods => (int)((double)pods_actuales / pods_maximos * 100);

        public event Action inventario_actualizado;
        public event Action almacenamiento_abierto;
        public event Action almacenamiento_cerrado;

        // Constructor
        internal InventarioGeneral(Cuenta _cuenta)
        {
            cuenta = _cuenta;
            _objetos = new ConcurrentDictionary<uint, ObjetosInventario>();
        }

        public ObjetosInventario get_Objeto_Modelo_Id(int gid) => objetos.FirstOrDefault(f => f.id_modelo == gid);
        public ObjetosInventario get_Objeto_en_Posicion(InventarioPosiciones posicion) => objetos.FirstOrDefault(o => o.posicion == posicion);

        public void agregar_Objetos(string paquete)
        {
            foreach (string obj in paquete.Split(';'))
            {
                if (!string.IsNullOrEmpty(obj))
                {
                    string[] separador = obj.Split('~');
                    uint id_inventario = Convert.ToUInt32(separador[0], 16);
                    ObjetosInventario objeto = new ObjetosInventario(obj);
                    _objetos.TryAdd(id_inventario, objeto);
                }
            }

            inventario_actualizado?.Invoke();
        }

        public void modificar_Objetos(string paquete)
        {
            if (!string.IsNullOrEmpty(paquete))
            {
                string[] separador = paquete.Split('|');
                ObjetosInventario objeto = objetos.FirstOrDefault(f => f.id_inventario == uint.Parse(separador[0]));

                if (objeto != null)
                {
                    int cantidad = int.Parse(separador[1]);
                    ObjetosInventario nuevo_objeto = objeto;
                    nuevo_objeto.cantidad = cantidad;

                    if (_objetos.TryUpdate(objeto.id_inventario, nuevo_objeto, objeto))
                        inventario_actualizado?.Invoke();
                }
            }
        }

        public void eliminar_Objeto(ObjetosInventario obj, int cantidad, bool paquete_eliminar) => Task.Run(async () =>
        {
            if (obj == null)
                return;

            cantidad = cantidad == 0 ? obj.cantidad : cantidad > obj.cantidad ? obj.cantidad : cantidad;

            if (obj.cantidad > cantidad)
            {
                ObjetosInventario nuevo_objeto = obj;
                nuevo_objeto.cantidad -= cantidad;
                _objetos.TryUpdate(obj.id_inventario, nuevo_objeto, obj);
            }
            else
                _objetos.TryRemove(obj.id_inventario, out ObjetosInventario objeto);

            if (paquete_eliminar)
            {
                await cuenta.conexion.enviar($"Od{obj.id_inventario}|{cantidad}");
                cuenta.logger.log_informacion("Inventario", $"{cantidad} {obj.nombre} eliminados(s).");
            }

            inventario_actualizado?.Invoke();
        });

        public void eliminar_Objeto(uint id_inventario, int cantidad, bool paquete_eliminar)
        {
            if (!_objetos.TryGetValue(id_inventario, out ObjetosInventario obj))
                return;

            eliminar_Objeto(obj, cantidad, paquete_eliminar);
        }

        public bool equipar_Objeto(ObjetosInventario objeto)
        {
            if (cuenta == null)
                return false;

            PersonajeJuego personaje = cuenta.juego.personaje;

            if (objeto == null || objeto.cantidad == 0 || cuenta.esta_ocupado || personaje == null)
            {
                cuenta.logger.log_Error("INVENTARIO", $"El objeto {objeto.nombre} no se puede equipar");
                return false;
            }

            if (objeto.nivel > personaje.nivel)
            {
                cuenta.logger.log_Error("INVENTARIO", $"El nivel del objeto {objeto.nombre} es superior al nivel actual");
                return false;
            }

            if (objeto.posicion != InventarioPosiciones.NO_EQUIPADO)//objeto ya esta equipado
            {
                cuenta.logger.log_Error("INVENTARIO", $"El objeto {objeto.nombre} ya esta equipado");
                return false;
            }

            List<InventarioPosiciones> possibles_posiciones = InventarioUtiles.get_Posibles_Posiciones(objeto.tipo);

            if (possibles_posiciones == null || possibles_posiciones.Count == 0)//objeto no equipable
            {
                cuenta.logger.log_Error("INVENTARIO", $"El objeto {objeto.nombre} no es equipable.");
                return false;
            }

            foreach (InventarioPosiciones posicion in possibles_posiciones)
            {
                if (get_Objeto_en_Posicion(posicion) == null)
                {
                    cuenta.conexion.enviar("OM" + objeto.id_inventario + "|" + (sbyte)posicion).Wait();
                    cuenta.logger.log_informacion("INVENTARIO", $"{objeto.nombre} equipado.");
                    objeto.posicion = posicion;
                    inventario_actualizado?.Invoke();
                    return true;
                }
            }

            //desequipa X objeto si ya esta equipado
            if (_objetos.TryGetValue(get_Objeto_en_Posicion(possibles_posiciones[0]).id_inventario, out ObjetosInventario objeto_equipado))
            {
                objeto_equipado.posicion = InventarioPosiciones.NO_EQUIPADO;
                cuenta.conexion.enviar("OM" + objeto_equipado.id_inventario + "|" + (sbyte)InventarioPosiciones.NO_EQUIPADO).Wait();
            }

            cuenta.conexion.enviar("OM" + objeto.id_inventario + "|" + (sbyte)possibles_posiciones[0]).Wait();

            if (objeto.cantidad == 1)
                objeto.posicion = possibles_posiciones[0];

            cuenta.logger.log_informacion("INVENTARIO", $"{objeto.nombre} equipado.");
            inventario_actualizado?.Invoke();
            return true;
        }

        public Task<bool> desequipar_Objeto(ObjetosInventario objeto) => Task.Run(async () =>
        {
            if (cuenta == null)
                return false;

            PersonajeJuego personaje = cuenta.juego.personaje;

            if (objeto == null || personaje == null)
                return false;

            if (objeto.posicion == InventarioPosiciones.NO_EQUIPADO)
                return false;

            await cuenta.conexion.enviar("OM" + objeto.id_inventario + "|" + (sbyte)InventarioPosiciones.NO_EQUIPADO);
            objeto.posicion = InventarioPosiciones.NO_EQUIPADO;
            cuenta.logger.log_informacion("INVENTARIO", $"{objeto.nombre} desequipado.");

            inventario_actualizado?.Invoke();
            return true;
        });

        public void utilizar_Objeto(ObjetosInventario objeto) => Task.Run(async () =>
        {
            if (objeto == null)
                return;

            if (objeto.cantidad == 0)
            {
                cuenta.logger.log_Error("INVENTARIO", $"El objeto {objeto.nombre} no se puede utilizar, cantidad insuficiente");
                return;
            }

            await cuenta.conexion.enviar("OU" + objeto.id_inventario + "|");
            eliminar_Objeto(objeto, 1, false);
            cuenta.logger.log_informacion("INVENTARIO", $"{objeto.nombre} utilizado.");
        });

        public void evento_Almacenamiento_Abierto() => almacenamiento_abierto?.Invoke();
        public void evento_Almacenamiento_Cerrado() => almacenamiento_cerrado?.Invoke();

        #region Zona Dispose
        public void Dispose() => Dispose(true);
        ~InventarioGeneral() => Dispose(false);

        public void limpiar()
        {
            kamas = 0;
            pods_actuales = 0;
            pods_maximos = 0;
            _objetos.Clear();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                _objetos.Clear();
                _objetos = null;
                cuenta = null;
                disposed = true;
            }
        }
        #endregion
    }
}
