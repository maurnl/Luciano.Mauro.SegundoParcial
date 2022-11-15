using Biblioteca.ADO;
using Biblioteca.Modelos;
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
    public partial class FrmCrudJugador : Form
    {
        private Jugador jugador;
        private bool editando;

        public Jugador JugadorDelForm
        {
            get
            {
                return this.jugador;
            }
        }

        public FrmCrudJugador()
        {
            InitializeComponent();
        }

        public FrmCrudJugador(Jugador jugador, bool editando) : this()
        {
            this.editando = editando;
            this.jugador = jugador;
            this.lblId.Text = $"ID {jugador.Id}";
            this.btnAceptar.Text = "Confirmar cambios";
        }

        private void FrmCrudJugador_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_menu")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!editando)
            {
                this.jugador = new Jugador(this.txtNombre.Text, this.txtApellido.Text);
                this.jugador.CantidadVictoriasTruco = (int)this.nudVictoriasTruco.Value;
                this.jugador.CantidadVictoriasJanKenPon = (int)this.nudVictoriasPPT.Value;

            } else
            {
                this.jugador.Nombre = this.txtNombre.Text;
                this.jugador.Apellido = this.txtApellido.Text;
                this.jugador.CantidadVictoriasTruco = (int)this.nudVictoriasTruco.Value;
                this.jugador.CantidadVictoriasJanKenPon = (int)this.nudVictoriasPPT.Value;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
