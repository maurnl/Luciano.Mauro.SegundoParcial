namespace Vista
{
    partial class FrmJugarManoTruco
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
            this.panelCartas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTruco = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelCartas
            // 
            this.panelCartas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCartas.Location = new System.Drawing.Point(0, 0);
            this.panelCartas.Name = "panelCartas";
            this.panelCartas.Size = new System.Drawing.Size(335, 220);
            this.panelCartas.TabIndex = 0;
            // 
            // btnTruco
            // 
            this.btnTruco.Location = new System.Drawing.Point(364, 12);
            this.btnTruco.Name = "btnTruco";
            this.btnTruco.Size = new System.Drawing.Size(75, 46);
            this.btnTruco.TabIndex = 0;
            this.btnTruco.Text = "Truco!!";
            this.btnTruco.UseVisualStyleBackColor = true;
            // 
            // FrmJugarManoTruco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 220);
            this.Controls.Add(this.btnTruco);
            this.Controls.Add(this.panelCartas);
            this.Name = "FrmJugarManoTruco";
            this.Text = "FrmJugarMano";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelCartas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTruco;
    }
}