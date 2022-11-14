namespace Vista
{
    partial class FrmMenuJuegoBase
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
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHistorialPartidas = new System.Windows.Forms.Button();
            this.btnGuardarPartidas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSimulada = new System.Windows.Forms.CheckBox();
            this.flowPanelPartidas = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.Location = new System.Drawing.Point(3, 3);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(84, 81);
            this.btnCrearPartida.TabIndex = 0;
            this.btnCrearPartida.Text = "Crear nueva partida";
            this.btnCrearPartida.UseVisualStyleBackColor = true;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.38737F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61263F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowPanelPartidas, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.25874F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.74126F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(839, 572);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnHistorialPartidas, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGuardarPartidas, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.70422F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.29578F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 474);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnHistorialPartidas
            // 
            this.btnHistorialPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistorialPartidas.Location = new System.Drawing.Point(3, 3);
            this.btnHistorialPartidas.Name = "btnHistorialPartidas";
            this.btnHistorialPartidas.Size = new System.Drawing.Size(201, 66);
            this.btnHistorialPartidas.TabIndex = 0;
            this.btnHistorialPartidas.Text = "Historial Partidas";
            this.btnHistorialPartidas.UseVisualStyleBackColor = true;
            this.btnHistorialPartidas.Click += new System.EventHandler(this.btnHistorialPartidas_Click);
            // 
            // btnGuardarPartidas
            // 
            this.btnGuardarPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarPartidas.Location = new System.Drawing.Point(3, 75);
            this.btnGuardarPartidas.Name = "btnGuardarPartidas";
            this.btnGuardarPartidas.Size = new System.Drawing.Size(201, 64);
            this.btnGuardarPartidas.TabIndex = 1;
            this.btnGuardarPartidas.Text = "Administrar jugadores";
            this.btnGuardarPartidas.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkSimulada);
            this.panel1.Controls.Add(this.btnCrearPartida);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 86);
            this.panel1.TabIndex = 2;
            // 
            // chkSimulada
            // 
            this.chkSimulada.AutoSize = true;
            this.chkSimulada.Location = new System.Drawing.Point(93, 35);
            this.chkSimulada.Name = "chkSimulada";
            this.chkSimulada.Size = new System.Drawing.Size(111, 19);
            this.chkSimulada.TabIndex = 1;
            this.chkSimulada.Text = "Simular partida?";
            this.chkSimulada.UseVisualStyleBackColor = true;
            // 
            // flowPanelPartidas
            // 
            this.flowPanelPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelPartidas.Location = new System.Drawing.Point(216, 95);
            this.flowPanelPartidas.Name = "flowPanelPartidas";
            this.flowPanelPartidas.Size = new System.Drawing.Size(620, 474);
            this.flowPanelPartidas.TabIndex = 3;
            // 
            // FrmMenuJuegoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMenuJuegoBase";
            this.Text = "VistaJuego";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuJuegoBase_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnCrearPartida;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.CheckBox chkSimulada;
        protected System.Windows.Forms.FlowLayoutPanel flowPanelPartidas;
        private System.Windows.Forms.Button btnHistorialPartidas;
        private System.Windows.Forms.Button btnGuardarPartidas;
    }
}