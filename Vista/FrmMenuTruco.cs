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
    public partial class FrmMenuTruco : Form, IVistaMenuTruco
    {
        private readonly PresentadorMenuTruco presentadorMenuTruco;
        public FrmMenuTruco()
        {
            InitializeComponent();
            this.presentadorMenuTruco = new PresentadorMenuTruco(this);
        }

        public bool EsPartidaSimulada
        {
            get
            {
                return this.chkSimulada.Checked;
            }
        }

        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;

        public void AbrirComponentePartida(Partida<Truco> partida)
        {
            new FrmPartidaTruco(partida).Show();
        }

        public void CrearComponentePartida(Partida<Truco> partida)
        {
            Button boton = new Button
            {
                Size = new Size(200, 200),
                Text = $"{partida.JugadorA.Nombre} y {partida.JugadorB.Nombre} estan jugando...",
                Name = $"{partida.Id}"
            };
            this.flowPanelPartidas.Controls.Add(boton);
            boton.Click += (sender, e) => this.ClickeoAbrirPartida?.Invoke(((Button)sender!).Name, e);
        }

        public void EliminarComponentePartida(Partida<Truco> partida)
        {
            int cantidadItems = this.flowPanelPartidas.Controls.Count;
            for (int i = cantidadItems - 1; i >= 0; i--)
            {
                Control item = this.flowPanelPartidas.Controls[i];
                if(item is Button boton)
                {
                    if(boton.Name == partida.Id.ToString())
                    {
                        this.Invoke(new Action(() => this.flowPanelPartidas.Controls.RemoveAt(i)));
                    }
                }
            }
        }

        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            this.ClickeoNuevaPartida?.Invoke(this, e);
        }
    }
}
