using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class PartidaTerminada
    {
        private int idPartida;
        private string nombreGanador;
        private string nombrePerdedor;
        private int rondasJugadas;
        private string nombreJuego;

        public PartidaTerminada()
        {

        }

        public PartidaTerminada(int idPartida, string nombreGanador, string nombrePerdedor, int rondasJugadas, string nombreJuego)
        {
            this.idPartida = idPartida;
            this.nombreGanador = nombreGanador;
            this.nombrePerdedor = nombrePerdedor;
            this.rondasJugadas = rondasJugadas;
            this.nombreJuego = nombreJuego;
        }
        
        public int IdPartida
        {
            get
            {
                return this.idPartida;
            }
            set
            {
                this.idPartida = value;
            }
        }

        public string NombreGanador
        {
            get
            {
                return this.nombreGanador;
            }
            set
            {
                this.nombreGanador = value;
            }
        }

        public string NombrePerdedor
        {
            get
            {
                return this.nombrePerdedor;
            }
            set
            {
                this.nombrePerdedor = value;
            }
        }

        public int RondasJugadas
        {
            get
            {
                return this.rondasJugadas;
            }
            set
            {
                this.rondasJugadas = value;
            }
        }

        public string NombreJuego
        {
            get
            {
                return this.nombreJuego;
            }
            set
            {
                this.nombreJuego = value;
            }
        }
    }
}
