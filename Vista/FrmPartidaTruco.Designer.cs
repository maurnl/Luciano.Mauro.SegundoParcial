namespace Vista
{
    partial class FrmPartidaTruco
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
            this.lblJugadorA = new System.Windows.Forms.Label();
            this.lblJugadorB = new System.Windows.Forms.Label();
            this.panelManoJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGanador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panelManoJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJuegoJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJuegoJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelarPartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblJugadorA
            // 
            this.lblJugadorA.AutoSize = true;
            this.lblJugadorA.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugadorA.Location = new System.Drawing.Point(498, 752);
            this.lblJugadorA.Name = "lblJugadorA";
            this.lblJugadorA.Size = new System.Drawing.Size(83, 36);
            this.lblJugadorA.TabIndex = 0;
            this.lblJugadorA.Text = "label1";
            // 
            // lblJugadorB
            // 
            this.lblJugadorB.AutoSize = true;
            this.lblJugadorB.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugadorB.Location = new System.Drawing.Point(498, 9);
            this.lblJugadorB.Name = "lblJugadorB";
            this.lblJugadorB.Size = new System.Drawing.Size(83, 36);
            this.lblJugadorB.TabIndex = 1;
            this.lblJugadorB.Text = "label1";
            // 
            // panelManoJ1
            // 
            this.panelManoJ1.BackColor = System.Drawing.Color.SandyBrown;
            this.panelManoJ1.Location = new System.Drawing.Point(202, 608);
            this.panelManoJ1.Name = "panelManoJ1";
            this.panelManoJ1.Size = new System.Drawing.Size(290, 180);
            this.panelManoJ1.TabIndex = 3;
            // 
            // lblGanador
            // 
            this.lblGanador.AutoSize = true;
            this.lblGanador.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGanador.Location = new System.Drawing.Point(809, 85);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Size = new System.Drawing.Size(83, 36);
            this.lblGanador.TabIndex = 4;
            this.lblGanador.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(631, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = " ";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(704, 132);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(405, 510);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // panelManoJ2
            // 
            this.panelManoJ2.BackColor = System.Drawing.Color.SandyBrown;
            this.panelManoJ2.Location = new System.Drawing.Point(202, 12);
            this.panelManoJ2.Name = "panelManoJ2";
            this.panelManoJ2.Size = new System.Drawing.Size(290, 186);
            this.panelManoJ2.TabIndex = 4;
            // 
            // panelJuegoJ1
            // 
            this.panelJuegoJ1.BackColor = System.Drawing.Color.SandyBrown;
            this.panelJuegoJ1.Location = new System.Drawing.Point(202, 414);
            this.panelJuegoJ1.Name = "panelJuegoJ1";
            this.panelJuegoJ1.Size = new System.Drawing.Size(290, 180);
            this.panelJuegoJ1.TabIndex = 7;
            // 
            // panelJuegoJ2
            // 
            this.panelJuegoJ2.BackColor = System.Drawing.Color.SandyBrown;
            this.panelJuegoJ2.Location = new System.Drawing.Point(202, 219);
            this.panelJuegoJ2.Name = "panelJuegoJ2";
            this.panelJuegoJ2.Size = new System.Drawing.Size(290, 180);
            this.panelJuegoJ2.TabIndex = 8;
            // 
            // btnCancelarPartida
            // 
            this.btnCancelarPartida.Location = new System.Drawing.Point(704, 730);
            this.btnCancelarPartida.Name = "btnCancelarPartida";
            this.btnCancelarPartida.Size = new System.Drawing.Size(150, 58);
            this.btnCancelarPartida.TabIndex = 9;
            this.btnCancelarPartida.Text = "Cancelar partida";
            this.btnCancelarPartida.UseVisualStyleBackColor = true;
            this.btnCancelarPartida.Click += new System.EventHandler(this.btnCancelarPartida_Click);
            // 
            // FrmPartidaTruco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 800);
            this.Controls.Add(this.btnCancelarPartida);
            this.Controls.Add(this.panelJuegoJ2);
            this.Controls.Add(this.panelJuegoJ1);
            this.Controls.Add(this.panelManoJ2);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.panelManoJ1);
            this.Controls.Add(this.lblJugadorB);
            this.Controls.Add(this.lblJugadorA);
            this.Name = "FrmPartidaTruco";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTruco_FormClosing);
            this.Load += new System.EventHandler(this.FrmTruco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJugadorA;
        private System.Windows.Forms.Label lblJugadorB;
        private System.Windows.Forms.FlowLayoutPanel panelManoJ1;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.FlowLayoutPanel panelManoJ2;
        private System.Windows.Forms.FlowLayoutPanel panelJuegoJ1;
        private System.Windows.Forms.FlowLayoutPanel panelJuegoJ2;
        private System.Windows.Forms.Button btnCancelarPartida;
    }
}