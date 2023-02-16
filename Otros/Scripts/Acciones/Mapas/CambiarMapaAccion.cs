﻿using Bot_Dofus_Retro.Otros.Game.Entidades.Manejadores.Movimientos;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Utilidades.Criptografia;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Otros.Scripts.Acciones
{
    public class CambiarMapaAccion : AccionesScript
    {
        public MapaTeleportCeldas direccion { get; private set; }
        public short celda_id { get; private set; }

        public bool celda_especifica => direccion == MapaTeleportCeldas.NINGUNO && celda_id != -1;
        public bool direccion_especifica => direccion != MapaTeleportCeldas.NINGUNO && celda_id == -1;

        public CambiarMapaAccion(MapaTeleportCeldas _direccion, short _celda_id)
        {
            direccion = _direccion;
            celda_id = _celda_id;
        }

        internal override Task<ResultadosAcciones> proceso(Cuenta cuenta)
        {
            if (celda_especifica)
            {
                Celda celda = cuenta.juego.mapa.get_Celda_Id(celda_id);
                bool puede_cambiar_mapa = cuenta.juego.manejador.movimientos.get_Cambiar_Mapa(direccion, celda);

                if (!puede_cambiar_mapa)
                    return resultado_fallado;
            }
            else if (direccion_especifica)
            {
                bool puede_cambiar_mapa = cuenta.juego.manejador.movimientos.get_Cambiar_Mapa(direccion);

                if (!puede_cambiar_mapa)
                    return resultado_fallado;
            }

            return resultado_procesado;
        }

        public static bool TryParse(string texto, out CambiarMapaAccion accion)
        {
            string[] partes = texto.Split('|');
            string total_partes = partes[Hash.get_Nuevo_Random(0, partes.Length)];

            Match match = Regex.Match(total_partes, @"(?<direccion>arriba|derecha|abajo|izquierda)\((?<celda>\d{1,3})\)");
            if (match.Success)
            {
                accion = new CambiarMapaAccion((MapaTeleportCeldas)Enum.Parse(typeof(MapaTeleportCeldas), match.Groups["direccion"].Value, true), short.Parse(match.Groups["celda"].Value));
                return true;
            }
            else
            {
                match = Regex.Match(total_partes, @"(?<direccion>arriba|derecha|abajo|izquierda)");
                if (match.Success)
                {
                    accion = new CambiarMapaAccion((MapaTeleportCeldas)Enum.Parse(typeof(MapaTeleportCeldas), match.Groups["direccion"].Value, true), -1);
                    return true;
                }
                else
                {
                    match = Regex.Match(total_partes, @"(?<celda>\d{1,3})");
                    if (match.Success)
                    {
                        accion = new CambiarMapaAccion(MapaTeleportCeldas.NINGUNO, short.Parse(match.Groups["celda"].Value));
                        return true;
                    }
                }
            }
            accion = null;
            return false;
        }
    }
}
