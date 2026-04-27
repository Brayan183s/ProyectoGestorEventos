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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEventosProximos_Load(object sender, EventArgs e)
        {
            CargarEvento();             
            dgvInteres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvInteres.CurrentRow != null)
            {
                EventoCalendario fila = (EventoCalendario)dgvInteres.CurrentRow.DataBoundItem;

                FrmDetalleEvento f = new FrmDetalleEvento(fila.Id, usuarioActual);
                f.ShowDialog();
            }
        }
        private void CargarEvento()
        {
            EventoDAO dao = new EventoDAO();

            var eventos = dao.ObtenerEventosInteres(usuarioActual.Id);

            var lista = eventos
                .OrderBy(e => e.Fecha)
                .Select(e => new EventoCalendario
                {
                    Id = e.Id,
                    Fecha = e.Fecha.ToShortDateString(),
                    Evento = e.Nombre + " - " + e.Lugar
                })
                .ToList();

            dgvInteres.DataSource = lista;

            dgvInteres.Columns["Id"].Visible = false;
        }


    }
}
