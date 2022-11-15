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
    public partial class FrmPartidaPiedraPapelTijera : Form
    {
        private List<Image> imagenes;
        private PiedraPapelTijeraDatosDeJuego datosDeJuego;
        public FrmPartidaPiedraPapelTijera()
        {
            InitializeComponent();
            this.imagenes = new List<Image>();
        }

        public FrmPartidaPiedraPapelTijera(Partida partida) : this()
        {
            this.datosDeJuego = (PiedraPapelTijeraDatosDeJuego)partida.DatosDeJuego;
            partida.NotificarDatosDeJuegoActualizados += MostrarDatosDeJuego;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return createParams;
            }
        }


        private void MostrarDatosDeJuego(object? sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MostrarDatosDeJuego), sender, e);
            }
            else
            {
                if (datosDeJuego.JugadorTurnoActual == datosDeJuego.Jugadores[0])
                {
                    this.panelJugadorA.Controls.Clear();
                    MostrarElemento(datosDeJuego.SeleccionJugadorA, panelJugadorA);
                } else
                {
                    this.panelJugadorB.Controls.Clear();
                    MostrarElemento(datosDeJuego.SeleccionJugadorB, panelJugadorB);
                }
                this.rtbLog.Text = "";
                this.rtbLog.Text = this.rtbLog.Text.Insert(0, datosDeJuego.LogPartida);
            }
        }

        private void MostrarElemento(int elemento, Panel panel)
        {
            PictureBox pb = new PictureBox
            {
                BackgroundImage = datosDeJuego.Jugadores[0].EsHumano && elemento == datosDeJuego.SeleccionJugadorB ? (Image)Resources.ResourceManager.GetObject("reverso")! : (Image)Resources.ResourceManager.GetObject($"{NumeroAString(elemento)}")!,
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(165, 230)
            };
            panel.Controls.Add(pb);
        }

        private void FrmPartidaJanKenPon_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_jankenpon")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private string NumeroAString(int numero)
        {
            string texto = "";
            switch (numero)
            {
                case 0:
                    texto += "piedra";
                    break;  
                case 1:
                    texto += "papel";
                    break;
                case 2:
                    texto += "tijera";
                    break;
            }
            return texto;
        }
    }
}
