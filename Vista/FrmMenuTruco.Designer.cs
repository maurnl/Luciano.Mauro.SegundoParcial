namespace Vista
{
    partial class FrmMenuTruco
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSimulada = new System.Windows.Forms.CheckBox();
            this.lstJugadores = new System.Windows.Forms.ListBox();
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.flowPanelPartidas = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lstPartidas, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lstJugadores, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.342494F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.65751F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 473);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkSimulada);
            this.panel1.Controls.Add(this.btnCrearPartida);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 87);
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
            // lstJugadores
            // 
            this.lstJugadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstJugadores.FormattingEnabled = true;
            this.lstJugadores.ItemHeight = 15;
            this.lstJugadores.Location = new System.Drawing.Point(3, 33);
            this.lstJugadores.Name = "lstJugadores";
            this.lstJugadores.Size = new System.Drawing.Size(97, 437);
            this.lstJugadores.TabIndex = 0;
            // 
            // lstPartidas
            // 
            this.lstPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.ItemHeight = 15;
            this.lstPartidas.Location = new System.Drawing.Point(106, 33);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(98, 437);
            this.lstPartidas.TabIndex = 1;
            // 
            // flowPanelPartidas
            // 
            this.flowPanelPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelPartidas.Location = new System.Drawing.Point(216, 96);
            this.flowPanelPartidas.Name = "flowPanelPartidas";
            this.flowPanelPartidas.Size = new System.Drawing.Size(620, 473);
            this.flowPanelPartidas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jugadores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Partidas activas";
            // 
            // FrmMenuTruco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMenuTruco";
            this.Text = "VistaJuego";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSimulada;
        private System.Windows.Forms.ListBox lstJugadores;
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.FlowLayoutPanel flowPanelPartidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}