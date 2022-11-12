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
    public partial class FrmHistorialPartidas : Form
    {
        private List<PartidaTerminada> partidas;
        private string juego;
        public FrmHistorialPartidas()
        {
            InitializeComponent();
        }

        public FrmHistorialPartidas(List<PartidaTerminada> partidas, string juego) : this()
        {
            this.partidas = partidas;
            this.juego = juego;
        }

        private void FrmHistorialPartidas_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_menu")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.lblJuego.Text = $"Historial de partidas de {this.juego}";
            ActualizarDatagrid();
        }

        private void ActualizarDatagrid()
        {
            this.label1.Visible = true;
            this.dgvHistorial.Visible = false;
            this.dgvHistorial.DataSource = null;
            if(this.partidas.Count > 0)
            {
                this.label1.Visible = false;
                this.dgvHistorial.DataSource = partidas;
                this.dgvHistorial.Visible = true;
            }
        }
    }
}
