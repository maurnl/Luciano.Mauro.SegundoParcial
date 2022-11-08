using Biblioteca.Modelos;
using Biblioteca.Vistas;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorMenuTruco
    {
        private IVistaMenuTruco vistaMenuTruco;
        private ManejadorPartida<Truco> manejadorPartidaTruco;

        public event EventHandler NuevaPartidaCreada;
        public event EventHandler PartidaTerminada;

        public PresentadorMenuTruco(IVistaMenuTruco vistaMenuTruco)
        {
            this.vistaMenuTruco = vistaMenuTruco;
            this.manejadorPartidaTruco = new ManejadorPartida<Truco>();
            this.vistaMenuTruco.ClickeoNuevaPartida += NuevaPartida;
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            if (this.vistaMenuTruco.EsPartidaSimulada)
            {
                this.manejadorPartidaTruco.NuevaPartida();
            }
            //this.NuevaPartidaCreada?.Invoke();
        }

        private void EliminarComponentePartida(object sender, EventArgs e)
        {
            //this.PartidaTerminada?.Invoke();
        }
    }
}
