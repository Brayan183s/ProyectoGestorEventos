using System;
using System.Windows.Forms;

namespace GestorDeEventosCulturales
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                GestorAutenticacion gestor = new GestorAutenticacion();

                Usuario usuario = gestor.Login(txtUsuario.Text, txtPassword.Text);

                if (usuario != null)
                {
                    MessageBox.Show("Bienvenido " + usuario.Nombre);

                    FrmMenuPrincipal f = new FrmMenuPrincipal(usuario);

                    // CUANDO SE CIERRE EL MENÚ → REGRESAR AL LOGIN
                    f.FormClosed += (s, args) => this.Show();

                    f.Show();

                    this.Hide(); // ocultar login
                }
                else
                {
                    MessageBox.Show("Datos incorrectos", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "¿Desea salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                Application.Exit(); // Cierra TODA la aplicación correctamente
            }
        }
    }
}
