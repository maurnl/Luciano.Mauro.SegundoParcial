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
            ActualizarDatagrid(this.partidas);
        }

        private void ActualizarDatagrid(List<PartidaTerminada> listaPartidas)
        {
            this.label1.Visible = true;
            this.dgvHistorial.Visible = false;
            this.dgvHistorial.DataSource = null;
            if(this.partidas.Count > 0)
            {
                this.label1.Visible = false;
                this.dgvHistorial.DataSource = listaPartidas;
                this.dgvHistorial.Visible = true;
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            FrmSerializacion frmSerializacion = new FrmSerializacion(this.partidas, true);
            if(frmSerializacion.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Archivo generado correctamente!");
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            FrmSerializacion frmSerializacion = new FrmSerializacion(this.partidas, false);
            if (frmSerializacion.ShowDialog() == DialogResult.OK)
            {
                this.partidas = frmSerializacion.PartidasDeserializadas;
                ActualizarDatagrid(this.partidas);
                MessageBox.Show("Lista cargada correctamente!");
            }
        }
    }
}
