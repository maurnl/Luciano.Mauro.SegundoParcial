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
        private FrmMenuTruco formMenuTruco;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.formMenuTruco = new FrmMenuTruco();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            this.formMenuTruco.Show();
        }
    }
}
