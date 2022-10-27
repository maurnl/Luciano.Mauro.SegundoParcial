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

namespace Vista
{
    public partial class FormPrincipal : Form, IFormPrincipal
    {
        private IVistaPartidas vistaPartidas;
        private IVistaJuego vistaJuego;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(IVistaPartidas vistaPartidas, IVistaJuego vistaJuego) : this()
        {
            this.vistaPartidas = vistaPartidas;
            this.vistaJuego = vistaJuego;
        }

        public void MostrarVistaJuego(IJuego juego)
        {
            this.vistaJuego.Show();
        }

        public void MostrarVistaPartidas()
        {
            this.vistaPartidas.Show();
        }
    }
}
