using Biblioteca.Modelos;
using Biblioteca.Presentadores;
using Biblioteca.Vistas;
using Entidades.Entidades;
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
    public partial class FrmMenuTruco : FrmMenuJuegoBase, IVistaMenuTruco
    {
        private readonly PresentadorMenuTruco presentadorMenuTruco;
        private Dictionary<Partida<Truco>, FrmPartidaTruco> formsPartidas;
        public FrmMenuTruco()
        {
            InitializeComponent();
            this.presentadorMenuTruco = new PresentadorMenuTruco(this);
            this.formsPartidas = new Dictionary<Partida<Truco>, FrmPartidaTruco>();
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

        public void AbrirComponentePartida(Partida<Truco> partida)
        {
            if (!formsPartidas.ContainsKey(partida))
            {
                new FrmPartidaTruco(partida).Show();
            }
            else
            {
                formsPartidas[partida].Show();
            }
        }

        public void CrearComponentePartida(Partida<Truco> partida)
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

        public void ActualizarComponentePartida(Partida<Truco> partida)
        {
            int indice = BuscarComponentePorPartida(partida);
            ActualizarBoton(partida, indice);
        }

        public void EliminarComponentePartida(Partida<Truco> partida)
        {
            EliminarBoton(partida);
        }




        private void EliminarBoton(Partida<Truco> partida)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Partida<Truco>>(EliminarBoton), partida);

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

        private void ActualizarBoton(Partida<Truco> partida, int indiceBoton)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Partida<Truco>, int>(ActualizarBoton), partida, indiceBoton);
            }
            else
            {
                if (indiceBoton < 0 || indiceBoton > flowPanelPartidas.Controls.Count)
                {
                    return;
                }
                this.flowPanelPartidas.Controls[indiceBoton].Text = $"{partida.JugadorA.Nombre} y {partida.JugadorB.Nombre} estan jugando la mano {(partida.RondaActual == 3 ? "3" : $"{partida.RondaActual + 1}")} de {partida.Juego.GetType().Name}!";
            }
        }

        private int BuscarComponentePorPartida(Partida<Truco> partida)
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
    }
}
