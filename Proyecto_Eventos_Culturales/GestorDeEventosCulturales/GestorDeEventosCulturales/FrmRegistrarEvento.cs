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
        private int? idEvento = null;
        public FrmRegistrarEvento(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            idEvento = id;
            CargarDatos();
        }
        public FrmRegistrarEvento()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CargarDatos()
        {
            EventoDAO dao = new EventoDAO();
            Evento e = dao.ObtenerPorId(idEvento.Value);

            txtNombre.Text = e.Nombre;
            txtDescripcion.Text = e.Descripcion;
            dtpFecha.Value = e.Fecha;
            txtLugar.Text = e.Lugar;
            txtOrganizador.Text = e.Organizador;
            cmbTipo.Text = e.Tipo;
            txtCupo.Text = e.Cupo.ToString();
            txtCosto.Text = e.Costo.ToString();
        }

        private void Txt_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCosto.Text))
                {
                    MessageBox.Show("Completa los campos obligatorios");
                    return;
                }

                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un tipo de evento");
                    return;
                }

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

                
                if (idEvento == null)
                {
                    
                    if (dao.Insertar(e1))
                        MessageBox.Show("Evento registrado correctamente");
                }
                else
                {
                    
                    e1.Id = idEvento.Value;

                    if (dao.Actualizar(e1))
                        MessageBox.Show("Evento actualizado correctamente");
                }

                this.Close();
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
