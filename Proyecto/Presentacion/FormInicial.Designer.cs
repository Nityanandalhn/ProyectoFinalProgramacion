
namespace Presentacion
{
    partial class FormInicial
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
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNuevaReserva = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGestores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHabitaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReservas = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInicio,
            this.tsmiGestores});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(1187, 28);
            this.msPrincipal.TabIndex = 0;
            this.msPrincipal.Text = "Menu Principal";
            // 
            // tsmiInicio
            // 
            this.tsmiInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNuevaReserva,
            this.toolStripSeparator1,
            this.tsmiSalir});
            this.tsmiInicio.Name = "tsmiInicio";
            this.tsmiInicio.Size = new System.Drawing.Size(59, 24);
            this.tsmiInicio.Text = "Inicio";
            // 
            // tsmiNuevaReserva
            // 
            this.tsmiNuevaReserva.Name = "tsmiNuevaReserva";
            this.tsmiNuevaReserva.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNuevaReserva.Size = new System.Drawing.Size(242, 26);
            this.tsmiNuevaReserva.Text = "Nueva Reserva";
            this.tsmiNuevaReserva.Click += new System.EventHandler(this.tsmiNuevaReserva_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(242, 26);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // tsmiGestores
            // 
            this.tsmiGestores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHabitaciones,
            this.tsmiClientes,
            this.tsmiPlanVentas,
            this.tsmiEmpleados,
            this.tsmiReservas});
            this.tsmiGestores.Name = "tsmiGestores";
            this.tsmiGestores.Size = new System.Drawing.Size(135, 24);
            this.tsmiGestores.Text = "Gestion de datos";
            // 
            // tsmiHabitaciones
            // 
            this.tsmiHabitaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiHabitaciones.Name = "tsmiHabitaciones";
            this.tsmiHabitaciones.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmiHabitaciones.Size = new System.Drawing.Size(320, 26);
            this.tsmiHabitaciones.Text = "Modificar Habitaciones";
            this.tsmiHabitaciones.Click += new System.EventHandler(this.tsmiHabitaciones_Click);
            // 
            // tsmiClientes
            // 
            this.tsmiClientes.Name = "tsmiClientes";
            this.tsmiClientes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiClientes.Size = new System.Drawing.Size(320, 26);
            this.tsmiClientes.Text = "Modificar Clientes";
            this.tsmiClientes.Click += new System.EventHandler(this.tsmiClientes_Click);
            // 
            // tsmiPlanVentas
            // 
            this.tsmiPlanVentas.Name = "tsmiPlanVentas";
            this.tsmiPlanVentas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiPlanVentas.Size = new System.Drawing.Size(320, 26);
            this.tsmiPlanVentas.Text = "Modificar Planes de Ventas";
            this.tsmiPlanVentas.Click += new System.EventHandler(this.tsmiPlanVentas_Click);
            // 
            // tsmiEmpleados
            // 
            this.tsmiEmpleados.Name = "tsmiEmpleados";
            this.tsmiEmpleados.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiEmpleados.Size = new System.Drawing.Size(320, 26);
            this.tsmiEmpleados.Text = "Modificar Empleados";
            this.tsmiEmpleados.Click += new System.EventHandler(this.tsmiEmpleados_Click);
            // 
            // tsmiReservas
            // 
            this.tsmiReservas.Name = "tsmiReservas";
            this.tsmiReservas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiReservas.Size = new System.Drawing.Size(320, 26);
            this.tsmiReservas.Text = "Modificar Reservas";
            this.tsmiReservas.Click += new System.EventHandler(this.tsmiReservas_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 692);
            this.Controls.Add(this.msPrincipal);
            this.Name = "FormInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Gestor";
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiGestores;
        private System.Windows.Forms.ToolStripMenuItem tsmiHabitaciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanVentas;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpleados;
        private System.Windows.Forms.ToolStripMenuItem tsmiReservas;
        private System.Windows.Forms.ToolStripMenuItem tsmiInicio;
        private System.Windows.Forms.ToolStripMenuItem tsmiNuevaReserva;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
    }
}