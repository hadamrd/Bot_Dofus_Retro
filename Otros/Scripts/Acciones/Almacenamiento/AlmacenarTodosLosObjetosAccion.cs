﻿using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones.Almacenamiento
{
    class AlmacenarTodosLosObjetosAccion : AccionesScript
    {
        internal override async Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            InventarioGeneral inventario = cuenta.juego.personaje.inventario;

            foreach (ObjetosInventario objeto in inventario.objetos)
            {
                if (!objeto.objeto_esta_equipado())
                {
                    await cuenta.conexion.enviar_Paquete_Async($"EMO+{objeto.id_inventario}|{objeto.cantidad}");
                    inventario.eliminar_Objeto(objeto, 0, false);
                    await Task.Delay(300);
                }
            }
            return ResultadosAcciones.HECHO;
        }
    }
}
