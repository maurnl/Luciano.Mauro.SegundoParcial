namespace Vista
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTruco = new System.Windows.Forms.Button();
            this.btnJankenpon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTruco
            // 
            this.btnTruco.Location = new System.Drawing.Point(38, 99);
            this.btnTruco.Name = "btnTruco";
            this.btnTruco.Size = new System.Drawing.Size(130, 130);
            this.btnTruco.TabIndex = 0;
            this.btnTruco.Text = "Jugar al Truco!";
            this.btnTruco.UseVisualStyleBackColor = true;
            this.btnTruco.Click += new System.EventHandler(this.btnTruco_Click);
            // 
            // btnJankenpon
            // 
            this.btnJankenpon.Location = new System.Drawing.Point(207, 99);
            this.btnJankenpon.Name = "btnJankenpon";
            this.btnJankenpon.Size = new System.Drawing.Size(130, 130);
            this.btnJankenpon.TabIndex = 1;
            this.btnJankenpon.Text = "Jugar Jan-Ken-Pon!";
            this.btnJankenpon.UseVisualStyleBackColor = true;
            this.btnJankenpon.Click += new System.EventHandler(this.btnJankenpon_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 344);
            this.Controls.Add(this.btnJankenpon);
            this.Controls.Add(this.btnTruco);
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTruco;
        private System.Windows.Forms.Button btnJankenpon;
    }
}
