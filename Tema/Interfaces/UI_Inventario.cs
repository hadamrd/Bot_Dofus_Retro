﻿using Bot_Dofus_Retro.DarkUI.Docking;
using Bot_Dofus_Retro.Otros;
using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario;
using Bot_Dofus_Retro.Otros.Game.Personaje.Inventario.Enums;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Bot_Dofus_Retro.Tema.Interfaces
{
    public partial class UI_Inventario : DarkDocument
    {
        private Cuenta cuenta = null;

        public UI_Inventario(Cuenta _cuenta, string nombre, Bitmap icono)
        {
            InitializeComponent();
            cuenta = _cuenta;
            Icon = icono;
            DockText = nombre;
            cuenta.juego.personaje.inventario.inventario_actualizado += actualizar_Inventario;
        }

        private void UI_Inventario_Load(object sender, EventArgs e)
        {
            set_DoubleBuffered(dataGridView_equipamientos);
            set_DoubleBuffered(dataGridView_varios);
            set_DoubleBuffered(dataGridView_recursos);
        }

        private void actualizar_Inventario()
        {
            if (!IsHandleCreated)
                return;

            BeginInvoke((Action)(() =>
            {
                dataGridView_equipamientos.Rows.Clear();
                foreach (ObjetosInventario obj in cuenta.juego.personaje.inventario.equipamiento)
                    dataGridView_equipamientos.Rows.Add(new object[] { obj.id_inventario, obj.id_modelo, obj.nombre, obj.cantidad, obj.posicion, obj.posicion == InventarioPosiciones.NO_EQUIPADO ? "Equipar" : "Desequipar", "Eliminar" });

                dataGridView_varios.Rows.Clear();
                foreach (ObjetosInventario obj in cuenta.juego.personaje.inventario.varios)
                    dataGridView_varios.Rows.Add(new object[] { obj.id_inventario, obj.id_modelo, obj.nombre, obj.cantidad, obj.pods, "Eliminar" });

                dataGridView_recursos.Rows.Clear();
                foreach (ObjetosInventario obj in cuenta.juego.personaje.inventario.recursos)
                    dataGridView_recursos.Rows.Add(new object[] { obj.id_inventario, obj.id_modelo, obj.nombre, obj.cantidad, obj.pods, "Eliminar" });

                dataGridView_mision.Rows.Clear();
                foreach (ObjetosInventario obj in cuenta.juego.personaje.inventario.mision)
                    dataGridView_mision.Rows.Add(new object[] { obj.id_inventario, obj.id_modelo, obj.nombre, obj.cantidad });

            }));
        }

        private void dataGridView_equipamientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 5)
                return;

            ObjetosInventario objeto = cuenta.juego.personaje.inventario.equipamiento.ElementAt(e.RowIndex);

            string accion = dataGridView_equipamientos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            switch (accion)
            {
                case "Equipar":
                    cuenta.juego.personaje.inventario.equipar_Objeto(objeto);
                    break;

                case "Desequipar":
                    cuenta.juego.personaje.inventario.desequipar_Objeto(objeto);
                    break;

                case "Eliminar":
                    if (MessageBox.Show("Realmente deseas eliminar " + objeto.nombre + "?", "Eliminar un objeto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        cuenta.juego.personaje.inventario.eliminar_Objeto(objeto, 1, true);
                    break;
            }
        }

        private void dataGridView_recursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 5)
                return;

            ObjetosInventario objeto = cuenta.juego.personaje.inventario.recursos.ElementAt(e.RowIndex);
            string accion = dataGridView_recursos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (!int.TryParse(Interaction.InputBox($"Ingresa la cantidad para {accion.ToLower()} el objeto {objeto.nombre} (0 = todos):", accion, "1"), out int cantidad))
                return;

            switch (accion)
            {
                case "Eliminar":
                    cuenta.juego.personaje.inventario.eliminar_Objeto(objeto, cantidad, true);
                    break;
            }
        }

        public static void set_DoubleBuffered(Control control) => typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, control, new object[] { true });
    }
}
