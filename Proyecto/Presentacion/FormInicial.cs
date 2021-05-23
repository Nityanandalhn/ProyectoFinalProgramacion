using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void AbrirFormulario(Form formulario)
        {
            bool abierto = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().Equals(formulario.GetType()))
                    abierto = true;
            }

            formulario.MdiParent = this;

            if (!abierto)
                formulario.Show();
        }

        private void tsmiHabitaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHabitaciones());
        }

        private void tsmiClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormClientes());
        }

        private void tsmiPlanVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormPlanVentas());
        }

        private void tsmiEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormEmpleados());
        }

        private void tsmiReservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReservas());
        }

        private void tsmiNuevaReserva_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormNuevaReserva());
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
