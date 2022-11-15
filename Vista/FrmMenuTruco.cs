using Biblioteca.ADO;
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
    public partial class FrmMenuTruco : FrmMenuJuegoBase, IPresentadorMenuJuego
    {
        private readonly PresentadorMenuJuego presentadorMenuTruco;
        public FrmMenuTruco()
        {
            InitializeComponent();
            this.presentadorMenuTruco = new PresentadorMenuJuego(this, new Truco(), new JugadorADO());
            this.Text = "Sala de Truco!";
        }

        public bool EsPartidaSimulada
        {
            get
            {
                return this.chkSimulada.Checked;
            }
        }

        public event EventHandler OnCierreVista;
        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;
        public event EventHandler ClickeoMostrarHistorialPartidas;

        public void AbrirComponentePartida(Partida partida)
        {
            new FrmPartidaTruco(partida).Show();
        }

        public void CrearComponentePartida(Partida partida)
        {
            Button boton = new Button
            {
                Size = new Size(200, 200),
                Text = $"{partida.JugadorA.Nombre} y {partida.JugadorB.Nombre} estan por comenzar a jugar...",
                Name = $"{partida.Id}"
            };
            this.flowPanelPartidas.Controls.Add(boton);
            boton.Click += (sender, e) => this.ClickeoAbrirPartida?.Invoke(((Button)sender!).Name, e);
        }

        public void ActualizarComponentePartida(Partida partida)
        {
            int indice = BuscarComponentePorPartida(partida);
            ActualizarBoton(partida, indice);
        }

        public void EliminarComponentePartida(Partida partida)
        {
            EliminarBoton(partida);
        }

        private void EliminarBoton(Partida partida)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Partida>(EliminarBoton), partida);

            }
            else
            {
                int indice = BuscarComponentePorPartida(partida);
                if (indice != -1)
                {
                    base.flowPanelPartidas.Controls.RemoveAt(indice);
                }
            }
        }

        private void ActualizarBoton(Partida partida, int indiceBoton)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Partida, int>(ActualizarBoton), partida, indiceBoton);
            }
            else
            {
                if (indiceBoton < 0 || indiceBoton > flowPanelPartidas.Controls.Count || indiceBoton > this.flowPanelPartidas.Controls.Count - 1)
                {
                    return;
                }
                this.flowPanelPartidas.Controls[indiceBoton].Text = $"{partida.JugadorA.Nombre} y {partida.JugadorB.Nombre} estan jugando la mano {(partida.RondaActual == 3 ? "3" : $"{partida.RondaActual + 1}")} de Truco!";
            }
        }

        private int BuscarComponentePorPartida(Partida partida)
        {
            int cantidadItems = this.flowPanelPartidas.Controls.Count;
            int indice = -1;
            for (int i = cantidadItems - 1; i >= 0; i--)
            {
                Control item = this.flowPanelPartidas.Controls[i];
                if (item is Button boton)
                {
                    if (boton.Name == partida.Id.ToString())
                    {
                        indice = i;
                        break;
                    }
                }
            }
            return indice;
        }

        protected override void FrmMenuJuegoBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.OnCierreVista?.Invoke(this, EventArgs.Empty);
            this.Hide();
        }

        protected override void btnCrearPartida_Click(object sender, EventArgs e)
        {
            this.ClickeoNuevaPartida?.Invoke(this, e);
        }

        protected override void btnHistorialPartidas_Click(object sender, EventArgs e)
        {
            this.ClickeoMostrarHistorialPartidas?.Invoke(this, e);
        }

        public void MostrarHistorialPartidas(List<PartidaTerminada> historialPartidas, string juego)
        {
            new FrmHistorialPartidas(historialPartidas, juego).Show();
        }

        public void MostrarCantidadPartidas(int cantidadPartidas)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(MostrarCantidadPartidas), cantidadPartidas);
            } 
            else
            {
                base.lblCantidadPartidas.Text = $"Partidas activas: {cantidadPartidas}";
            }
        }
    }
}
