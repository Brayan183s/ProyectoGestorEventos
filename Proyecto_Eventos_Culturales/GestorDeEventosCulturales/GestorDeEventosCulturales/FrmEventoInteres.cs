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
    public partial class FrmEventoInteres : Form
    {
        private Usuario usuarioActual;
        public FrmEventoInteres(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;

        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEventosProximos_Load(object sender, EventArgs e)
        {
            CargarEvento();
            dgvInteres.Columns["Id"].Visible = false;
            dgvInteres.Columns["Descripcion"].Visible = false;
            dgvInteres.Columns["Organizador"].Visible = false;
            dgvInteres.Columns["Tipo"].Visible = false;
            dgvInteres.Columns["Cupo"].Visible = false;
            dgvInteres.Columns["Hora"].Visible = false;
            dgvInteres.Columns["Costo"].Visible = false;
            dgvInteres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarEvento()
        {
            EventoDAO dao = new EventoDAO();
            dgvInteres.DataSource = dao.ObtenerEventosInteres(usuarioActual.Id);
        }
    }
}
