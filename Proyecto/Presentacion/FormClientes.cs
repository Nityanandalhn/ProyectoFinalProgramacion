using Negocio;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormClientes : Form
    {
        private GesCliente gesClientes;
        public FormClientes()
        {
            InitializeComponent();

            gesClientes = new GesCliente();

            lblSistema.Text = gesClientes.Error;

            MostrarListado();
        }

        private void LimpiarPresentacion()
        {
            gesClientes.BuscarTodos();

            txtApellidos.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtPais.Text = "";
            txtDireccion.Text = "";
            txtTlf.Text = "";
            lblSistema.Text = gesClientes.Error;

            MostrarListado();
        }

        private void MostrarListado()
        {
            lsvClientes.Clear();

            lsvClientes.Columns.Add("Dni", 100);
            lsvClientes.Columns.Add("Nombre", 100);
            lsvClientes.Columns.Add("Apellidos", 100);
            lsvClientes.Columns.Add("Email", 100);
            lsvClientes.Columns.Add("Teléfono", 100);
            lsvClientes.Columns.Add("País", 100);
            lsvClientes.Columns.Add("Dirección", 100);

            lsvClientes.AllowColumnReorder = true;

            gesClientes.Clientes.ForEach(c => lsvClientes.Items.Add(new ListViewItem(
                new string[]
                {
                    c.Dni,
                    c.Nombre,
                    c.Apellidos,
                    c.Email,
                    c.Telefono,
                    c.Pais,
                    c.Direccion
                })));
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";
            if (txtDni.Text != "")
            {
                gesClientes.Cliente = new Cliente()
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Dni = txtDni.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text,
                    Pais = txtPais.Text,
                    Telefono = txtTlf.Text
                };
            }
            else
            {
                lblSistema.Text = "Falta DNI";
                return false;
            }
            return true;
        }

        private void MapearPresentacion()
        {
            txtPais.Text = gesClientes.Cliente.Pais;
            txtTlf.Text = gesClientes.Cliente.Telefono.ToString();
            txtNombre.Text = gesClientes.Cliente.Nombre;
            txtEmail.Text = gesClientes.Cliente.Email;
            txtDni.Text = gesClientes.Cliente.Dni;
            txtDireccion.Text = gesClientes.Cliente.Direccion;
            txtApellidos.Text = gesClientes.Cliente.Apellidos;
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarPresentacion();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            gesClientes.BuscarClientes(
                txtNombre.Text,
                txtApellidos.Text,
                txtEmail.Text,
                txtTlf.Text,
                txtDni.Text,
                txtPais.Text,
                txtDireccion.Text
            );
            MostrarListado();

            lblSistema.Text = gesClientes.Error;
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (MapearNegocio())
                gesClientes.Editar();
            if (lblSistema.Text == "")
                lblSistema.Text = gesClientes.Error;

            gesClientes.BuscarTodos();
            MostrarListado();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (MapearNegocio())
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que desea eliminar esta entrada?", "Eliminar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                    gesClientes.Eliminar();
            }
            if (lblSistema.Text == "")
                lblSistema.Text = gesClientes.Error;

            gesClientes.BuscarTodos();
            MostrarListado();
        }

        private void lsvClientes_Click(object sender, System.EventArgs e)
        {
            try
            {
                gesClientes.Cliente = gesClientes.Clientes[lsvClientes.FocusedItem.Index];
                MapearPresentacion();
            }
            catch
            {
                //Por si cambia el listado antes de la operación (Aunque debería estar controlado)
                lblSistema.Text = "Algo ha salido mal. Trata de repetir la operación tras reiniciar el listado.";
            }
        }
    }
}
