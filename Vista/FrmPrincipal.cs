using Biblioteca.Modelos;
using Biblioteca.Presentadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        private PresentadorPrincipal presentadorPrincipal;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "Eligir sala de juego...";
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            new FrmMenuTruco().Show();
        }
    }
}
