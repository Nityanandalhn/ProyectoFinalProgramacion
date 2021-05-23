using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormReservas : Form
    {
        private GesReserva gesReserva;
        public FormReservas()
        {
            InitializeComponent();

            gesReserva = new GesReserva();
            gesReserva.BuscarTodasReservas();
            lblSistema.Text = gesReserva.Error;

            MostrarListado();
        }

        private void LimpiarPresentacion()
        {
            gesReserva.BuscarTodasReservas();

            txtCod.Text = "";
            txtDniCliente.Text = "";
            txtOrigen.Text = "";
            nudDesc.Value = 0;
            txtHabitacion.Text = "";
            txtTipoVenta.Text = "";
            txtFiltro.Text = "";
            lblSistema.Text = gesReserva.Error;

            MostrarListado();
        }
        private void MostrarListado()
        {
            MostrarListado("");
        }
        private void MostrarListado(string filtro)
        {
            ConfigurarListViewReservas();

            if (filtro == "")
            {
                gesReserva.Reservas.ForEach(reserva => ListarReserva(reserva));
            }
            else
            {
                ListarFiltrado(filtro);
            }
        }

        private void ListarFiltrado(string filtro)
        {
            gesReserva.Reservas.ForEach(r =>
            {
                bool existeCodigo = false;
                bool existeDni = false;
                bool existeNombreCliente = false;

                string nombreCliente = gesReserva.GesCliente.Clientes.Find(
                    c => c.Dni == r.DniCliente).NombreCompleto();

                string nombreEmpleado = gesReserva.GesEmpleado.Empleados.Find(
                    e => e.Dni == r.DniEmpleado).NombreCompleto();

                if(r.Codigo.ToString().Length >= filtro.Length)
                    existeCodigo = r.Codigo.ToString()[..filtro.Length].CompareTo(filtro) == 0;

                if(r.DniCliente.Length >= filtro.Length)
                    existeDni = r.DniCliente[..filtro.Length].CompareTo(filtro) == 0;

                if (nombreCliente.Length >= filtro.Length)
                    existeNombreCliente = nombreCliente[..filtro.Length].CompareTo(filtro) == 0;

                if (existeCodigo || existeDni || existeNombreCliente)
                    ListarReserva(r);
            });
        }

        private void ListarReserva(Reserva reserva)
        {
            PlanVentas pv = gesReserva.GesPlanVentas.Planes.Find(p => p.Tipo == reserva.PlanVenta);
            int cantidadDias = (int)Math.Max(1, (reserva.FechaSalida - reserva.FechaEntrada).TotalDays);

            string costeTotal = (pv.Precio * cantidadDias).ToString();
            ListViewItem lsvi = new ListViewItem(new string[] {
                    reserva.Codigo.ToString(),
                    reserva.DniCliente,
                    gesReserva.GesCliente.Clientes.Find(c => c.Dni == reserva.DniCliente).NombreCompleto(),
                    reserva.CodHabitacion,
                    reserva.PlanVenta,
                    costeTotal,
                    reserva.FechaReserva.ToString("yyyy-MM-dd"),
                    reserva.FechaEntrada.ToString("yyyy-MM-dd"),
                    reserva.FechaSalida.ToString("yyyy-MM-dd"),
                    reserva.Origen,
                    reserva.Descuento switch { 0 => "", _ => reserva.Descuento.ToString() },
                    gesReserva.GesEmpleado.Empleados.Find(e => e.Dni == reserva.DniEmpleado).NombreCompleto()
            });

            lsvReservas.Items.Add(lsvi);
        }

        private void ConfigurarListViewReservas()
        {
            lsvReservas.Clear();

            lsvReservas.Columns.Add("ID", 50);
            lsvReservas.Columns.Add("DNI", 100);
            lsvReservas.Columns.Add("Cliente", 100);
            lsvReservas.Columns.Add("Habitación", 50);
            lsvReservas.Columns.Add("Tipo", 100);
            lsvReservas.Columns.Add("Total", 50);
            lsvReservas.Columns.Add("Reservado", 100);
            lsvReservas.Columns.Add("Entrada", 100);
            lsvReservas.Columns.Add("Salida", 100);
            lsvReservas.Columns.Add("Origen", 50);
            lsvReservas.Columns.Add("Descuento", 50);
            lsvReservas.Columns.Add("Empleado", 100);

            lsvReservas.AllowColumnReorder = true;
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";

            if (int.TryParse(txtCod.Text, out int cod))
            {
                gesReserva.RecuperarReserva(cod);
                gesReserva.Reserva.Descuento = (float)nudDesc.Value;
                gesReserva.Reserva.Origen = txtOrigen.Text;
                gesReserva.Reserva.DniCliente = txtDniCliente.Text;
                gesReserva.Reserva.CodHabitacion = txtHabitacion.Text;
                gesReserva.Reserva.PlanVenta = txtTipoVenta.Text;
                gesReserva.Reserva.FechaEntrada = dtpEntrada.Value;
                gesReserva.Reserva.FechaSalida = dtpSalida.Value;

                lblSistema.Text = gesReserva.Error;
                return true;
            }
            else
            {
                lblSistema.Text = "Identificador de reserva incorrecto.";
                return false;
            }
        }

        private void MapearPresentacion()
        {
            txtCod.Text = gesReserva.Reserva.Codigo.ToString();
            txtDniCliente.Text = gesReserva.Reserva.DniCliente;
            txtOrigen.Text = gesReserva.Reserva.Origen;
            nudDesc.Value = (decimal)gesReserva.Reserva.Descuento;
            txtHabitacion.Text = gesReserva.Reserva.CodHabitacion;
            txtTipoVenta.Text = gesReserva.Reserva.PlanVenta;
            lblNombreEmpleado.Text = gesReserva.GesEmpleado.Empleado.NombreCompleto();
            lblFechaRva.Text = gesReserva.Reserva.FechaReserva.ToString("yyyy-MM-dd");
            dtpEntrada.Value = gesReserva.Reserva.FechaEntrada;
            dtpSalida.Value = gesReserva.Reserva.FechaSalida;

            lblSistema.Text = gesReserva.Error;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Seguro que desea eliminar esta entrada?", "Eliminar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                    gesReserva.Eliminar();
            }

            if (lblSistema.Text == "")
                lblSistema.Text = gesReserva.Error;

            gesReserva.BuscarTodasReservas();
            MostrarListado();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
                gesReserva.Editar();
            if (lblSistema.Text == "")
                lblSistema.Text = gesReserva.Error;

            gesReserva.BuscarTodasReservas();
            MostrarListado();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            MostrarListado(txtFiltro.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPresentacion();
        }

        private void lsvReservas_Click(object sender, EventArgs e)
        {
            try
            {
                gesReserva.Reserva = gesReserva.Reservas[lsvReservas.FocusedItem.Index];
                gesReserva.MapearGestores();
                MapearPresentacion();
            }
            catch
            {
                //Por si cambia el listado antes de la operación (Aunque debería estar controlado)
                lblSistema.Text = "Algo ha salido mal. Trata de repetir la operación tras reiniciar el listado.";
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MostrarListado(txtFiltro.Text);
        }
    }
}
