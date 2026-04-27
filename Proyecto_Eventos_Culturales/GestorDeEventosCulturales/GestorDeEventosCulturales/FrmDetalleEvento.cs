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
    public partial class FrmDetalleEvento : Form
    {
        private int idEvento;
        private Usuario usuarioActual;

        public FrmDetalleEvento(int id, Usuario u)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            idEvento = id;
            usuarioActual = u;
        }

        private void FrmDetalleEvento_Load(object sender, EventArgs e)
        {
            CargarDetalle();
        }

        private void CargarDetalle()
        {
            EventoDAO dao = new EventoDAO();
            Evento e = dao.ObtenerPorId(idEvento);

            if (e != null)
            {
                lblNombre.Text = e.Nombre;
                lblFecha.Text = e.Fecha.ToShortDateString();
                lblHora.Text = e.Hora.ToString(@"hh\:mm");
                lblLugar.Text = e.Lugar;
                lblCosto.Text = "$ " + e.Costo.ToString();
                lblCupo.Text = e.Cupo.ToString();
                lblDescripcion.Text = e.Descripcion;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarcarInteres_Click(object sender, EventArgs e)
        {
            try
            {
                EventoDAO dao = new EventoDAO();

                dao.MarcarInteres(usuarioActual.Id, idEvento);

                MessageBox.Show("Evento marcado como interés ⭐");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
