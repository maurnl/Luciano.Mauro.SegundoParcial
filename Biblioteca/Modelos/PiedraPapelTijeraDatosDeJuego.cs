using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class PiedraPapelTijeraDatosDeJuego : IDatosDeJuego<PiedraPapelTijera>
    {
        private bool hayGanador;
        private List<Jugador> jugadores;
        private Jugador ganador;
        private int rondaActual;
        private int puntajeJugadorA;
        private int puntajeJugadorB;
        private int seleccionJugadorA;
        private int seleccionJugadorB;
        private int contadorTurnos;
        private bool hayGanadorDeRonda;
        private Jugador jugadorTurnoActual;
        private string logPartida;

        public PiedraPapelTijeraDatosDeJuego()
        {
            this.contadorTurnos = 0;
            this.rondaActual = 0;
            this.puntajeJugadorA = 0;
            this.puntajeJugadorB = 0;
            this.hayGanador = false;
            this.hayGanadorDeRonda = false;
            this.logPartida = "";
        }

        public Jugador JugadorTurnoActual
        {
            get
            {
                return this.jugadorTurnoActual;
            }
        }
        public int SeleccionJugadorA
        {
            get
            {
                return this.seleccionJugadorA;
            }
            set
            {
                this.seleccionJugadorA = value;
            }
        }

        public int SeleccionJugadorB
        {
            get
            {
                return this.seleccionJugadorB;
            }
            set
            {
                this.seleccionJugadorB = value;
            }
        }

        public bool HayGanador
        {
            get
            {
                return this.hayGanador;
            }
            set
            {
                this.hayGanador = true;
            }
        }
        public Jugador Ganador
        {
            get
            {
                return this.ganador;
            }
            set
            {
                this.ganador = value;
                this.hayGanador = true;
            }
        }
        public List<Jugador> Jugadores
        {
            get
            {
                return this.jugadores;
            }
            set
            {
                this.jugadores = value;
                this.jugadorTurnoActual = this.jugadores[0];
            }
        }

        public int PuntajeJugadorA
        {
            get
            {
                return this.puntajeJugadorA;
            }
        }

        public int PuntajeJugadorB
        {
            get
            {
                return this.puntajeJugadorB;
            }
        }
        public int RondaActual
        {
            get
            {
                return this.rondaActual;
            }
        }

        public bool HayGanadorDeRonda
        {
            get
            {
                return this.hayGanadorDeRonda;
            }
        }

        public string LogPartida
        {
            get
            {
                return this.logPartida;
            }
        }

        public void SetSeleccionJugador(Jugador jugador, int seleccion)
        {
            if (jugador.Equals(this.jugadores[0]))
            {
                this.seleccionJugadorA = seleccion;
            }
            else if (jugador.Equals(this.jugadores[1]))
            {
                this.seleccionJugadorB = seleccion;
            }
        }

        public void Jugar()
        {
            this.jugadorTurnoActual = Jugadores[contadorTurnos];
            if(jugadorTurnoActual == jugadores[0])
            {
                this.logPartida += $"{jugadores[0].Nombre} elegio {NumeroAString(seleccionJugadorA)}...\n";
            }
            else
            {
                this.logPartida += $"{jugadores[1].Nombre} elegio {NumeroAString(seleccionJugadorB)}...\n";
            }
            Thread.Sleep(1000);
            if (contadorTurnos < 1)
            {
                contadorTurnos++;
                return;
            }
            contadorTurnos = 0;
            rondaActual++;
            if (seleccionJugadorA - seleccionJugadorB == 0)
            {
                // Empate
                this.logPartida += "Empate!!!\n";
            }
            else if (seleccionJugadorA - seleccionJugadorB == -1 || seleccionJugadorA - seleccionJugadorB == 2)
            {
                // Gana jugador B

                this.logPartida += $"{jugadores[0].Nombre} gano! Obtiene 1 punto!\n";
                puntajeJugadorB++;
            }
            else if (seleccionJugadorA - seleccionJugadorB == 1 || seleccionJugadorB - seleccionJugadorA == 2)
            {
                // Gana jugador A
                this.logPartida += $"{jugadores[1].Nombre} gano! Obtiene 1 punto!\n";
                puntajeJugadorA++;
            }
            if (puntajeJugadorA == 3)
            {
                Ganador = this.Jugadores[0];
            }
            else if (puntajeJugadorB == 3)
            {
                Ganador = this.Jugadores[1];
            }
            if(Ganador != null)
            {
                this.logPartida += $"{Ganador.Nombre} gana la partida!";
            }
            Thread.Sleep(1000);
        }

        public void Inicializar()
        {
            return;
        }

        private string NumeroAString(int numero)
        {
            string texto = "";
            switch (numero)
            {
                case 0:
                    texto += "Piedra";
                    break;
                case 1:
                    texto += "Papel";
                    break;
                case 2:
                    texto += "Tijera";
                    break;
            }
            return texto;
        }

    }
}
