using Biblioteca.Modelos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista
{
    public partial class FrmPartidaTruco : Form
    {
        private TrucoDatosDeJuego datosDeJuego;
        private Partida<Truco> partida;

        public FrmPartidaTruco()
        {
            InitializeComponent();
        }

        public FrmPartidaTruco(Partida<Truco> partida) : this()
        {
            this.partida = partida;
            this.datosDeJuego = (TrucoDatosDeJuego)partida.Juego.ObtenerDatosDeJuego();
            if (partida.JugadorA.EsHumano)
            {
                this.partida.JugadorA.TurnoDeJugador += PedirJugada;
            }
            if (partida.JugadorB.EsHumano)
            {
                this.partida.JugadorB.TurnoDeJugador += PedirJugada;
            }
            this.partida.NotificarDatosDeJuegoActualizados += MostrarCartas;
        }

        private void FrmTruco_Load(object sender, EventArgs e)
        {
            MostrarCartas(null!, (EventArgs)null!);
            this.label1.Text = "";
        }

        private void MostrarCartas(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler delegado = MostrarCartas;
                Invoke(delegado, sender, e);
            }
            else
            {
                this.panelManoJ1.Controls.Clear();
                this.panelManoJ2.Controls.Clear();
                this.panelJuegoJ1.Controls.Clear();
                this.panelJuegoJ2.Controls.Clear();
                MostrarCartas(datosDeJuego.CartasJugadorA, panelManoJ1);
                MostrarCartas(datosDeJuego.CartasJugadorB, panelManoJ2);
                MostrarCartas(datosDeJuego.CartasEnJuegoJugadorA, panelJuegoJ1);
                MostrarCartas(datosDeJuego.CartasEnJuegoJugadorB, panelJuegoJ2);
                // Ganador
                this.lblGanador.Text = datosDeJuego.HayGanador ? $"Ganador: {datosDeJuego.Ganador.Nombre}!!" : "Jugando...";
                // Puntaje
                this.lblJugadorA.Text = $"{datosDeJuego.Jugadores[0].Nombre}: {datosDeJuego.PuntajeJugadorA}";
                this.lblJugadorB.Text = $"{datosDeJuego.Jugadores[1].Nombre}: {datosDeJuego.PuntajeJugadorB}";
                // Turnos
                if (panelJuegoJ2.Controls.Count < 3)
                {
                    this.rtbLog.Text = this.rtbLog.Text.Insert(0, datosDeJuego.LogPartida);
                }
            }
        }

        private void PedirJugada(object sender, EventArgs e)
        {
            MostrarCartas(sender, e);
            FrmJugarManoTruco formMano = new FrmJugarManoTruco(datosDeJuego);
            if (formMano.ShowDialog() == DialogResult.OK)
            {
                datosDeJuego.SetSeleccionJugador(datosDeJuego.JugadorTurnoActual, formMano.IndiceCartaJugada);
            }
        }

        private void MostrarCartas(List<Carta> cartas, Panel panel)
        {
            foreach (Carta carta in cartas)
            {
                PictureBox pb = new PictureBox
                {
                    BackgroundImage = (Image)Resources.ResourceManager.GetObject($"{carta.Numero}de{carta.Palo.ToString().ToLower()}")!,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Size = new Size(70, 145)
                };
                panel.Controls.Add(pb);
                if (carta.EstaEnJuego && (panel == panelManoJ1 || panel == panelManoJ2))
                {
                    panel.Controls[panel.Controls.Count - 1].Visible = false;
                }
            }
        }

        private void FrmTruco_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!datosDeJuego.HayGanador)
            {
                e.Cancel = true;
                this.Hide();
            } else
            {
                this.partida.JugadorA.TurnoDeJugador -= PedirJugada;
                this.partida.JugadorB.TurnoDeJugador -= PedirJugada;
                this.partida.NotificarDatosDeJuegoActualizados -= MostrarCartas;
            }
        }
    }
}
