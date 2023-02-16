﻿using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Enums;
using Bot_Dofus_Retro.Otros.Mapas;
using Bot_Dofus_Retro.Otros.Mapas.Entidades;
using Bot_Dofus_Retro.Tema.Controles.ControlMapa.Animaciones;
using Bot_Dofus_Retro.Tema.Controles.ControlMapa.Celdas;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Tema.Controles.ControlMapa
{
    [Serializable]
    public partial class ControlMapa : UserControl
    {
        public byte mapa_altura { get; set; }
        public byte mapa_anchura { get; set; }
        private CalidadMapa tipo_calidad;
        private bool mapa_raton_abajo;
        private CeldaMapa celda_retenida;
        private CeldaMapa celda_abajo;
        private Cuenta cuenta;
        private ConcurrentDictionary<int, MovimientoAnimacion> animaciones;
        private System.Timers.Timer animaciones_timer;
        private bool mostrar_animaciones;
        private bool mostrar_celdas;

        public delegate void CellClickedHandler(CeldaMapa celda, MouseButtons botones, bool abajo);
        public event CellClickedHandler clic_celda;
        public event Action<CeldaMapa, CeldaMapa> clic_celda_terminado;

        public ControlMapa()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            tipo_calidad = CalidadMapa.BAJA;
            mapa_altura = 17;
            mapa_anchura = 15;
            TraceOnOver = false;
            ColorCeldaInactiva = Color.DarkGray;
            ColorCeldaActiva = Color.Gray;

            mostrar_animaciones = true;
            animaciones = new ConcurrentDictionary<int, MovimientoAnimacion>();
            animaciones_timer = new System.Timers.Timer(80);
            animaciones_timer.Elapsed += animacion_Finalizada;

            set_Celda_Numero();
            dibujar_Cuadricula();
            InitializeComponent();
        }

        protected void OnCellClicked(CeldaMapa cell, MouseButtons buttons, bool abajo) => clic_celda?.Invoke(cell, buttons, abajo);
        protected void OnCellOver(CeldaMapa cell, CeldaMapa last) => clic_celda_terminado?.Invoke(cell, last);

        public bool Mostrar_Animaciones
        {
            get => mostrar_animaciones;
            set
            {
                mostrar_animaciones = value;
                if (mostrar_animaciones)
                    animaciones_timer.Start();
            }
        }

        public bool Mostrar_Celdas_Id
        {
            get => mostrar_celdas;
            set
            {
                mostrar_celdas = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public int RealCellHeight { get; private set; }
        [Browsable(false)]
        public int RealCellWidth { get; private set; }
        public Color ColorCeldaInactiva { get; set; }
        public Color ColorCeldaActiva { get; set; }
        public bool TraceOnOver { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public CeldaMapa CurrentCellOver { get; set; }
        public Color BorderColorOnOver { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public CeldaMapa[] celdas { get; set; }

        public CalidadMapa TipoCalidad
        {
            get => tipo_calidad;
            set
            {
                tipo_calidad = value;
                Invalidate();
            }
        }

        public void set_Cuenta(Cuenta _cuenta) => cuenta = _cuenta;

        private void aplicar_Calidad_Mapa(Graphics g)
        {
            switch (tipo_calidad)
            {
                case CalidadMapa.BAJA:
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.InterpolationMode = InterpolationMode.Low;
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                break;

                case CalidadMapa.MEDIA:
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.GammaCorrected;
                    g.InterpolationMode = InterpolationMode.High;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                break;


                case CalidadMapa.ALTA:
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                break;
            }
        }

        public void set_Celda_Numero()
        {
            celdas = new CeldaMapa[2 * mapa_altura * mapa_anchura];

            short cellId = 0;
            CeldaMapa celda;
            for (int y = 0; y < mapa_altura; y++)
            {
                for (int x = 0; x < mapa_anchura * 2; x++)
                {
                    celda = new CeldaMapa(cellId++);
                    celdas[celda.id] = celda;
                }
            }
        }

        private double get_Maximo_Escalado()
        {
            double celda_anchura = Width / (double)(mapa_anchura + 1);
            double cellHeight = Height / (double)(mapa_altura + 1);
            celda_anchura = Math.Min(cellHeight * 2, celda_anchura);

            return celda_anchura;
        }

        public void dibujar_Cuadricula()
        {
            int cellId = 0;
            double cellWidth = get_Maximo_Escalado();
            double cellHeight = Math.Ceiling(cellWidth / 2);

            int offsetX = Convert.ToInt32((Width - ((mapa_anchura + 0.5) * cellWidth)) / 2);
            var offsetY = Convert.ToInt32((Height - ((mapa_altura + 0.5) * cellHeight)) / 2);

            double midCellHeight = cellHeight / 2;
            double midCellWidth = cellWidth / 2;

            for (int y = 0; y <= (2 * mapa_altura) - 1; ++y)
            {
                if ((y % 2) == 0)
                {
                    for (int x = 0; x <= mapa_anchura - 1; x++)//dibuja los impares
                    {
                        Point left = new Point(Convert.ToInt32(offsetX + (x * cellWidth)), Convert.ToInt32(offsetY + (y * midCellHeight) + midCellHeight));
                        Point top = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + midCellWidth), Convert.ToInt32(offsetY + (y * midCellHeight)));
                        Point right = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + cellWidth), Convert.ToInt32(offsetY + (y * midCellHeight) + midCellHeight));
                        Point down = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + midCellWidth), Convert.ToInt32(offsetY + (y * midCellHeight) + cellHeight));
                        celdas[cellId++].Puntos = new[] { left, top, right, down };
                    }
                }
                else
                {
                    for (int x = 0; x <= mapa_anchura - 2; x++)//dibuja los pares
                    {
                        Point left = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + midCellWidth), Convert.ToInt32(offsetY + (y * midCellHeight) + midCellHeight));
                        Point top = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + cellWidth), Convert.ToInt32(offsetY + (y * midCellHeight)));
                        Point right = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + cellWidth + midCellWidth), Convert.ToInt32(offsetY + (y * midCellHeight) + midCellHeight));
                        Point down = new Point(Convert.ToInt32(offsetX + (x * cellWidth) + cellWidth), Convert.ToInt32(offsetY + (y * midCellHeight) + cellHeight));
                        celdas[cellId++].Puntos = new[] { left, top, right, down };
                    }
                }
            }
            RealCellHeight = (int)cellHeight;
            RealCellWidth = (int)cellWidth;
            Invalidate();
        }

        public void dibujar_Celdas(Graphics g)
        {
            aplicar_Calidad_Mapa(g);
            g.Clear(BackColor);

            foreach (CeldaMapa celda in celdas)
            {
                if (celda.esta_En_Rectangulo(g.ClipBounds))
                {
                    switch (celda.estado)
                    {
                        case CeldaEstado.CAMINABLE:
                            celda.dibujar_Color(g, Color.Gray, Color.White);

                            if (mostrar_celdas)
                                celda.dibujar_Celda_Id(this, g);
                            break;

                        case CeldaEstado.OBSTACULO:
                            if (mostrar_celdas)
                                celda.dibujar_Celda_Id(this, g);
                            else
                                celda.dibujar_Obstaculo(g, Color.Gray, Color.FromArgb(60, 60, 60));
                            break;

                        case CeldaEstado.CELDA_TELEPORT:
                            celda.dibujar_Color(g, Color.Gray, Color.Orange);
                            celda.dibujar_Celda_Id(this, g);
                            break;

                        case CeldaEstado.OBJETO_INTERACTIVO:
                            celda.dibujar_Color(g, Color.LightGoldenrodYellow, Color.LightGoldenrodYellow);
                            celda.dibujar_Celda_Id(this, g);
                            break;

                        default:
                            celda.dibujar_Color(g, Color.Gray, Color.DarkGray);
                            break;
                    }

                    dibujar_Contenido_Celda(g, celda);
                }
            }

            dibujar_Animaciones(g);

            if (cuenta?.Estado_Cuenta == EstadoCuenta.LUCHANDO)
            {
                using (Pen p = new Pen(Color.FromArgb(200, 143, 9, 9), 8))
                {
                    g.DrawRectangle(p, 4, 4, Width - 8, Height - 8);
                }
            }
        }

        private void dibujar_Contenido_Celda(Graphics g, CeldaMapa celda)
        {
            if (cuenta == null)
                return;

            Mapa mapa_juego = cuenta.juego.mapa;

            if (mapa_juego == null || !mapa_juego.mapa_cargado)
                return;

            if (cuenta.esta_Luchando())
            {
                if (celda.id == cuenta.juego.pelea.jugador_luchador?.celda.id && !animaciones.ContainsKey(cuenta.juego.pelea.jugador_luchador.id))
                    celda.dibujar_FillPie(g, Color.Blue, RealCellHeight / 2);
                else if (cuenta.juego.pelea.get_Enemigos.FirstOrDefault(luchador => luchador.esta_vivo && luchador.celda.id == celda.id && !animaciones.ContainsKey(luchador.id)) != null)
                    celda.dibujar_FillPie(g, Color.DarkRed, RealCellHeight / 2);
                else if (cuenta.juego.pelea.get_Aliados.FirstOrDefault(luchador => luchador.esta_vivo && luchador.celda.id == celda.id && !animaciones.ContainsKey(luchador.id)) != null)
                    celda.dibujar_FillPie(g, Color.FromArgb(81, 113, 202), RealCellHeight / 2);
            }
            else
            {
                if (celda.id == cuenta.juego.personaje.celda.id && !animaciones.ContainsKey(cuenta.juego.personaje.id))
                    celda.dibujar_FillPie(g, Color.Blue, RealCellHeight / 2);
                else if (mapa_juego.entidades.Values.Where(m => m is Monstruos).FirstOrDefault(m => m.celda.id == celda.id && !animaciones.ContainsKey(m.id)) != null)
                    celda.dibujar_FillPie(g, Color.DarkRed, RealCellHeight / 2);
                else if (mapa_juego.entidades.Values.Where(n => n is Npc).FirstOrDefault(n => n.celda.id == celda.id && !animaciones.ContainsKey(n.id)) != null)
                    celda.dibujar_FillPie(g, Color.FromArgb(179, 120, 211), RealCellHeight / 2);
                else if (mapa_juego.entidades.Values.Where(p => p is Personajes).FirstOrDefault(p => p.celda.id == celda.id && !animaciones.ContainsKey(p.id)) != null)
                    celda.dibujar_FillPie(g, Color.FromArgb(81, 113, 202), RealCellHeight / 2);
                else if (mapa_juego.entidades.Values.Where(p => p is Mercantes).FirstOrDefault(p => p.celda.id == celda.id && !animaciones.ContainsKey(p.id)) != null)
                    celda.dibujar_FillPie(g, Color.FromArgb(255, 20, 147), RealCellHeight / 2);
            }
        }

        #region Animaciones
        public void agregar_Animacion(int id, List<Celda> path, int duracion, TipoAnimaciones actor)
        {
            if (path.Count < 2 || !mostrar_animaciones)
                return;

            if (animaciones.ContainsKey(id))
                animacion_Finalizada(animaciones[id]);

            MovimientoAnimacion nueva_animacion = new MovimientoAnimacion(id, path.Select(f => celdas[f.id]), duracion, actor);
            nueva_animacion.finalizado += animacion_Finalizada;
            animaciones.TryAdd(id, nueva_animacion);
            nueva_animacion.iniciar();
        }

        private void animacion_Finalizada(MovimientoAnimacion animacion)
        {
            animacion.finalizado -= animacion_Finalizada;
            animaciones.TryRemove(animacion.entidad_id, out MovimientoAnimacion animacion_eliminada);
            animacion.Dispose();

            Invalidate();
        }

        private void dibujar_Animaciones(Graphics g)
        {
            foreach (MovimientoAnimacion animacion in animaciones.Values)
            {
                if (animacion.path == null)
                    continue;

                using (SolidBrush brush = new SolidBrush(get_Animacion_Color(animacion)))
                    g.FillPie(brush, animacion.actual_punto.X - (RealCellHeight / 2 / 2), animacion.actual_punto.Y - RealCellHeight / 2 / 2, RealCellHeight / 2, RealCellHeight / 2, 0, 360);
            }
        }

        private void animacion_Finalizada(object sender, ElapsedEventArgs e)
        {
            if (animaciones.Count > 0)
                Invalidate();
            else if (!mostrar_animaciones)
                animaciones_timer.Stop();
        }

        private Color get_Animacion_Color(MovimientoAnimacion animacion)
        {
            switch (animacion.tipo_animacion)
            {
                case TipoAnimaciones.PERSONAJE:
                    return Color.Blue;

                case TipoAnimaciones.GRUPO_MONSTRUOS:
                    return Color.DarkRed;

                default:
                    return Color.FromArgb(81, 113, 202);
            }
        }

        public void refrescar_Mapa()
        {
            Mapa mapa_juego = cuenta.juego.mapa;

            if (mapa_juego == null || !mapa_juego.mapa_cargado)
                return;

            animaciones.Clear();
            animaciones_timer.Stop();

            Celda[] celdas_juego = mapa_juego.celdas;

            if (celdas_juego == null || celdas_juego.Length < 1)
                return;

            foreach (Celda celda in celdas_juego)
            {
                celdas[celda.id].estado = CeldaEstado.NO_CAMINABLE;

                if (celda.es_Caminable())
                    celdas[celda.id].estado = CeldaEstado.CAMINABLE;

                if (celda.es_linea_vision)
                    celdas[celda.id].estado = CeldaEstado.OBSTACULO;

                if (celda.es_Teleport())
                    celdas[celda.id].estado = CeldaEstado.CELDA_TELEPORT;

                if (celda.es_Interactivo())
                    celdas[celda.id].estado = CeldaEstado.OBJETO_INTERACTIVO;
            }

            animaciones_timer.Start();
            Invalidate();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            dibujar_Celdas(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            dibujar_Cuadricula();
            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mapa_raton_abajo)
            {
                CeldaMapa celda = get_Celda(e.Location);
                if (celda_retenida != null && celda_retenida != celda)
                {
                    OnCellClicked(celda_retenida, e.Button, true);
                    celda_retenida = celda;
                }
                if (celda != null)
                    OnCellClicked(celda, e.Button, true);
            }

            if (TraceOnOver)
            {
                var cell = get_Celda(e.Location);
                Rectangle rect = Rectangle.Empty;
                CeldaMapa last = null;

                if (CurrentCellOver != null && CurrentCellOver != cell)
                {
                    CurrentCellOver.MouseOverPen = null;

                    rect = CurrentCellOver.Rectangulo;
                    last = CurrentCellOver;
                }

                if (cell != null)
                {
                    cell.MouseOverPen = new Pen(BorderColorOnOver, 1);
                    rect = rect != Rectangle.Empty ? Rectangle.Union(rect, cell.Rectangulo) : cell.Rectangulo;
                    CurrentCellOver = cell;
                }

                OnCellOver(cell, last);

                if (rect != Rectangle.Empty)
                    Invalidate(rect);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            CeldaMapa cell = get_Celda(e.Location);

            if (cell != null)
            {
                celda_retenida = celda_abajo = cell;
            }
            mapa_raton_abajo = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mapa_raton_abajo = false;
            CeldaMapa cell = get_Celda(e.Location);

            if (celda_retenida != null)
            {
                OnCellClicked(celda_retenida, e.Button, cell != celda_abajo);
                celda_retenida = null;
            }
            base.OnMouseUp(e);
        }

        public CeldaMapa get_Celda(Point p) => celdas.FirstOrDefault(cell => cell.esta_En_Rectangulo(new Rectangle(p.X - RealCellWidth, p.Y - RealCellHeight, RealCellWidth, RealCellHeight)) && PointInPoly(cell.Puntos, p));

        public static bool PointInPoly(Point[] poly, Point p)
        {
            int x_antiguo, y_antiguo, x_nuevo, y_nuevo, x1, y1, x2, y2;
            bool inside = false;

            if (poly.Length < 3)
                return false;

            x_antiguo = poly[poly.Length - 1].X;
            y_antiguo = poly[poly.Length - 1].Y;

            foreach (Point t in poly)
            {
                x_nuevo = t.X;
                y_nuevo = t.Y;

                if (x_nuevo > x_antiguo)
                {
                    x1 = x_antiguo;
                    x2 = x_nuevo;
                    y1 = y_antiguo;
                    y2 = y_nuevo;
                }
                else
                {
                    x1 = x_nuevo;
                    x2 = x_antiguo;
                    y1 = y_nuevo;
                    y2 = y_antiguo;
                }

                if ((x_nuevo < p.X) == (p.X <= x_antiguo) && (p.Y - (long)y1) * (x2 - x1) < (y2 - (long)y1) * (p.X - x1))
                {
                    inside = !inside;
                }
                x_antiguo = x_nuevo;
                y_antiguo = y_nuevo;
            }

            return inside;
        }
    }
}