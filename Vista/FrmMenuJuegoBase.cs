using Biblioteca.Serializacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Vista.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class FrmMenuJuegoBase : Form
    {
        public FrmMenuJuegoBase()
        {
            InitializeComponent();
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_menu")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.tableLayoutPanel1.BackColor = Color.FromArgb(50, 244, 164, 96);

            foreach (Control control in this.tableLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = Color.FromArgb(80, 244, 164, 96);
                }
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return createParams;
            }
        }

        protected virtual void btnCrearPartida_Click(object sender, EventArgs e)
        {

        }

        protected virtual void FrmMenuJuegoBase_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        protected virtual void btnHistorialPartidas_Click(object sender, EventArgs e)
        {

        }


    }
}
