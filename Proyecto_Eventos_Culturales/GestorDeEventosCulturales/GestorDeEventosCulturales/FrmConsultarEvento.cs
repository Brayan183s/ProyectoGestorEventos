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
    public partial class FrmConsultarEvento : Form
    {
        public FrmConsultarEvento()
        {
            InitializeComponent();
        }

        private void FrmConsultarEvento_Load(object sender, EventArgs e)
        {
            CargarEventos();
            dgvEventos.Columns["Id"].Visible = false;
            dgvEventos.Columns["Descripcion"].Visible = false;
            dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarEventos()
        {
            EventoDAO dao = new EventoDAO();
            dgvEventos.DataSource = dao.ObtenerEventos();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvEventos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvEventos.CurrentRow.Cells["Id"].Value);

                FrmDetalleEvento f = new FrmDetalleEvento(id);
                f.Show();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
