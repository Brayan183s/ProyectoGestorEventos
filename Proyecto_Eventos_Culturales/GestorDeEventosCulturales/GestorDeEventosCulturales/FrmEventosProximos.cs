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
            CargarEventos();
        
        }

        private void CargarEventos()
        {
            EventoDAO dao = new EventoDAO();
            dgvEventos.DataSource = dao.ObtenerEventos();

            // 🔥 AHORA sí existen columnas
            
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

            double costo;

            // validar costo
            if (!double.TryParse(txtCostoMax.Text, out costo))
            {
                MessageBox.Show("Ingresa un costo válido");
                return;
            }

            // validar fechas
            if (desde > hasta)
            {
                MessageBox.Show("Fecha incorrecta");
                return;
            }

            dgvEventos.DataSource = null;
            dgvEventos.DataSource = dao.FiltrarSimple(desde, hasta, costo);
        }

        private void LimpiarCampos()
        {
            // 🔹 Limpiar campos de costo
            txtCostoMin.Text = "";
            txtCostoMax.Text = "";

            // 🔹 Resetear fechas
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            // 🔹 Recargar todos los eventos
            CargarEventos();
        }



    }
}
