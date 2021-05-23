using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormEmpleados : Form
    {
        private GesEmpleado gesEmpleados;
        public FormEmpleados()
        {
            InitializeComponent();

            gesEmpleados = new GesEmpleado();

            lblSistema.Text = gesEmpleados.Error;

            MostrarListado();
        }

        private void LimpiarPresentacion()
        {
            gesEmpleados.BuscarTodos();

            txtApellidos.Text = "";
            txtDni.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTurno.Text = "";
            txtDireccion.Text = "";
            txtTlf.Text = "";
            txtTipo.Text = "";
            txtSalario.Text = "";
            lblSistema.Text = gesEmpleados.Error;

            MostrarListado();
        }

        private void MostrarListado()
        {
            lsvEmpleados.Clear();

            lsvEmpleados.Columns.Add("Dni", 100);
            lsvEmpleados.Columns.Add("Nombre", 100);
            lsvEmpleados.Columns.Add("Apellidos", 100);
            lsvEmpleados.Columns.Add("Email", 100);
            lsvEmpleados.Columns.Add("Teléfono", 100);
            lsvEmpleados.Columns.Add("Dirección", 50);
            lsvEmpleados.Columns.Add("Turno", 50);
            lsvEmpleados.Columns.Add("Tipo", 50);
            lsvEmpleados.Columns.Add("Salario", 50);

            lsvEmpleados.AllowColumnReorder = true;

            gesEmpleados.Empleados.ForEach(e => lsvEmpleados.Items.Add(new ListViewItem(
                new string[]
                {
                    e.Dni,
                    e.Nombre,
                    e.Apellidos,
                    e.Email,
                    e.Telefono,
                    e.Direccion,
                    e.Turno,
                    e.Tipo,
                    e.Salario switch { 0 => "", _ => e.Salario.ToString() }
                })));
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";

            if (txtDni.Text != "")
            {
                gesEmpleados.Empleado = new Empleado()
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellidos.Text,
                    Dni = txtDni.Text,
                    Email = txtEmail.Text,
                    Direccion = txtDireccion.Text,
                    Tipo = txtTipo.Text,
                    Turno = txtTurno.Text,
                    Telefono = txtTlf.Text
                };

                if (float.TryParse(txtSalario.Text, out float salario))
                {
                    gesEmpleados.Empleado.Salario = salario;
                }
                else
                {
                    lblSistema.Text += " - Salario no introducido";
                }
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
            txtTipo.Text = gesEmpleados.Empleado.Tipo;
            txtTlf.Text = gesEmpleados.Empleado.Telefono.ToString();
            txtNombre.Text = gesEmpleados.Empleado.Nombre;
            txtEmail.Text = gesEmpleados.Empleado.Email;
            txtDni.Text = gesEmpleados.Empleado.Dni;
            txtDireccion.Text = gesEmpleados.Empleado.Direccion;
            txtApellidos.Text = gesEmpleados.Empleado.Apellidos;
            txtTurno.Text = gesEmpleados.Empleado.Turno;
            txtSalario.Text = gesEmpleados.Empleado.Salario.ToString();
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarPresentacion();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            gesEmpleados.BuscarEmpleados(
                txtNombre.Text,
                txtApellidos.Text,
                txtEmail.Text,
                txtTlf.Text,
                txtDni.Text,
                txtTurno.Text,
                txtDireccion.Text,
                txtTipo.Text,
                txtSalario.Text
            );
            MostrarListado();

            lblSistema.Text = gesEmpleados.Error;
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (MapearNegocio())
                gesEmpleados.Editar();
            if (lblSistema.Text == "")
                lblSistema.Text = gesEmpleados.Error;

            gesEmpleados.BuscarTodos();
            MostrarListado();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (MapearNegocio())
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que desea eliminar esta entrada?", "Eliminar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                    gesEmpleados.Eliminar();
            }
            if (lblSistema.Text == "")
                lblSistema.Text = gesEmpleados.Error;

            gesEmpleados.BuscarTodos();
            MostrarListado();
        }

        private void lsvEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                gesEmpleados.Empleado = gesEmpleados.Empleados[lsvEmpleados.FocusedItem.Index];
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
