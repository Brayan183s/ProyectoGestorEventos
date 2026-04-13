using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            GestorAutenticacion gestor = new GestorAutenticacion();

            bool acceso = gestor.Login(txtUsuario.Text, txtPassword.Text);

            if (acceso)
            {
                MessageBox.Show("Bienvenido");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
