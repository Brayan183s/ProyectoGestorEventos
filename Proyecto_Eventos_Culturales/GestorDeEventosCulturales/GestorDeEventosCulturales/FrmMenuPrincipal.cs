using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestorDeEventosCulturales
{
    public partial class FrmMenuPrincipal : Form
    {
        private Usuario usuarioActual;

        public FrmMenuPrincipal(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show("Error: usuario no cargado");
                this.Close();
                return;
            }

            lblBienvenida.Text = "Acceso: " + usuarioActual.Nombre;

            bool esAdmin = usuarioActual.TipoUsuario == "administrador";

            btn_registrarEvento.Visible = esAdmin;
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();

                Application.Restart(); // correcto
            }
        }

        private void btn_registrarEvento_Click(object sender, EventArgs e)
        {
            if (usuarioActual.TipoUsuario != "administrador")
            {
                MessageBox.Show("No tienes permisos");
                return;
            }

            // abrir formulario registrar evento
            FrmRegistrarEvento f = new FrmRegistrarEvento();
            f.ShowDialog();
        }

        private void btn_consultarEventos_Click(object sender, EventArgs e)
        {
            FrmConsultarEvento f = new FrmConsultarEvento(usuarioActual);
            f.ShowDialog();
        }

  
    }
}
