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
    public partial class FrmPartidaJanKenPon : Form
    {
        private List<Image> imagenes;
        private JanKenPonDatosDeJuego datosDeJuego;
        public FrmPartidaJanKenPon()
        {
            InitializeComponent();
            this.imagenes = new List<Image>();
        }

        public FrmPartidaJanKenPon(Partida partida) : this()
        {
            this.datosDeJuego = (JanKenPonDatosDeJuego) partida.DatosDeJuego;
            partida.NotificarDatosDeJuegoActualizados += MostrarDatosDeJuego;
            //List<int> selecciones;
            //for (int i = 0; i < 3; i++)
            //{
            //    if (datosDeJuego.JugadorTurnoActual == datosDeJuego.Jugadores[0])
            //    {
            //        selecciones = datosDeJuego.SeleccionesJugadorA;
            //    }
            //    else
            //    {
            //        selecciones = datosDeJuego.SeleccionesJugadorA;
            //    }
            //    Button boton = new Button
            //    {
            //        Size = new Size(100, 175),
            //        Text = $"Seleccion: {NumeroAString(i)}",
            //        TabIndex = i,
            //        BackgroundImage = (Image)Resources.ResourceManager.GetObject($"{NumeroAString(i)}")!,
            //        BackgroundImageLayout = ImageLayout.Stretch
            //    };
            //    this.panelCartas.Controls.Add(boton);
            //    boton.Click += Button_onClick;
            //    this.btnTruco.Click += CantarTruco;
            //    this.indiceCartaJugada = 0;
            //}
            //this.StartPosition = FormStartPosition.CenterScreen;

            // Ganador
            //this.lblGanador.Text = datosDeJuego.HayGanador ? $"Ganador: {datosDeJuego.Ganador.Nombre}!!" : "Jugando...";
            // Puntaje
            //this.lblJugadorA.Text = $"{datosDeJuego.Jugadores[0].Nombre}: {datosDeJuego.PuntajeJugadorA}";
            //this.lblJugadorB.Text = $"{datosDeJuego.Jugadores[1].Nombre}: {datosDeJuego.PuntajeJugadorB}";
            // Turnos
            //if (panelJuegoJ2.Controls.Count < 3)
            //{
                //this.rtbLog.Text = this.rtbLog.Text.Insert(0, datosDeJuego.LogPartida);
            //}
        }

        //private void PedirJugada(object? sender, EventArgs e)
        //{
        //    MostrarCartas(sender!, e);
        //    FrmJugarManoTruco formMano = new FrmJugarManoTruco(datosDeJuego);
        //    if (formMano.ShowDialog() == DialogResult.OK)
        //    {
        //        datosDeJuego.SetSeleccionJugador(datosDeJuego.JugadorTurnoActual, formMano.IndiceCartaJugada);
        //    }
        //}

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
                // Ganador
                //this.lblGanador.Text = datosDeJuego.HayGanador ? $"Ganador: {datosDeJuego.Ganador.Nombre}!!" : "Jugando...";
                // Puntaje
                //this.lblJugadorA.Text = $"{datosDeJuego.Jugadores[0].Nombre}: {datosDeJuego.PuntajeJugadorA}";
                //this.lblJugadorB.Text = $"{datosDeJuego.Jugadores[1].Nombre}: {datosDeJuego.PuntajeJugadorB}";
                // Turnos
                //if (panelJuegoJ2.Controls.Count < 3)
                //{
                //}
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
