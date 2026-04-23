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
        public FrmDetalleEvento(int id)
        {
            InitializeComponent();
            idEvento = id;
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
                lblDescripcion.Text = e.Descripcion;
                lblFecha.Text = e.Fecha.ToShortDateString();
                lblLugar.Text = e.Lugar;
                lblCosto.Text = e.Costo.ToString();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMarcarInteres_Click(object sender, EventArgs e)
        {

        }
    }
}
