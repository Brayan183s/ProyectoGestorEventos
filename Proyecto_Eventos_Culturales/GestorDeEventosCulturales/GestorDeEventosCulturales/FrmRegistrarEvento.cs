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
    public partial class FrmRegistrarEvento : Form
    {
        public FrmRegistrarEvento()
        {
            InitializeComponent();
        }

        private void Txt_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Evento e1 = new Evento()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Fecha = dtpFecha.Value,
                    Hora = dtpHora.Value.TimeOfDay,
                    Lugar = txtLugar.Text,
                    Organizador = txtOrganizador.Text,
                    Tipo = cmbTipo.SelectedItem.ToString(),
                    Cupo = Convert.ToInt32(txtCupo.Text),
                    Costo = Convert.ToDouble(txtCosto.Text)
                };

                EventoDAO dao = new EventoDAO();

                if (dao.Insertar(e1))
                {
                    MessageBox.Show("Evento guardado correctamente");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
                if (txtNombre.Text == "" || txtCosto.Text == "")
                {
                    MessageBox.Show("Completa los campos obligatorios");
                    return;
                }
                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un tipo de evento");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtLugar.Clear();
            txtOrganizador.Clear();
            txtOrganizador.Clear();
            dtpFecha.Value = DateTime.Now;
        }

        private void FrmRegistrarEvento_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("Cultural");
            cmbTipo.Items.Add("Deportivo");
            cmbTipo.Items.Add("Académico");
            cmbTipo.Items.Add("Artístico");
            cmbTipo.Items.Add("Social");

            cmbTipo.SelectedIndex = 0; 
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
