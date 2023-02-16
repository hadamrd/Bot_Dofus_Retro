﻿using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using System;
using System.Drawing;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Personaje : DarkDocument
    {
        private Cuenta cuenta;

        public UI_Personaje(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            Icon = icono;
            DockText = nombre;
            cuenta.juego.personaje.caracteristicas_actualizadas += personaje_Caracteristicas_Actualizadas;
        }

        private void personaje_Caracteristicas_Actualizadas()
        {
            BeginInvoke((Action)(() =>
            {
                //Sumario
                label_puntos_vida.Text = cuenta.juego.personaje.caracteristicas.vitalidad_actual.ToString() + '/' + cuenta.juego.personaje.caracteristicas.vitalidad_maxima.ToString();
                label_puntos_accion.Text = cuenta.juego.personaje.caracteristicas.puntos_accion.total_stats.ToString();
                label_puntos_movimiento.Text = cuenta.juego.personaje.caracteristicas.puntos_movimiento.total_stats.ToString();
                label_iniciativa.Text = cuenta.juego.personaje.caracteristicas.iniciativa.total_stats.ToString();
                label_prospeccion.Text = cuenta.juego.personaje.caracteristicas.prospeccion.total_stats.ToString();
                label_alcanze.Text = cuenta.juego.personaje.caracteristicas.alcanze.total_stats.ToString();
                label_invocaciones.Text = cuenta.juego.personaje.caracteristicas.criaturas_invocables.total_stats.ToString();

                //Caracteristicas
                stats_vitalidad.Text = cuenta.juego.personaje.caracteristicas.vitalidad.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.vitalidad.equipamiento.ToString() + ")";
                stats_sabiduria.Text = cuenta.juego.personaje.caracteristicas.sabiduria.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.sabiduria.equipamiento.ToString() + ")";
                stats_fuerza.Text = cuenta.juego.personaje.caracteristicas.fuerza.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.fuerza.equipamiento.ToString() + ")";
                stats_inteligencia.Text = cuenta.juego.personaje.caracteristicas.inteligencia.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.inteligencia.equipamiento.ToString() + ")";
                stats_suerte.Text = cuenta.juego.personaje.caracteristicas.suerte.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.suerte.equipamiento.ToString() + ")";
                stats_agilidad.Text = cuenta.juego.personaje.caracteristicas.agilidad.base_personaje.ToString() + " (" + cuenta.juego.personaje.caracteristicas.agilidad.equipamiento.ToString() + ")";

                //Otros
                label_capital_stats.Text = cuenta.juego.personaje.puntos_caracteristicas.ToString();
                label_nivel_personaje.Text = $"Nivel {cuenta.juego.personaje.nivel}";

                if (imagen_personaje.Image == null)
                {
                    Bitmap imagen_raza = Properties.Resources.ResourceManager.GetObject("_" + cuenta.juego.personaje.raza_id + cuenta.juego.personaje.sexo) as Bitmap;
                    imagen_personaje.Image = imagen_raza;

                    label_nombre_personaje.Text = cuenta.juego.personaje.nombre;
                }
            }));
        }
    }
}
