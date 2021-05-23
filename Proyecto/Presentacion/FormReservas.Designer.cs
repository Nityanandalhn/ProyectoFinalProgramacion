
namespace Presentacion
{
    partial class FormReservas
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
            this.lblFechaEnt = new System.Windows.Forms.Label();
            this.txtTipoVenta = new System.Windows.Forms.TextBox();
            this.lblTipoVenta = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblHabitacion = new System.Windows.Forms.Label();
            this.txtHabitacion = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lsvReservas = new System.Windows.Forms.ListView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblDniCliente = new System.Windows.Forms.Label();
            this.txtDniCliente = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblSalida = new System.Windows.Forms.Label();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.lblFechaRva = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.nudDesc = new System.Windows.Forms.NumericUpDown();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaEnt
            // 
            this.lblFechaEnt.AutoSize = true;
            this.lblFechaEnt.Location = new System.Drawing.Point(51, 192);
            this.lblFechaEnt.Name = "lblFechaEnt";
            this.lblFechaEnt.Size = new System.Drawing.Size(63, 20);
            this.lblFechaEnt.TabIndex = 86;
            this.lblFechaEnt.Text = "Entrada:";
            // 
            // txtTipoVenta
            // 
            this.txtTipoVenta.Location = new System.Drawing.Point(142, 150);
            this.txtTipoVenta.MaxLength = 15;
            this.txtTipoVenta.Name = "txtTipoVenta";
            this.txtTipoVenta.Size = new System.Drawing.Size(179, 27);
            this.txtTipoVenta.TabIndex = 70;
            // 
            // lblTipoVenta
            // 
            this.lblTipoVenta.AutoSize = true;
            this.lblTipoVenta.Location = new System.Drawing.Point(51, 153);
            this.lblTipoVenta.Name = "lblTipoVenta";
            this.lblTipoVenta.Size = new System.Drawing.Size(42, 20);
            this.lblTipoVenta.TabIndex = 85;
            this.lblTipoVenta.Text = "Tipo:";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(327, 120);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(226, 20);
            this.lblEmpleado.TabIndex = 84;
            this.lblEmpleado.Text = "Empleado que aceptó la reserva:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(327, 153);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(218, 20);
            this.lblTipo.TabIndex = 83;
            this.lblTipo.Text = "Fecha de ceación de la reserva: ";
            // 
            // lblHabitacion
            // 
            this.lblHabitacion.AutoSize = true;
            this.lblHabitacion.Location = new System.Drawing.Point(51, 118);
            this.lblHabitacion.Name = "lblHabitacion";
            this.lblHabitacion.Size = new System.Drawing.Size(85, 20);
            this.lblHabitacion.TabIndex = 82;
            this.lblHabitacion.Text = "Habitacion:";
            // 
            // txtHabitacion
            // 
            this.txtHabitacion.Location = new System.Drawing.Point(142, 117);
            this.txtHabitacion.MaxLength = 9;
            this.txtHabitacion.Name = "txtHabitacion";
            this.txtHabitacion.Size = new System.Drawing.Size(179, 27);
            this.txtHabitacion.TabIndex = 68;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(467, 536);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(139, 29);
            this.btnEliminar.TabIndex = 81;
            this.btnEliminar.Text = "Eliminar Reserva";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(612, 537);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(138, 29);
            this.btnEditar.TabIndex = 80;
            this.btnEditar.Text = "Aplicar Cambios";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(265, 537);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(94, 29);
            this.btnFiltrar.TabIndex = 79;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lsvReservas
            // 
            this.lsvReservas.FullRowSelect = true;
            this.lsvReservas.GridLines = true;
            this.lsvReservas.HideSelection = false;
            this.lsvReservas.Location = new System.Drawing.Point(51, 248);
            this.lsvReservas.Name = "lsvReservas";
            this.lsvReservas.Size = new System.Drawing.Size(699, 283);
            this.lsvReservas.TabIndex = 78;
            this.lsvReservas.UseCompatibleStateImageBehavior = false;
            this.lsvReservas.View = System.Windows.Forms.View.Details;
            this.lsvReservas.Click += new System.EventHandler(this.lsvReservas_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(365, 537);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(67, 29);
            this.btnLimpiar.TabIndex = 77;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(327, 87);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(60, 20);
            this.lblDescuento.TabIndex = 75;
            this.lblDescuento.Text = "% Desc:";
            // 
            // lblDniCliente
            // 
            this.lblDniCliente.AutoSize = true;
            this.lblDniCliente.Location = new System.Drawing.Point(51, 87);
            this.lblDniCliente.Name = "lblDniCliente";
            this.lblDniCliente.Size = new System.Drawing.Size(35, 20);
            this.lblDniCliente.TabIndex = 74;
            this.lblDniCliente.Text = "Dni:";
            // 
            // txtDniCliente
            // 
            this.txtDniCliente.Location = new System.Drawing.Point(142, 84);
            this.txtDniCliente.MaxLength = 120;
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.Size = new System.Drawing.Size(179, 27);
            this.txtDniCliente.TabIndex = 66;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(51, 52);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(61, 20);
            this.lblCod.TabIndex = 73;
            this.lblCod.Text = "Codigo:";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(142, 51);
            this.txtCod.MaxLength = 60;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(179, 27);
            this.txtCod.TabIndex = 64;
            // 
            // lblSalida
            // 
            this.lblSalida.AutoSize = true;
            this.lblSalida.Location = new System.Drawing.Point(430, 192);
            this.lblSalida.Name = "lblSalida";
            this.lblSalida.Size = new System.Drawing.Size(53, 20);
            this.lblSalida.TabIndex = 88;
            this.lblSalida.Text = "Salida:";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Location = new System.Drawing.Point(51, 215);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(318, 27);
            this.dtpEntrada.TabIndex = 89;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Location = new System.Drawing.Point(430, 215);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(320, 27);
            this.dtpSalida.TabIndex = 90;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(327, 54);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(57, 20);
            this.lblOrigen.TabIndex = 76;
            this.lblOrigen.Text = "Origen:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(405, 51);
            this.txtOrigen.MaxLength = 90;
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(345, 27);
            this.txtOrigen.TabIndex = 65;
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(580, 120);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(64, 20);
            this.lblNombreEmpleado.TabIndex = 91;
            this.lblNombreEmpleado.Text = "Nombre";
            // 
            // lblFechaRva
            // 
            this.lblFechaRva.AutoSize = true;
            this.lblFechaRva.Location = new System.Drawing.Point(580, 153);
            this.lblFechaRva.Name = "lblFechaRva";
            this.lblFechaRva.Size = new System.Drawing.Size(93, 20);
            this.lblFechaRva.TabIndex = 92;
            this.lblFechaRva.Text = "yyyy-MM-dd";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(51, 587);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(61, 20);
            this.lblSistema.TabIndex = 93;
            this.lblSistema.Text = "Sistema";
            // 
            // nudDesc
            // 
            this.nudDesc.DecimalPlaces = 2;
            this.nudDesc.Location = new System.Drawing.Point(405, 84);
            this.nudDesc.Name = "nudDesc";
            this.nudDesc.Size = new System.Drawing.Size(150, 27);
            this.nudDesc.TabIndex = 94;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(51, 538);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(208, 27);
            this.txtFiltro.TabIndex = 95;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // FormReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 616);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.nudDesc);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblFechaRva);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.dtpSalida);
            this.Controls.Add(this.dtpEntrada);
            this.Controls.Add(this.lblSalida);
            this.Controls.Add(this.lblFechaEnt);
            this.Controls.Add(this.txtTipoVenta);
            this.Controls.Add(this.lblTipoVenta);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblHabitacion);
            this.Controls.Add(this.txtHabitacion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lsvReservas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblDniCliente);
            this.Controls.Add(this.txtDniCliente);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.txtCod);
            this.Name = "FormReservas";
            this.Text = "FormReservas";
            ((System.ComponentModel.ISupportInitialize)(this.nudDesc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFechaEnt;
        private System.Windows.Forms.TextBox txtTipoVenta;
        private System.Windows.Forms.Label lblTipoVenta;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblHabitacion;
        private System.Windows.Forms.TextBox txtHabitacion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ListView lsvReservas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblDniCliente;
        private System.Windows.Forms.TextBox txtDniCliente;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblSalida;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label lblNombreEmpleado;
        private System.Windows.Forms.Label lblFechaRva;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.NumericUpDown nudDesc;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}