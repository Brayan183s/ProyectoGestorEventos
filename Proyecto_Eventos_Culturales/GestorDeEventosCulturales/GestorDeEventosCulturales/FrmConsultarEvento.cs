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
        private Usuario usuarioActual;

        public FrmConsultarEvento(Usuario u)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            usuarioActual = u;
        }

        private void FrmConsultarEvento_Load(object sender, EventArgs e)
        {
            if (usuarioActual.TipoUsuario != "administrador") 
            {
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioActual.TipoUsuario != "administrador")
            {
                MessageBox.Show("No tienes permisos");
                return;
            }

            if (dgvEventos.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgvEventos.CurrentRow.Cells["Id"].Value);

            FrmRegistrarEvento f = new FrmRegistrarEvento(id);
            f.ShowDialog();

            CargarEventos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (usuarioActual.TipoUsuario != "administrador")
            {
                MessageBox.Show("No tienes permisos");
                return;
            }

            if (dgvEventos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un evento");
                return;
            }

            int id = Convert.ToInt32(dgvEventos.CurrentRow.Cells["Id"].Value);

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar este evento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (r == DialogResult.Yes)
            {
                EventoDAO dao = new EventoDAO();

                if (dao.Eliminar(id))
                {
                    MessageBox.Show("Evento eliminado correctamente");
                    CargarEventos(); // 🔄 refresca el grid
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }
    }
}
