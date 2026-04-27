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
            LimpiarCampos();
        
        }

        private void CargarEventos()
        {
            EventoDAO dao = new EventoDAO();
            dgvEventos.DataSource = dao.ObtenerEventos();
       
            
            dgvEventos.Columns["Id"].Visible = false;
            dgvEventos.Columns["Descripcion"].Visible = false;
            dgvEventos.Columns["Organizador"].Visible = false;
            dgvEventos.Columns["Tipo"].Visible = false;
            dgvEventos.Columns["Cupo"].Visible = false;
            dgvEventos.Columns["Hora"].Visible = false;
             

            dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvEventos.CurrentRow != null)
            {
                Evento evento = (Evento)dgvEventos.CurrentRow.DataBoundItem;

                FrmDetalleEvento f = new FrmDetalleEvento(evento.Id, usuarioActual);
                f.ShowDialog();
            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }

        private void txtFiltrar_Click(object sender, EventArgs e)
        {
            EventoDAO dao = new EventoDAO();

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            double costoMin, costoMax;

     
            if (desde > hasta)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCostoMin.Text) ||
                string.IsNullOrWhiteSpace(txtCostoMax.Text))
            {
                MessageBox.Show("Ingresa ambos costos");
                return;
            }

        
            if (!double.TryParse(txtCostoMin.Text, out costoMin))
            {
                MessageBox.Show("Costo mínimo inválido");
                return;
            }

            if (!double.TryParse(txtCostoMax.Text, out costoMax))
            {
                MessageBox.Show("Costo máximo inválido");
                return;
            }

         
            if (costoMin > costoMax)
            {
                MessageBox.Show("Costo mínimo no puede ser mayor");
                return;
            }

     
            dgvEventos.DataSource = null;
            dgvEventos.DataSource = dao.FiltrarEventos(desde, hasta, costoMin, costoMax);
        }

        private void LimpiarCampos()
        {
            txtCostoMin.Text = "";
            txtCostoMax.Text = "";

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            EventoDAO dao = new EventoDAO();
            dgvEventos.DataSource = dao.ObtenerEventos();
        }



    }
}
