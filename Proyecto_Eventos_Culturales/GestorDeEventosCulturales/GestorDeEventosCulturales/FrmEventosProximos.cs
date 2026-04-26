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
    public partial class FrmEventosProximos : Form
    {
        private Usuario usuarioActual;
        public FrmEventosProximos(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
        }

        private void FrmEventosProximos_Load(object sender, EventArgs e)
        {
            CargarEventos();
            dgvEventos.Columns["Id"].Visible = false;
            dgvEventos.Columns["Descripcion"].Visible = false;
            dgvEventos.Columns["Organizador"].Visible = false;
            dgvEventos.Columns["Tipo"].Visible = false;
            dgvEventos.Columns["Cupo"].Visible = false;
            dgvEventos.Columns["Hora"].Visible = false;
            dgvEventos.Columns["Costo"].Visible = false;
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

                FrmDetalleEvento f = new FrmDetalleEvento(id, usuarioActual);
                f.ShowDialog();
            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }


    }
}
