namespace Vista
{
    partial class FrmPartidaPiedraPapelTijera
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
            this.panelJugadorB = new System.Windows.Forms.FlowLayoutPanel();
            this.panelJugadorA = new System.Windows.Forms.FlowLayoutPanel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panelJugadorB
            // 
            this.panelJugadorB.Location = new System.Drawing.Point(295, 40);
            this.panelJugadorB.Name = "panelJugadorB";
            this.panelJugadorB.Size = new System.Drawing.Size(165, 230);
            this.panelJugadorB.TabIndex = 0;
            // 
            // panelJugadorA
            // 
            this.panelJugadorA.Location = new System.Drawing.Point(295, 309);
            this.panelJugadorA.Name = "panelJugadorA";
            this.panelJugadorA.Size = new System.Drawing.Size(165, 230);
            this.panelJugadorA.TabIndex = 1;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(521, 82);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(258, 396);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // FrmPartidaJanKenPon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.panelJugadorA);
            this.Controls.Add(this.panelJugadorB);
            this.Name = "FrmPartidaJanKenPon";
            this.Text = "FrmPartidaJanKenPon";
            this.Load += new System.EventHandler(this.FrmPartidaJanKenPon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelJugadorB;
        private System.Windows.Forms.FlowLayoutPanel panelJugadorA;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}