
namespace Presentacion
{
    partial class FormHabitaciones
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
            this.lblTotalHab = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblCodHab = new System.Windows.Forms.Label();
            this.lblCamas = new System.Windows.Forms.Label();
            this.txtCamas = new System.Windows.Forms.TextBox();
            this.lblMaxPax = new System.Windows.Forms.Label();
            this.txtPax = new System.Windows.Forms.TextBox();
            this.lblPlanta = new System.Windows.Forms.Label();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.lblCantidadHab = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lsvHabitaciones = new System.Windows.Forms.ListView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotalHab
            // 
            this.lblTotalHab.AutoSize = true;
            this.lblTotalHab.Location = new System.Drawing.Point(670, 27);
            this.lblTotalHab.Name = "lblTotalHab";
            this.lblTotalHab.Size = new System.Drawing.Size(70, 20);
            this.lblTotalHab.TabIndex = 0;
            this.lblTotalHab.Text = "TotalHab";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(70, 380);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(61, 20);
            this.lblSistema.TabIndex = 1;
            this.lblSistema.Text = "Sistema";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(109, 24);
            this.txtCod.MaxLength = 4;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(67, 27);
            this.txtCod.TabIndex = 2;
            // 
            // lblCodHab
            // 
            this.lblCodHab.AutoSize = true;
            this.lblCodHab.Location = new System.Drawing.Point(41, 25);
            this.lblCodHab.Name = "lblCodHab";
            this.lblCodHab.Size = new System.Drawing.Size(61, 20);
            this.lblCodHab.TabIndex = 3;
            this.lblCodHab.Text = "Código:";
            // 
            // lblCamas
            // 
            this.lblCamas.AutoSize = true;
            this.lblCamas.Location = new System.Drawing.Point(182, 27);
            this.lblCamas.Name = "lblCamas";
            this.lblCamas.Size = new System.Drawing.Size(56, 20);
            this.lblCamas.TabIndex = 5;
            this.lblCamas.Text = "Camas:";
            // 
            // txtCamas
            // 
            this.txtCamas.Location = new System.Drawing.Point(244, 25);
            this.txtCamas.MaxLength = 1;
            this.txtCamas.Name = "txtCamas";
            this.txtCamas.Size = new System.Drawing.Size(27, 27);
            this.txtCamas.TabIndex = 4;
            // 
            // lblMaxPax
            // 
            this.lblMaxPax.AutoSize = true;
            this.lblMaxPax.Location = new System.Drawing.Point(277, 28);
            this.lblMaxPax.Name = "lblMaxPax";
            this.lblMaxPax.Size = new System.Drawing.Size(34, 20);
            this.lblMaxPax.TabIndex = 7;
            this.lblMaxPax.Text = "Pax:";
            // 
            // txtPax
            // 
            this.txtPax.Location = new System.Drawing.Point(317, 25);
            this.txtPax.MaxLength = 2;
            this.txtPax.Name = "txtPax";
            this.txtPax.Size = new System.Drawing.Size(29, 27);
            this.txtPax.TabIndex = 6;
            // 
            // lblPlanta
            // 
            this.lblPlanta.AutoSize = true;
            this.lblPlanta.Location = new System.Drawing.Point(352, 28);
            this.lblPlanta.Name = "lblPlanta";
            this.lblPlanta.Size = new System.Drawing.Size(53, 20);
            this.lblPlanta.TabIndex = 9;
            this.lblPlanta.Text = "Planta:";
            // 
            // txtPlanta
            // 
            this.txtPlanta.Location = new System.Drawing.Point(411, 24);
            this.txtPlanta.MaxLength = 2;
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.Size = new System.Drawing.Size(31, 27);
            this.txtPlanta.TabIndex = 8;
            // 
            // lblCantidadHab
            // 
            this.lblCantidadHab.AutoSize = true;
            this.lblCantidadHab.Location = new System.Drawing.Point(547, 27);
            this.lblCantidadHab.Name = "lblCantidadHab";
            this.lblCantidadHab.Size = new System.Drawing.Size(117, 20);
            this.lblCantidadHab.TabIndex = 10;
            this.lblCantidadHab.Text = "Cantidad listada";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(673, 345);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(67, 29);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lsvHabitaciones
            // 
            this.lsvHabitaciones.FullRowSelect = true;
            this.lsvHabitaciones.GridLines = true;
            this.lsvHabitaciones.HideSelection = false;
            this.lsvHabitaciones.Location = new System.Drawing.Point(41, 58);
            this.lsvHabitaciones.Name = "lsvHabitaciones";
            this.lsvHabitaciones.Size = new System.Drawing.Size(699, 281);
            this.lsvHabitaciones.TabIndex = 12;
            this.lsvHabitaciones.UseCompatibleStateImageBehavior = false;
            this.lsvHabitaciones.View = System.Windows.Forms.View.Details;
            this.lsvHabitaciones.Click += new System.EventHandler(this.lsvHabitaciones_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(570, 345);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 29);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(470, 345);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(94, 29);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(378, 345);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 29);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 412);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lsvHabitaciones);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblCantidadHab);
            this.Controls.Add(this.lblPlanta);
            this.Controls.Add(this.txtPlanta);
            this.Controls.Add(this.lblMaxPax);
            this.Controls.Add(this.txtPax);
            this.Controls.Add(this.lblCamas);
            this.Controls.Add(this.txtCamas);
            this.Controls.Add(this.lblCodHab);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblTotalHab);
            this.Name = "FormHabitaciones";
            this.Text = "Gestionar Habitaciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalHab;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblCodHab;
        private System.Windows.Forms.Label lblCamas;
        private System.Windows.Forms.TextBox txtCamas;
        private System.Windows.Forms.Label lblMaxPax;
        private System.Windows.Forms.TextBox txtPax;
        private System.Windows.Forms.Label lblPlanta;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.Label lblCantidadHab;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListView lsvHabitaciones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
    }
}