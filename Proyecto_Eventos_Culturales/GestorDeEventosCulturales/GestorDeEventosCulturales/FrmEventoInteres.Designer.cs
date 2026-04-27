namespace GestorDeEventosCulturales
{
    partial class FrmEventoInteres
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
            this.dgvInteres = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInteres)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInteres
            // 
            this.dgvInteres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInteres.Location = new System.Drawing.Point(59, 137);
            this.dgvInteres.Name = "dgvInteres";
            this.dgvInteres.RowTemplate.Height = 28;
            this.dgvInteres.Size = new System.Drawing.Size(758, 385);
            this.dgvInteres.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mis eventos";
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(339, 544);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(188, 70);
            this.btnVerDetalle.TabIndex = 3;
            this.btnVerDetalle.Text = "Ver detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(339, 620);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 70);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmEventoInteres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(874, 714);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInteres);
            this.Name = "FrmEventoInteres";
            this.Text = "Calendario";
            this.Load += new System.EventHandler(this.FrmEventosProximos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInteres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInteres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnCancelar;
    }
}