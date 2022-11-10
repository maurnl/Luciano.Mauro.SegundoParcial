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
using Vista.Properties;

namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        FrmMenuTruco formTruco;
        FrmMenuJanKenPon formJankenpon;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.formTruco = new FrmMenuTruco();
            this.formJankenpon = new FrmMenuJanKenPon();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            this.btnJankenpon.Enabled = false;
            this.btnTruco.Enabled = false;
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_principal")!;
            this.btnTruco.BackgroundImage = (Image)Resources.ResourceManager.GetObject("boton_truco")!;
            this.btnTruco.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.lblDescripcion.BackColor = Color.FromArgb(50, 100, 100, 100);
            this.lblBienvenido.BackColor = Color.FromArgb(50, 100, 100, 100);
            this.label1.BackColor = Color.FromArgb(50, 100, 100, 100);
            this.Text = "Eligir sala de juego...";
            this.lblBienvenido.Text = "Bienvenido!";
            this.lblDescripcion.Text = "";
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            formTruco.Show();
        }

        private void btnJankenpon_Click(object sender, EventArgs e)
        {
            formJankenpon.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(this.txtNombre.Text == "")
            {
                this.btnJankenpon.Enabled = false;
                this.btnTruco.Enabled = false;
                this.lblBienvenido.Text = "Bienvenido!";
            }
            else
            {
                this.lblBienvenido.Text = $"Bienvenido, {this.txtNombre.Text}!";
                this.btnJankenpon.Enabled = true;
                this.btnTruco.Enabled = true;
            }
        }

        private void btnTruco_MouseEnter(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = "En cada ronda, se reparten 3 cartas a cada jugador y todos tiran una carta \n" +
                "por turnos. El jugador con la carta de mayor valor ganará dicha mano y tirará primero en la \n" +
                "siguiente. La primera pareja o jugador que gana 2 manos, gana la ronda.                         \n" +
                "                                               ";
        }

        private void btnJankenpon_MouseEnter(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = "A \"Piedra, papel o tijeras\" se juega de dos en dos. Los jugadores se \n" +
                "deben poner uno frente al otro con una mano a la espalda y decir en alto: piedra, papel o tijera,\n" +
                " justo al acabar la frase enseñarán las manos y verán quien gana. Si los dos jugadores sacan la \n" +
                "misma figura hay empate, tablas, no gana nadie.";
        }
    }
}
