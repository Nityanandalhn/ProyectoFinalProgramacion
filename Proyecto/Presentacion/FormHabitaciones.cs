using System;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class FormHabitaciones : Form
    {
        private GesHabitacion gesHab;
        public FormHabitaciones()
        {
            InitializeComponent();

            gesHab = new GesHabitacion();

            lblSistema.Text = gesHab.Error;

            MostrarListadoHabitaciones();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPresentacion();
        }

        private void LimpiarPresentacion()
        {
            gesHab.BuscarTodasHabitaciones();

            txtCamas.Text = "";
            txtPax.Text = "";
            txtCod.Text = "";
            txtPlanta.Text = "";
            lblSistema.Text = gesHab.Error;

            MostrarListadoHabitaciones();
        }

        private void MostrarListadoHabitaciones()
        {
            lsvHabitaciones.Clear();

            lsvHabitaciones.Columns.Add("Habitación", 100);
            lsvHabitaciones.Columns.Add("Tipo", 100);
            lsvHabitaciones.Columns.Add("Planta", 100);
            lsvHabitaciones.Columns.Add("Camas", 100);

            lsvHabitaciones.AllowColumnReorder = true;

            gesHab.Habitaciones.ForEach(h => lsvHabitaciones.Items.Add(new ListViewItem(
                new string[]
                {
                    h.Cod,
                    h.MaxHuespedes switch {
                        1 => "Individual",
                        2 => "Doble",
                        3 => "Triple",
                        4 => "Cuádruple",
                        _ => h.MaxHuespedes.ToString() + " Pax"
                    },
                    h.Planta,
                    h.Camas.ToString()
                })));

            lblTotalHab.Text = gesHab.Habitaciones.Count.ToString();
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";

            if (int.TryParse(txtCamas.Text, out int camas) 
                && int.TryParse(txtPax.Text, out int pax)
                && txtCod.Text != ""
                && txtPlanta.Text != "")
            {
                gesHab.Habitacion = new Habitacion()
                {
                    Camas = camas,
                    Cod = txtCod.Text,
                    MaxHuespedes = pax,
                    Planta = txtPlanta.Text
                };

                return true;
            }
            else
            {
                lblSistema.Text = "Datos introducidos incorrectos. Operación cancelada.";
                return false;
            }
        }

        private void MapearPresentacion()
        {
            txtCamas.Text = gesHab.Habitacion.Camas.ToString();
            txtCod.Text = gesHab.Habitacion.Cod;
            txtPax.Text = gesHab.Habitacion.MaxHuespedes.ToString();
            txtPlanta.Text = gesHab.Habitacion.Planta;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gesHab.BuscarHabitaciones(
                txtCod.Text,
                txtCamas.Text,
                txtPlanta.Text,
                txtPax.Text
            );
            MostrarListadoHabitaciones();

            lblSistema.Text = gesHab.Error;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
                gesHab.Editar();
            if(lblSistema.Text == "")
                lblSistema.Text = gesHab.Error;

            gesHab.BuscarTodasHabitaciones();
            MostrarListadoHabitaciones();
        }

        private void lsvHabitaciones_Click(object sender, EventArgs e)
        {
            try
            {
                gesHab.Habitacion = gesHab.Habitaciones[lsvHabitaciones.FocusedItem.Index];
                MapearPresentacion();
            }
            catch
            {
                //Por si cambia el listado antes de la operación (Aunque debería estar controlado)
                lblSistema.Text = "Algo ha salido mal. Trata de repetir la operación tras reiniciar el listado.";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que desea eliminar esta entrada?", "Eliminar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                    gesHab.Eliminar();
            }
            if (lblSistema.Text == "")
                lblSistema.Text = gesHab.Error;

            gesHab.BuscarTodasHabitaciones();
            MostrarListadoHabitaciones();
        }
    }
}
