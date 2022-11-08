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
            this.lblTurnosRestantes = new System.Windows.Forms.Label();
            this.panelManoJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGanador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panelManoJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJuegoJ1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJuegoJ2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblJugadorA
            // 
            this.lblJugadorA.AutoSize = true;
            this.lblJugadorA.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugadorA.Location = new System.Drawing.Point(432, 685);
            this.lblJugadorA.Name = "lblJugadorA";
            this.lblJugadorA.Size = new System.Drawing.Size(83, 36);
            this.lblJugadorA.TabIndex = 0;
            this.lblJugadorA.Text = "label1";
            // 
            // lblJugadorB
            // 
            this.lblJugadorB.AutoSize = true;
            this.lblJugadorB.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJugadorB.Location = new System.Drawing.Point(432, 88);
            this.lblJugadorB.Name = "lblJugadorB";
            this.lblJugadorB.Size = new System.Drawing.Size(83, 36);
            this.lblJugadorB.TabIndex = 1;
            this.lblJugadorB.Text = "label1";
            // 
            // lblTurnosRestantes
            // 
            this.lblTurnosRestantes.AutoSize = true;
            this.lblTurnosRestantes.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTurnosRestantes.Location = new System.Drawing.Point(656, 137);
            this.lblTurnosRestantes.Name = "lblTurnosRestantes";
            this.lblTurnosRestantes.Size = new System.Drawing.Size(83, 36);
            this.lblTurnosRestantes.TabIndex = 2;
            this.lblTurnosRestantes.Text = "label1";
            // 
            // panelManoJ1
            // 
            this.panelManoJ1.Location = new System.Drawing.Point(24, 611);
            this.panelManoJ1.Name = "panelManoJ1";
            this.panelManoJ1.Size = new System.Drawing.Size(350, 180);
            this.panelManoJ1.TabIndex = 3;
            // 
            // lblGanador
            // 
            this.lblGanador.AutoSize = true;
            this.lblGanador.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGanador.Location = new System.Drawing.Point(568, 12);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Size = new System.Drawing.Size(83, 36);
            this.lblGanador.TabIndex = 4;
            this.lblGanador.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(568, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(728, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(457, 575);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // panelManoJ2
            // 
            this.panelManoJ2.Location = new System.Drawing.Point(24, 12);
            this.panelManoJ2.Name = "panelManoJ2";
            this.panelManoJ2.Size = new System.Drawing.Size(350, 186);
            this.panelManoJ2.TabIndex = 4;
            // 
            // panelJuegoJ1
            // 
            this.panelJuegoJ1.Location = new System.Drawing.Point(24, 414);
            this.panelJuegoJ1.Name = "panelJuegoJ1";
            this.panelJuegoJ1.Size = new System.Drawing.Size(350, 180);
            this.panelJuegoJ1.TabIndex = 7;
            // 
            // panelJuegoJ2
            // 
            this.panelJuegoJ2.Location = new System.Drawing.Point(24, 213);
            this.panelJuegoJ2.Name = "panelJuegoJ2";
            this.panelJuegoJ2.Size = new System.Drawing.Size(350, 180);
            this.panelJuegoJ2.TabIndex = 8;
            // 
            // FrmTruco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 800);
            this.Controls.Add(this.panelJuegoJ2);
            this.Controls.Add(this.panelJuegoJ1);
            this.Controls.Add(this.panelManoJ2);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.panelManoJ1);
            this.Controls.Add(this.lblTurnosRestantes);
            this.Controls.Add(this.lblJugadorB);
            this.Controls.Add(this.lblJugadorA);
            this.Name = "FrmTruco";
            this.Text = "FrmTruco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTruco_FormClosing);
            this.Load += new System.EventHandler(this.FrmTruco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJugadorA;
        private System.Windows.Forms.Label lblJugadorB;
        private System.Windows.Forms.Label lblTurnosRestantes;
        private System.Windows.Forms.FlowLayoutPanel panelManoJ1;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.FlowLayoutPanel panelManoJ2;
        private System.Windows.Forms.FlowLayoutPanel panelJuegoJ1;
        private System.Windows.Forms.FlowLayoutPanel panelJuegoJ2;

    }
}