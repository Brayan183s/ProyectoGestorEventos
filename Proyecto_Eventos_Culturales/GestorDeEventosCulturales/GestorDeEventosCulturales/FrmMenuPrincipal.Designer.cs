namespace GestorDeEventosCulturales
{
    partial class FrmMenuPrincipal
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
            this.btn_registrarEvento = new System.Windows.Forms.Button();
            this.btn_consultarEventos = new System.Windows.Forms.Button();
            this.btn_eventosProximos = new System.Windows.Forms.Button();
            this.btn_calendario = new System.Windows.Forms.Button();
            this.btn_cerrarSesion = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Hola, Bienvenido!";
            // 
            // btn_registrarEvento
            // 
            this.btn_registrarEvento.Location = new System.Drawing.Point(437, 213);
            this.btn_registrarEvento.Name = "btn_registrarEvento";
            this.btn_registrarEvento.Size = new System.Drawing.Size(273, 69);
            this.btn_registrarEvento.TabIndex = 1;
            this.btn_registrarEvento.Text = "Registrar Evento";
            this.btn_registrarEvento.UseVisualStyleBackColor = true;
            this.btn_registrarEvento.Click += new System.EventHandler(this.btn_registrarEvento_Click);
            // 
            // btn_consultarEventos
            // 
            this.btn_consultarEventos.Location = new System.Drawing.Point(437, 298);
            this.btn_consultarEventos.Name = "btn_consultarEventos";
            this.btn_consultarEventos.Size = new System.Drawing.Size(273, 69);
            this.btn_consultarEventos.TabIndex = 2;
            this.btn_consultarEventos.Text = "Consultar Eventos";
            this.btn_consultarEventos.UseVisualStyleBackColor = true;
            this.btn_consultarEventos.Click += new System.EventHandler(this.btn_consultarEventos_Click);
            // 
            // btn_eventosProximos
            // 
            this.btn_eventosProximos.Location = new System.Drawing.Point(437, 387);
            this.btn_eventosProximos.Name = "btn_eventosProximos";
            this.btn_eventosProximos.Size = new System.Drawing.Size(273, 69);
            this.btn_eventosProximos.TabIndex = 3;
            this.btn_eventosProximos.Text = "Eventos Proximos";
            this.btn_eventosProximos.UseVisualStyleBackColor = true;
            this.btn_eventosProximos.Click += new System.EventHandler(this.btn_eventosProximos_Click);
            // 
            // btn_calendario
            // 
            this.btn_calendario.Location = new System.Drawing.Point(437, 480);
            this.btn_calendario.Name = "btn_calendario";
            this.btn_calendario.Size = new System.Drawing.Size(273, 69);
            this.btn_calendario.TabIndex = 4;
            this.btn_calendario.Text = "Calendario";
            this.btn_calendario.UseVisualStyleBackColor = true;
            // 
            // btn_cerrarSesion
            // 
            this.btn_cerrarSesion.Location = new System.Drawing.Point(388, 606);
            this.btn_cerrarSesion.Name = "btn_cerrarSesion";
            this.btn_cerrarSesion.Size = new System.Drawing.Size(376, 69);
            this.btn_cerrarSesion.TabIndex = 5;
            this.btn_cerrarSesion.Text = "Cerrar sesión";
            this.btn_cerrarSesion.UseVisualStyleBackColor = true;
            this.btn_cerrarSesion.Click += new System.EventHandler(this.btn_cerrarSesion_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(12, 680);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(64, 20);
            this.lblBienvenida.TabIndex = 7;
            this.lblBienvenida.Text = "Usuario";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 709);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btn_cerrarSesion);
            this.Controls.Add(this.btn_calendario);
            this.Controls.Add(this.btn_eventosProximos);
            this.Controls.Add(this.btn_consultarEventos);
            this.Controls.Add(this.btn_registrarEvento);
            this.Controls.Add(this.label1);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_registrarEvento;
        private System.Windows.Forms.Button btn_consultarEventos;
        private System.Windows.Forms.Button btn_eventosProximos;
        private System.Windows.Forms.Button btn_calendario;
        private System.Windows.Forms.Button btn_cerrarSesion;
        private System.Windows.Forms.Label lblBienvenida;
    }
}