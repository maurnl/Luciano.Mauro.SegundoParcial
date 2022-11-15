namespace Vista
{
    partial class FrmHistorialPartidas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblJuego = new System.Windows.Forms.Label();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvHistorial);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 537);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(302, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "No hay partidas en el sistema.";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowTemplate.Height = 25;
            this.dgvHistorial.Size = new System.Drawing.Size(1071, 537);
            this.dgvHistorial.TabIndex = 0;
            // 
            // lblJuego
            // 
            this.lblJuego.AutoSize = true;
            this.lblJuego.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJuego.Location = new System.Drawing.Point(12, 19);
            this.lblJuego.Name = "lblJuego";
            this.lblJuego.Size = new System.Drawing.Size(100, 33);
            this.lblJuego.TabIndex = 1;
            this.lblJuego.Text = "label1";
            // 
            // btnSerializar
            // 
            this.btnSerializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerializar.Location = new System.Drawing.Point(806, 12);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(126, 39);
            this.btnSerializar.TabIndex = 2;
            this.btnSerializar.Text = "Serializar...";
            this.btnSerializar.UseVisualStyleBackColor = true;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeserializar.Location = new System.Drawing.Point(957, 12);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(126, 39);
            this.btnDeserializar.TabIndex = 3;
            this.btnDeserializar.Text = "Deserializar...";
            this.btnDeserializar.UseVisualStyleBackColor = true;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click);
            // 
            // FrmHistorialPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 615);
            this.Controls.Add(this.btnDeserializar);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.lblJuego);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHistorialPartidas";
            this.Text = "FrmHistorialPartidas";
            this.Load += new System.EventHandler(this.FrmHistorialPartidas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblJuego;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Button btnDeserializar;
    }
}