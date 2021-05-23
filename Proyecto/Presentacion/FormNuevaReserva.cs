using System;
using Negocio;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormNuevaReserva : Form
    {
        private GesReserva gesReserva;
        public FormNuevaReserva()
        {
            InitializeComponent();
            this.ActiveControl = txtOrigen;
            gesReserva = new GesReserva();
            lblSistema.Text = gesReserva.Error;
            MostrarElementos();
        }

        private void LimpiarPresentacion()
        {
        }

        private void MostrarElementos()
        {
            ListarClientes();

            gesReserva.GesHabitacion.Habitaciones.ForEach(h => cmbHabitacion.Items.Add(h.Cod));
            gesReserva.GesPlanVentas.Planes.ForEach(p => cmbPlanVentas.Items.Add(p.Tipo));
        }
        private void ListarClientes()
        {
            ListarClientes("");
        }
        private void ListarClientes(string filtro)
        {
            lsvClientes.Clear();

            lsvClientes.Columns.Add("Dni", 100);
            lsvClientes.Columns.Add("Nombre", 100);
            lsvClientes.Columns.Add("Apellidos", 100);

            lsvClientes.AllowColumnReorder = true;

            if (filtro == "")
            {
                gesReserva.GesCliente.Clientes.ForEach(c => lsvClientes.Items.Add(new ListViewItem(
                    new string[] { c.Dni, c.Nombre, c.Apellidos })));
            }
            else
            {
                gesReserva.GesCliente.Clientes.ForEach(c =>
                {
                    bool existeDni = false;
                    bool existeNombre = false;

                    if (c.Dni.Length >= filtro.Length)
                        existeDni = c.Dni[..filtro.Length].CompareTo(filtro) == 0;

                    if (c.NombreCompleto().Length >= filtro.Length)
                        existeNombre = c.NombreCompleto()[..filtro.Length].CompareTo(filtro) == 0;

                    if (existeDni || existeNombre)
                    {
                        lsvClientes.Items.Add(new ListViewItem(new string[] { c.Dni, c.Nombre, c.Apellidos }));
                    }
                });
            }
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";

            if (cmbHabitacion.SelectedIndex > -1 && cmbPlanVentas.SelectedIndex > -1
                && txtOrigen.Text != "" && lsvClientes.SelectedItems.Count > 0)
            {
                try
                {
                    gesReserva.Reserva.CodHabitacion = gesReserva.GesHabitacion.Habitaciones[cmbHabitacion.SelectedIndex].Cod;
                    gesReserva.Reserva.PlanVenta = gesReserva.GesPlanVentas.Planes[cmbPlanVentas.SelectedIndex].Tipo;
                    gesReserva.Reserva.DniCliente = gesReserva.GesCliente.Clientes[lsvClientes.FocusedItem.Index].Dni;
                    return true;
                }
                catch
                {
                    //Por si cambian los listados antes de la operación (Aunque debería estar controlado)
                    lblSistema.Text = "Algo ha salido mal. Trata de repetir la operación tras reiniciar la ventana.";
                }
            }
            return false;
        }

        private void btnAceptarEntrada_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
            {
                gesReserva.NuevaReserva(dtpFchEntrada.Value, dtpFchSalida.Value,
                    txtOrigen.Text, (float)nudDescuento.Value);

                if (gesReserva.Error != "")
                {
                    if (gesReserva.Error.Contains("Duplicate"))
                        lblSistema.Text = "Esta reserva ya ha sido realizada anteriormente.";

                    else
                        lblSistema.Text = gesReserva.Error;
                }
                else
                    lblSistema.Text = "Reserva completada.";
            }
            else
                lblSistema.Text = "Faltan elementos por introducir o seleccionar.";
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ListarClientes(txtFiltro.Text);
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ListarClientes(txtFiltro.Text);
        }
    }
}
