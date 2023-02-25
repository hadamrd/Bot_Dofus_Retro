﻿namespace Bot_Dofus_Retro.Tema.Forms
{
    partial class GestionCuentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionCuentas));
            this.tabControlPrincipalCuentas = new System.Windows.Forms.TabControl();
            this.ListaCuentas = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewCuentas = new System.Windows.Forms.ListView();
            this.ColumnaNombreCuenta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnaNombreServidor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnaNombrePersonaje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripFormCuentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDelPersonajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregarCuenta = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Nombre_Cuenta = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Eleccion_Servidor = new System.Windows.Forms.Label();
            this.label_Nombre_Personaje = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_nombre_personaje = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Servidor = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Nombre_Cuenta = new System.Windows.Forms.TextBox();
            this.boton_Agregar_Cuenta = new System.Windows.Forms.Button();
            this.checkBox_Agregar_Retroceder = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imagenesFormCuentas = new System.Windows.Forms.ImageList(this.components);
            this.tabControlPrincipalCuentas.SuspendLayout();
            this.ListaCuentas.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStripFormCuentas.SuspendLayout();
            this.AgregarCuenta.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPrincipalCuentas
            // 
            this.tabControlPrincipalCuentas.Controls.Add(this.ListaCuentas);
            this.tabControlPrincipalCuentas.Controls.Add(this.AgregarCuenta);
            this.tabControlPrincipalCuentas.Controls.Add(this.tabPage1);
            this.tabControlPrincipalCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrincipalCuentas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabControlPrincipalCuentas.ImageList = this.imagenesFormCuentas;
            this.tabControlPrincipalCuentas.ItemSize = new System.Drawing.Size(137, 28);
            this.tabControlPrincipalCuentas.Location = new System.Drawing.Point(0, 0);
            this.tabControlPrincipalCuentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlPrincipalCuentas.Name = "tabControlPrincipalCuentas";
            this.tabControlPrincipalCuentas.SelectedIndex = 0;
            this.tabControlPrincipalCuentas.Size = new System.Drawing.Size(461, 390);
            this.tabControlPrincipalCuentas.TabIndex = 0;
            // 
            // ListaCuentas
            // 
            this.ListaCuentas.Controls.Add(this.tableLayoutPanel1);
            this.ListaCuentas.ImageKey = "lista_cuentas.png";
            this.ListaCuentas.Location = new System.Drawing.Point(4, 32);
            this.ListaCuentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListaCuentas.Name = "ListaCuentas";
            this.ListaCuentas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListaCuentas.Size = new System.Drawing.Size(453, 354);
            this.ListaCuentas.TabIndex = 0;
            this.ListaCuentas.Text = "Lista de cuentas";
            this.ListaCuentas.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewCuentas, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.00565F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.99435F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 346);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.10158F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 304);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(441, 39);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // listViewCuentas
            // 
            this.listViewCuentas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnaNombreCuenta,
            this.ColumnaNombreServidor,
            this.ColumnaNombrePersonaje});
            this.listViewCuentas.ContextMenuStrip = this.contextMenuStripFormCuentas;
            this.listViewCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCuentas.FullRowSelect = true;
            this.listViewCuentas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCuentas.HideSelection = false;
            this.listViewCuentas.Location = new System.Drawing.Point(3, 4);
            this.listViewCuentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewCuentas.Name = "listViewCuentas";
            this.listViewCuentas.Size = new System.Drawing.Size(441, 293);
            this.listViewCuentas.TabIndex = 1;
            this.listViewCuentas.UseCompatibleStateImageBehavior = false;
            this.listViewCuentas.View = System.Windows.Forms.View.Details;
            this.listViewCuentas.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewCuentas_ColumnWidthChanging);
            this.listViewCuentas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewCuentas_MouseDoubleClick);
            // 
            // ColumnaNombreCuenta
            // 
            this.ColumnaNombreCuenta.Text = "Nombre de Cuenta";
            this.ColumnaNombreCuenta.Width = 148;
            // 
            // ColumnaNombreServidor
            // 
            this.ColumnaNombreServidor.Text = "Servidor";
            this.ColumnaNombreServidor.Width = 107;
            // 
            // ColumnaNombrePersonaje
            // 
            this.ColumnaNombrePersonaje.Text = "Nombre del personaje";
            this.ColumnaNombrePersonaje.Width = 184;
            // 
            // contextMenuStripFormCuentas
            // 
            this.contextMenuStripFormCuentas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripFormCuentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStripFormCuentas.Name = "contextMenuStripFormCuentas";
            this.contextMenuStripFormCuentas.Size = new System.Drawing.Size(147, 82);
            // 
            // conectarToolStripMenuItem
            // 
            this.conectarToolStripMenuItem.Image = global::Bot_Dofus_Retro.Properties.Resources.flecha_direccion_izquierda;
            this.conectarToolStripMenuItem.Name = "conectarToolStripMenuItem";
            this.conectarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.conectarToolStripMenuItem.Text = "Conectar";
            this.conectarToolStripMenuItem.Click += new System.EventHandler(this.conectarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentaToolStripMenuItem,
            this.contraseñaToolStripMenuItem,
            this.nombreDelPersonajeToolStripMenuItem});
            this.modificarToolStripMenuItem.Image = global::Bot_Dofus_Retro.Properties.Resources.icono_ajustes;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            this.cuentaToolStripMenuItem.Click += new System.EventHandler(this.modificar_Cuenta);
            // 
            // contraseñaToolStripMenuItem
            // 
            this.contraseñaToolStripMenuItem.Name = "contraseñaToolStripMenuItem";
            this.contraseñaToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.contraseñaToolStripMenuItem.Text = "Contraseña";
            this.contraseñaToolStripMenuItem.Click += new System.EventHandler(this.modificar_Cuenta);
            // 
            // nombreDelPersonajeToolStripMenuItem
            // 
            this.nombreDelPersonajeToolStripMenuItem.Name = "nombreDelPersonajeToolStripMenuItem";
            this.nombreDelPersonajeToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.nombreDelPersonajeToolStripMenuItem.Text = "Nombre del personaje";
            this.nombreDelPersonajeToolStripMenuItem.Click += new System.EventHandler(this.modificar_Cuenta);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::Bot_Dofus_Retro.Properties.Resources.cruz_roja;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // AgregarCuenta
            // 
            this.AgregarCuenta.Controls.Add(this.tableLayoutPanel5);
            this.AgregarCuenta.Controls.Add(this.checkBox_Agregar_Retroceder);
            this.AgregarCuenta.ImageKey = "agregar_cuenta.png";
            this.AgregarCuenta.Location = new System.Drawing.Point(4, 32);
            this.AgregarCuenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AgregarCuenta.Name = "AgregarCuenta";
            this.AgregarCuenta.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AgregarCuenta.Size = new System.Drawing.Size(453, 354);
            this.AgregarCuenta.TabIndex = 1;
            this.AgregarCuenta.Text = "Agregar una cuenta";
            this.AgregarCuenta.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.boton_Agregar_Cuenta, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.63636F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.36364F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(447, 319);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.96552F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.03448F));
            this.tableLayoutPanel6.Controls.Add(this.label_Nombre_Cuenta, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label_Password, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label_Eleccion_Servidor, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label_Nombre_Personaje, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel9, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(441, 273);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // label_Nombre_Cuenta
            // 
            this.label_Nombre_Cuenta.AutoSize = true;
            this.label_Nombre_Cuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Nombre_Cuenta.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nombre_Cuenta.Location = new System.Drawing.Point(3, 0);
            this.label_Nombre_Cuenta.Name = "label_Nombre_Cuenta";
            this.label_Nombre_Cuenta.Size = new System.Drawing.Size(121, 68);
            this.label_Nombre_Cuenta.TabIndex = 1;
            this.label_Nombre_Cuenta.Text = "Cuenta:";
            this.label_Nombre_Cuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Password.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_Password.Location = new System.Drawing.Point(3, 68);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(121, 68);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Contraseña:";
            this.label_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Eleccion_Servidor
            // 
            this.label_Eleccion_Servidor.AutoSize = true;
            this.label_Eleccion_Servidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Eleccion_Servidor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_Eleccion_Servidor.Location = new System.Drawing.Point(3, 136);
            this.label_Eleccion_Servidor.Name = "label_Eleccion_Servidor";
            this.label_Eleccion_Servidor.Size = new System.Drawing.Size(121, 68);
            this.label_Eleccion_Servidor.TabIndex = 5;
            this.label_Eleccion_Servidor.Text = "Servidor:";
            this.label_Eleccion_Servidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Nombre_Personaje
            // 
            this.label_Nombre_Personaje.AutoSize = true;
            this.label_Nombre_Personaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Nombre_Personaje.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_Nombre_Personaje.Location = new System.Drawing.Point(3, 204);
            this.label_Nombre_Personaje.Name = "label_Nombre_Personaje";
            this.label_Nombre_Personaje.Size = new System.Drawing.Size(121, 69);
            this.label_Nombre_Personaje.TabIndex = 7;
            this.label_Nombre_Personaje.Text = "Personaje:";
            this.label_Nombre_Personaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.textBox_nombre_personaje, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(130, 207);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(308, 63);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // textBox_nombre_personaje
            // 
            this.textBox_nombre_personaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_nombre_personaje.Location = new System.Drawing.Point(3, 24);
            this.textBox_nombre_personaje.MaxLength = 25;
            this.textBox_nombre_personaje.Name = "textBox_nombre_personaje";
            this.textBox_nombre_personaje.Size = new System.Drawing.Size(302, 29);
            this.textBox_nombre_personaje.TabIndex = 5;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.comboBox_Servidor, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(130, 139);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.39F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.61F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(308, 62);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // comboBox_Servidor
            // 
            this.comboBox_Servidor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Servidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Servidor.FormattingEnabled = true;
            this.comboBox_Servidor.Items.AddRange(new object[] {
            "Eratz",
            "Henual",
            "Bun",
            "Crail",
            "Gálgarion"});
            this.comboBox_Servidor.Location = new System.Drawing.Point(3, 20);
            this.comboBox_Servidor.Name = "comboBox_Servidor";
            this.comboBox_Servidor.Size = new System.Drawing.Size(302, 29);
            this.comboBox_Servidor.TabIndex = 6;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.textBox_Password, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(130, 71);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(308, 62);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Password.Location = new System.Drawing.Point(3, 23);
            this.textBox_Password.MaxLength = 25;
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(302, 29);
            this.textBox_Password.TabIndex = 4;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.textBox_Nombre_Cuenta, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(130, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(308, 62);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // textBox_Nombre_Cuenta
            // 
            this.textBox_Nombre_Cuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Nombre_Cuenta.Location = new System.Drawing.Point(3, 23);
            this.textBox_Nombre_Cuenta.MaxLength = 25;
            this.textBox_Nombre_Cuenta.Name = "textBox_Nombre_Cuenta";
            this.textBox_Nombre_Cuenta.Size = new System.Drawing.Size(302, 29);
            this.textBox_Nombre_Cuenta.TabIndex = 2;
            // 
            // boton_Agregar_Cuenta
            // 
            this.boton_Agregar_Cuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boton_Agregar_Cuenta.Location = new System.Drawing.Point(3, 282);
            this.boton_Agregar_Cuenta.Name = "boton_Agregar_Cuenta";
            this.boton_Agregar_Cuenta.Size = new System.Drawing.Size(441, 34);
            this.boton_Agregar_Cuenta.TabIndex = 9;
            this.boton_Agregar_Cuenta.Text = "Agregar cuenta";
            this.boton_Agregar_Cuenta.UseVisualStyleBackColor = true;
            this.boton_Agregar_Cuenta.Click += new System.EventHandler(this.boton_Agregar_Cuenta_Click);
            // 
            // checkBox_Agregar_Retroceder
            // 
            this.checkBox_Agregar_Retroceder.AutoSize = true;
            this.checkBox_Agregar_Retroceder.Checked = true;
            this.checkBox_Agregar_Retroceder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Agregar_Retroceder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox_Agregar_Retroceder.Location = new System.Drawing.Point(3, 323);
            this.checkBox_Agregar_Retroceder.Name = "checkBox_Agregar_Retroceder";
            this.checkBox_Agregar_Retroceder.Size = new System.Drawing.Size(447, 27);
            this.checkBox_Agregar_Retroceder.TabIndex = 51;
            this.checkBox_Agregar_Retroceder.Text = "Regresar a la pestaña \"Lista de cuentas\" despues de agregar la cuenta";
            this.checkBox_Agregar_Retroceder.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 354);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Agregar varias cuentas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imagenesFormCuentas
            // 
            this.imagenesFormCuentas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagenesFormCuentas.ImageStream")));
            this.imagenesFormCuentas.TransparentColor = System.Drawing.Color.Transparent;
            this.imagenesFormCuentas.Images.SetKeyName(0, "agregar_cuenta.png");
            this.imagenesFormCuentas.Images.SetKeyName(1, "lista_cuentas.png");
            // 
            // GestionCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 390);
            this.Controls.Add(this.tabControlPrincipalCuentas);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 437);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 437);
            this.Name = "GestionCuentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor cuentas";
            this.tabControlPrincipalCuentas.ResumeLayout(false);
            this.ListaCuentas.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStripFormCuentas.ResumeLayout(false);
            this.AgregarCuenta.ResumeLayout(false);
            this.AgregarCuenta.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipalCuentas;
        private System.Windows.Forms.TabPage ListaCuentas;
        private System.Windows.Forms.TabPage AgregarCuenta;
        private System.Windows.Forms.ImageList imagenesFormCuentas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFormCuentas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox_Agregar_Retroceder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label_Nombre_Cuenta;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Eleccion_Servidor;
        private System.Windows.Forms.Button boton_Agregar_Cuenta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label_Nombre_Personaje;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.ComboBox comboBox_Servidor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox textBox_Nombre_Cuenta;
        private System.Windows.Forms.ListView listViewCuentas;
        private System.Windows.Forms.ColumnHeader ColumnaNombreCuenta;
        private System.Windows.Forms.ColumnHeader ColumnaNombreServidor;
        private System.Windows.Forms.ColumnHeader ColumnaNombrePersonaje;
        private System.Windows.Forms.ToolStripMenuItem conectarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_nombre_personaje;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreDelPersonajeToolStripMenuItem;
    }
}