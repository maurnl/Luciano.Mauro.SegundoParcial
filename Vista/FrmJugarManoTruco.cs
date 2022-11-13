using Biblioteca.Modelos;
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
    public partial class FrmJugarManoTruco : Form
    {
        private TrucoDatosDeJuego datosDeJuego;
        private int indiceCartaJugada;

        public FrmJugarManoTruco(TrucoDatosDeJuego datosDeJuego)
        {
            InitializeComponent();
            List<Carta> cartas;
            this.datosDeJuego = datosDeJuego;
            for (int i = 0; i < 3; i++)
            {
                if (datosDeJuego.JugadorTurnoActual == datosDeJuego.Jugadores[0])
                {
                    cartas = datosDeJuego.CartasJugadorA;
                }
                else
                {
                    cartas = datosDeJuego.CartasJugadorB;
                }
                if (cartas[i].EstaEnJuego)
                {
                    continue;
                }
                Button boton = new Button
                {
                    Size = new Size(100, 175),
                    Text = $"Carta {cartas[i]}",
                    TabIndex = i,
                    BackgroundImage = (Image)Resources.ResourceManager.GetObject($"{cartas[i].Numero}de{cartas[i].Palo.ToString().ToLower()}")!,
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                this.panelCartas.Controls.Add(boton);
                boton.Click += Button_onClick;
                this.btnTruco.Click += CantarTruco;
                this.indiceCartaJugada = 0;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public int IndiceCartaJugada
        {
            get
            {
                return this.indiceCartaJugada;
            }
        }

        public void CantarTruco(object? sender, EventArgs e)
        {
            datosDeJuego.HayTrucoCantado = true;
            this.DialogResult = DialogResult.OK;
        }

        public void Button_onClick(object? sender, EventArgs e)
        {
            this.indiceCartaJugada = ((Button)sender!).TabIndex;
            this.DialogResult = DialogResult.OK;
        }
    }
}
