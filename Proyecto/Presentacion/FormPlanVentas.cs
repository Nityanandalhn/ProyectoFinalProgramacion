using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormPlanVentas : Form
    {
        private GesPlanVentas gesVentas;
        public FormPlanVentas()
        {
            InitializeComponent();

            gesVentas = new GesPlanVentas();

            lblSistema.Text = gesVentas.Error;

            MostrarListado();
        }

        private void LimpiarPresentacion()
        {
            gesVentas.BuscarTodosPlanes();

            txtComidas.Text = "";
            txtPrecio.Text = "";
            txtTemporada.Text = "";
            txtTipo.Text = "";
            lblSistema.Text = gesVentas.Error;

            MostrarListado();
        }

        private void MostrarListado()
        {
            lsvPlanes.Clear();

            lsvPlanes.Columns.Add("Tipo", 100);
            lsvPlanes.Columns.Add("Temporada", 100);
            lsvPlanes.Columns.Add("Comidas", 100);
            lsvPlanes.Columns.Add("Precio por noche", 150);

            lsvPlanes.AllowColumnReorder = true;

            gesVentas.Planes.ForEach(p => lsvPlanes.Items.Add(new ListViewItem(
                new string[]
                {
                    p.Tipo,
                    p.Temporada,
                    p.Comidas,
                    p.Precio.ToString()
                })));
        }

        private bool MapearNegocio()
        {
            lblSistema.Text = "";

            if (int.TryParse(txtPrecio.Text, out int precio)
                && txtTipo.Text != "")
            {
                gesVentas.PlanVentas = new PlanVentas()
                {
                    Tipo = txtTipo.Text,
                    Temporada = txtTemporada.Text,
                    Comidas = txtComidas.Text,
                    Precio = precio
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
            txtComidas.Text = gesVentas.PlanVentas.Comidas;
            txtPrecio.Text = gesVentas.PlanVentas.Precio.ToString();
            txtTemporada.Text = gesVentas.PlanVentas.Temporada;
            txtTipo.Text = gesVentas.PlanVentas.Tipo;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gesVentas.BuscarPlanes(
                txtTipo.Text,
                txtComidas.Text,
                txtPrecio.Text,
                txtTemporada.Text
            );
            MostrarListado();

            lblSistema.Text = gesVentas.Error;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPresentacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
                gesVentas.Editar();
            if (lblSistema.Text == "")
                lblSistema.Text = gesVentas.Error;

            gesVentas.BuscarTodosPlanes();
            MostrarListado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MapearNegocio())
            {
                DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que desea eliminar esta entrada?", "Eliminar", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                    gesVentas.Eliminar();
            }
            if (lblSistema.Text == "")
                lblSistema.Text = gesVentas.Error;

            gesVentas.BuscarTodosPlanes();
            MostrarListado();
        }

        private void lsvPlanes_Click(object sender, EventArgs e)
        {
            try
            {
                gesVentas.PlanVentas = gesVentas.Planes[lsvPlanes.FocusedItem.Index];
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
