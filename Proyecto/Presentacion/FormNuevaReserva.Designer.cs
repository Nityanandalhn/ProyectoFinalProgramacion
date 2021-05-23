
namespace Presentacion
{
    partial class FormNuevaReserva
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
            this.dtpFchEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpFchSalida = new System.Windows.Forms.DateTimePicker();
            this.btnAceptarEntrada = new System.Windows.Forms.Button();
            this.cmbPlanVentas = new System.Windows.Forms.ComboBox();
            this.cmbHabitacion = new System.Windows.Forms.ComboBox();
            this.lblFchEntrada = new System.Windows.Forms.Label();
            this.lblFchSalida = new System.Windows.Forms.Label();
            this.lblHabitacion = new System.Windows.Forms.Label();
            this.lblPlanVenta = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.lsvClientes = new System.Windows.Forms.ListView();
            this.lblSistema = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFchEntrada
            // 
            this.dtpFchEntrada.Location = new System.Drawing.Point(244, 46);
            this.dtpFchEntrada.Name = "dtpFchEntrada";
            this.dtpFchEntrada.Size = new System.Drawing.Size(295, 27);
            this.dtpFchEntrada.TabIndex = 0;
            // 
            // dtpFchSalida
            // 
            this.dtpFchSalida.Location = new System.Drawing.Point(244, 108);
            this.dtpFchSalida.Name = "dtpFchSalida";
            this.dtpFchSalida.Size = new System.Drawing.Size(295, 27);
            this.dtpFchSalida.TabIndex = 1;
            // 
            // btnAceptarEntrada
            // 
            this.btnAceptarEntrada.Location = new System.Drawing.Point(16, 336);
            this.btnAceptarEntrada.Name = "btnAceptarEntrada";
            this.btnAceptarEntrada.Size = new System.Drawing.Size(169, 78);
            this.btnAceptarEntrada.TabIndex = 2;
            this.btnAceptarEntrada.Text = "Aceptar";
            this.btnAceptarEntrada.UseVisualStyleBackColor = true;
            this.btnAceptarEntrada.Click += new System.EventHandler(this.btnAceptarEntrada_Click);
            // 
            // cmbPlanVentas
            // 
            this.cmbPlanVentas.FormattingEnabled = true;
            this.cmbPlanVentas.Location = new System.Drawing.Point(16, 45);
            this.cmbPlanVentas.Name = "cmbPlanVentas";
            this.cmbPlanVentas.Size = new System.Drawing.Size(151, 28);
            this.cmbPlanVentas.TabIndex = 3;
            // 
            // cmbHabitacion
            // 
            this.cmbHabitacion.FormattingEnabled = true;
            this.cmbHabitacion.Location = new System.Drawing.Point(16, 108);
            this.cmbHabitacion.Name = "cmbHabitacion";
            this.cmbHabitacion.Size = new System.Drawing.Size(151, 28);
            this.cmbHabitacion.TabIndex = 4;
            // 
            // lblFchEntrada
            // 
            this.lblFchEntrada.AutoSize = true;
            this.lblFchEntrada.Location = new System.Drawing.Point(335, 23);
            this.lblFchEntrada.Name = "lblFchEntrada";
            this.lblFchEntrada.Size = new System.Drawing.Size(123, 20);
            this.lblFchEntrada.TabIndex = 5;
            this.lblFchEntrada.Text = "Fecha de Entrada";
            // 
            // lblFchSalida
            // 
            this.lblFchSalida.AutoSize = true;
            this.lblFchSalida.Location = new System.Drawing.Point(335, 85);
            this.lblFchSalida.Name = "lblFchSalida";
            this.lblFchSalida.Size = new System.Drawing.Size(113, 20);
            this.lblFchSalida.TabIndex = 6;
            this.lblFchSalida.Text = "Fecha de Salida";
            // 
            // lblHabitacion
            // 
            this.lblHabitacion.AutoSize = true;
            this.lblHabitacion.Location = new System.Drawing.Point(44, 85);
            this.lblHabitacion.Name = "lblHabitacion";
            this.lblHabitacion.Size = new System.Drawing.Size(82, 20);
            this.lblHabitacion.TabIndex = 7;
            this.lblHabitacion.Text = "Habitación";
            // 
            // lblPlanVenta
            // 
            this.lblPlanVenta.AutoSize = true;
            this.lblPlanVenta.Location = new System.Drawing.Point(44, 22);
            this.lblPlanVenta.Name = "lblPlanVenta";
            this.lblPlanVenta.Size = new System.Drawing.Size(99, 20);
            this.lblPlanVenta.TabIndex = 8;
            this.lblPlanVenta.Text = "Plan de Venta";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(15, 174);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(152, 27);
            this.txtOrigen.TabIndex = 9;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(25, 151);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(142, 20);
            this.lblOrigen.TabIndex = 10;
            this.lblOrigen.Text = "Origen de la reserva";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(370, 336);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(169, 78);
            this.btnTerminar.TabIndex = 11;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // lsvClientes
            // 
            this.lsvClientes.AllowColumnReorder = true;
            this.lsvClientes.FullRowSelect = true;
            this.lsvClientes.GridLines = true;
            this.lsvClientes.HideSelection = false;
            this.lsvClientes.Location = new System.Drawing.Point(244, 174);
            this.lsvClientes.Name = "lsvClientes";
            this.lsvClientes.Size = new System.Drawing.Size(295, 99);
            this.lsvClientes.TabIndex = 12;
            this.lsvClientes.UseCompatibleStateImageBehavior = false;
            this.lsvClientes.View = System.Windows.Forms.View.Details;
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(25, 421);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(61, 20);
            this.lblSistema.TabIndex = 13;
            this.lblSistema.Text = "Sistema";
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Location = new System.Drawing.Point(17, 246);
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(150, 27);
            this.nudDescuento.TabIndex = 14;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(44, 223);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(95, 20);
            this.lblDescuento.TabIndex = 15;
            this.lblDescuento.Text = "% Descuento";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(370, 151);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(61, 20);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Clientes";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(370, 279);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(169, 27);
            this.txtFiltro.TabIndex = 17;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(244, 279);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(120, 27);
            this.btnFiltrar.TabIndex = 18;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FormNuevaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lsvClientes);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.lblPlanVenta);
            this.Controls.Add(this.lblHabitacion);
            this.Controls.Add(this.lblFchSalida);
            this.Controls.Add(this.lblFchEntrada);
            this.Controls.Add(this.cmbHabitacion);
            this.Controls.Add(this.cmbPlanVentas);
            this.Controls.Add(this.btnAceptarEntrada);
            this.Controls.Add(this.dtpFchSalida);
            this.Controls.Add(this.dtpFchEntrada);
            this.Name = "FormNuevaReserva";
            this.Text = "Nueva Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFchEntrada;
        private System.Windows.Forms.DateTimePicker dtpFchSalida;
        private System.Windows.Forms.Button btnAceptarEntrada;
        private System.Windows.Forms.ComboBox cmbPlanVentas;
        private System.Windows.Forms.ComboBox cmbHabitacion;
        private System.Windows.Forms.Label lblFchEntrada;
        private System.Windows.Forms.Label lblFchSalida;
        private System.Windows.Forms.Label lblHabitacion;
        private System.Windows.Forms.Label lblPlanVenta;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.ListView lsvClientes;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnFiltrar;
    }
}