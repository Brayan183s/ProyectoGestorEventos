namespace GestorDeEventosCulturales
{
    partial class FrmEventosProximos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.txtCostoMin = new System.Windows.Forms.TextBox();
            this.txtCostoMax = new System.Windows.Forms.TextBox();
            this.txtFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eventos Proximos";
            // 
            // dgvEventos
            // 
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(57, 195);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.RowTemplate.Height = 28;
            this.dgvEventos.Size = new System.Drawing.Size(950, 257);
            this.dgvEventos.TabIndex = 1;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(472, 525);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(188, 70);
            this.btnVerDetalle.TabIndex = 3;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(472, 626);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 70);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(1111, 119);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 26);
            this.dtpDesde.TabIndex = 5;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(1111, 170);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 26);
            this.dtpHasta.TabIndex = 6;
            // 
            // txtCostoMin
            // 
            this.txtCostoMin.Location = new System.Drawing.Point(1144, 242);
            this.txtCostoMin.Name = "txtCostoMin";
            this.txtCostoMin.Size = new System.Drawing.Size(116, 26);
            this.txtCostoMin.TabIndex = 7;
            // 
            // txtCostoMax
            // 
            this.txtCostoMax.Location = new System.Drawing.Point(1144, 304);
            this.txtCostoMax.Name = "txtCostoMax";
            this.txtCostoMax.Size = new System.Drawing.Size(116, 26);
            this.txtCostoMax.TabIndex = 8;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(1111, 382);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(188, 70);
            this.txtFiltrar.TabIndex = 9;
            this.txtFiltrar.Text = "Filtrar";
            this.txtFiltrar.UseVisualStyleBackColor = true;
            this.txtFiltrar.Click += new System.EventHandler(this.txtFiltrar_Click);
            // 
            // FrmEventosProximos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 759);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.txtCostoMax);
            this.Controls.Add(this.txtCostoMin);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.dgvEventos);
            this.Controls.Add(this.label1);
            this.Name = "FrmEventosProximos";
            this.Text = "Eventos Proximos";
            this.Load += new System.EventHandler(this.FrmEventosProximos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.TextBox txtCostoMin;
        private System.Windows.Forms.TextBox txtCostoMax;
        private System.Windows.Forms.Button txtFiltrar;
    }
}