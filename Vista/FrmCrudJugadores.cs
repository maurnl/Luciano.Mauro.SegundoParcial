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
    public partial class FrmCrudJugadores : Form
    {
        private List<Jugador> listaJugadores;
        private JugadorADO jugadorAdo;
        public FrmCrudJugadores()
        {
            InitializeComponent();
            this.jugadorAdo = new JugadorADO();
        }

        private void FrmCrudJugadores_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_menu")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = "CRUD Jugadores...";
            ActualizarDatagrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCrudJugador formCrud = new FrmCrudJugador();
            if (formCrud.ShowDialog() == DialogResult.OK)
            {
                Jugador jugadorDelForm = formCrud.JugadorDelForm;
                if (jugadorDelForm is not null && this.jugadorAdo.AgregarJugador(jugadorDelForm))
                {
                    MessageBox.Show("Jugador agregado correctamente!");
                }
                else
                {
                    MessageBox.Show("Error al agregar...");
                }
            }
            ActualizarDatagrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Jugador jugadorSeleccionado = (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;
            if(jugadorSeleccionado is null)
            {
                return;
            }
            FrmCrudJugador formCrud = new FrmCrudJugador(jugadorSeleccionado, true);
            if(formCrud.ShowDialog() == DialogResult.OK)
            {
                if (this.jugadorAdo.ModificarJugador(jugadorSeleccionado))
                {
                    MessageBox.Show("Jugador modificado correctamente!");
                }
                else
                {
                    MessageBox.Show("Error al modificar...");
                }
            }
            ActualizarDatagrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Jugador jugadorSeleccionado = (Jugador)dgvJugadores.SelectedRows[0].DataBoundItem;
            if (jugadorSeleccionado is null)
            {
                return;
            }
            if (this.jugadorAdo.EliminarJugador(jugadorSeleccionado.Id))
            {
                MessageBox.Show("Jugador eliminado correctamente!");
            }
            else
            {
                MessageBox.Show("Error al eliminar...");

            }
            ActualizarDatagrid();
        }

        private void ActualizarDatagrid()
        {
            this.dgvJugadores.DataSource = null;
            this.listaJugadores = this.jugadorAdo.ObtenerListaJugadores();
            if(this.listaJugadores is not null && this.listaJugadores.Count > 0)
            {
                this.dgvJugadores.DataSource = this.listaJugadores;
            }
        }
    }
}
