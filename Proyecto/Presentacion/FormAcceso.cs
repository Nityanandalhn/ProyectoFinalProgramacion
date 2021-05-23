using Negocio.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormAcceso : Form
    {
        public FormAcceso()
        {
            InitializeComponent();

            if (Login.NoHayEmpleadosConAcceso())
            {
                Login.CrearAdminAdmin();
                lblPrimeraVez.Text = "Admin : admin";
            }
            else
            {
                txtId.Text = Login.CargarId();
                this.ActiveControl = txtPwd;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            if (Login.IniciarSesion(txtId.Text, txtPwd.Text))
            {
                Application.Exit();

                Thread iniciar = new Thread(() => Application.Run(new FormInicial()))
                {
                    IsBackground = false
                };

                iniciar.Start();

                Login.GuardarId(txtId.Text);
            }
            else
            {
                lblSistema.Text = "Datos de acceso incorrectos.";
            }

            if (Login.Error != "")
                lblSistema.Text = Login.Error;
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                IniciarSesion();
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                IniciarSesion();
        }
    }
}
