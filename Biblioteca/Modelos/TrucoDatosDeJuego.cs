using System;
using System.Collections.Generic;
using System.Threading;

namespace Biblioteca.Modelos
{
    public class TrucoDatosDeJuego : IDatosDeJuego<Truco>
    {
        private static Random random;
        private bool banderaTurnoJugadorB;
        private readonly List<Carta> mazo;
        private List<Carta> cartasQueSalieron;
        private bool hayGanador;
        private bool hayGanadorDeRonda;
        private bool hayTrucoCantado;
        private bool sePuedeCantarTruco;
        private EstadoTruco estadoTruco;
        private List<Jugador> jugadores;
        private Jugador ganador;
        private int rondaActual;
        private int rondasGanadasJugadorA;
        private int rondasGanadasJugadorB;
        private int puntajeJugadorA;
        private int puntajeJugadorB;
        private int seleccionJugadorA;
        private int seleccionJugadorB;
        private int contadorTurnos;
        private int valorDeRonda;
        private string logPartida;
        private Jugador jugadorTurnoActual;
        private List<Carta> cartasJugadorA;
        private List<Carta> cartasEnJuegoJugadorA;
        private List<Carta> cartasEnJuegoJugadorB;
        private List<Carta> cartasJugadorB;
        private CancellationTokenSource tokenCancelacion;

        static TrucoDatosDeJuego()
        {
            random = new Random();
        }

        public TrucoDatosDeJuego(List<Carta> mazo)
        {
            logPartida = "";
            cartasQueSalieron = new List<Carta>();
            this.mazo = mazo;
            contadorTurnos = 0;
            rondaActual = 0;
            rondasGanadasJugadorA = 0;
            rondasGanadasJugadorB = 0;
            puntajeJugadorA = 0;
            puntajeJugadorB = 0;
            hayGanador = false;
            cartasJugadorA = new List<Carta>();
            cartasJugadorB = new List<Carta>();
            cartasEnJuegoJugadorA = new List<Carta>();
            cartasEnJuegoJugadorB = new List<Carta>();
            banderaTurnoJugadorB = true;
            hayGanadorDeRonda = false;
            hayTrucoCantado = false;
            estadoTruco = EstadoTruco.NoDecidio;
            valorDeRonda = 1;
            tokenCancelacion = new CancellationTokenSource();
            this.sePuedeCantarTruco = true;
        }

        public bool SePuedeCantarTruco
        {
            get
            {
                return this.sePuedeCantarTruco;
            }
        }
        public CancellationToken TokenCancelacion
        {
            get
            {
                return tokenCancelacion.Token;
            }
        }

        public Jugador JugadorTurnoActual
        {
            get
            {
                return jugadorTurnoActual;
            }
        }

        public List<Carta> CartasJugadorA
        {
            get
            {
                return cartasJugadorA;
            }
        }

        public List<Carta> CartasEnJuegoJugadorA
        {
            get
            {
                return cartasEnJuegoJugadorA;
            }
        }

        public List<Carta> CartasJugadorB
        {
            get
            {
                return cartasJugadorB;
            }
        }

        public List<Carta> CartasEnJuegoJugadorB
        {
            get
            {
                return cartasEnJuegoJugadorB;
            }
        }

        public int SeleccionJugadorA
        {
            get
            {
                return seleccionJugadorA;
            }
            set
            {
                seleccionJugadorA = value;
            }
        }

        public int SeleccionJugadorB
        {
            get
            {
                return seleccionJugadorB;
            }
            set
            {
                seleccionJugadorB = value;
            }
        }

        public bool HayGanador
        {
            get
            {
                return hayGanador;
            }
            set
            {
                hayGanador = true;
            }
        }

        public bool HayGanadorDeRonda
        {
            get
            {
                return hayGanadorDeRonda;
            }
        }

        public Jugador Ganador
        {
            get
            {
                return ganador;
            }
            set
            {
                ganador = value;
                hayGanador = true;
            }
        }

        public bool HayTrucoCantado
        {
            get
            {
                return hayTrucoCantado;
            }
            set
            {
                hayTrucoCantado = value;
            }
        }

        public List<Jugador> Jugadores
        {
            get
            {
                return jugadores;
            }
            set
            {
                jugadores = value;
                jugadorTurnoActual = jugadores[0];
            }
        }
        public int PuntajeJugadorA
        {
            get
            {
                return puntajeJugadorA;
            }
        }

        public int PuntajeJugadorB
        {
            get
            {
                return puntajeJugadorB;
            }
        }
        public int RondaActual
        {
            get
            {
                return rondaActual;
            }
        }

        public string LogPartida
        {
            get
            {
                return logPartida;
            }
        }

        public void CancelarPartida()
        {
            tokenCancelacion.Cancel();
        }

        public void SetSeleccionJugador(Jugador jugador, int seleccion)
        {
            if (hayTrucoCantado && estadoTruco == EstadoTruco.NoDecidio)
            {
                return;
            }
            if (jugador.Equals(jugadores[0]))
            {
                seleccionJugadorA = seleccion;
            }
            else if (jugador.Equals(jugadores[1]))
            {
                seleccionJugadorB = seleccion;
            }
        }

        public void SetSeleccionTruco(Jugador jugador, bool seleccion)
        {
            estadoTruco = seleccion ? EstadoTruco.Querido : EstadoTruco.NoQuerido;
            if (estadoTruco == EstadoTruco.NoQuerido)
            {
                if (jugador.Equals(jugadores[0]))
                {
                    rondasGanadasJugadorB++;
                }
                else if (jugador.Equals(jugadores[1]))
                {
                    rondasGanadasJugadorA++;
                }
            }
        }

        private List<Carta> ObtenerCartasAleatorias()
        {
            List<Carta> cartasRetorno = new List<Carta>();
            int indiceRandom;
            for (int i = 0; i < 3; i++)
            {
                Carta cartaRandom;
                do
                {
                    indiceRandom = random.Next(0, mazo.Count);
                    cartaRandom = mazo[indiceRandom];
                } while (cartasQueSalieron.Contains(cartaRandom));
                cartasQueSalieron.Add(cartaRandom);
                cartasRetorno.Add(cartaRandom);
            }
            return cartasRetorno;
        }

        public void Inicializar()
        {
            ReiniciarRonda();
        }

        private void ReiniciarRonda()
        {
            foreach (Carta carta in mazo)
            {
                carta.EstaEnJuego = false;
            }
            this.cartasQueSalieron.Clear();
            this.cartasJugadorA.Clear();
            this.cartasJugadorB.Clear();
            this.cartasEnJuegoJugadorA.Clear();
            this.cartasEnJuegoJugadorB.Clear();
            this.cartasJugadorA = ObtenerCartasAleatorias();
            this.cartasJugadorB = ObtenerCartasAleatorias();
            this.hayGanadorDeRonda = false;
            this.jugadorTurnoActual = jugadores[0];
            this.hayTrucoCantado = false;
            this.valorDeRonda = 1;
            this.estadoTruco = EstadoTruco.NoDecidio;
            this.sePuedeCantarTruco = true;
        }

        public void Jugar()
        {
            if (this.rondaActual == 3)
            {
                if (this.banderaTurnoJugadorB)
                {
                    banderaTurnoJugadorB = false;
                    return;
                }
                this.rondaActual = 0;
                ReiniciarRonda();
                return;
            }
            this.banderaTurnoJugadorB = true;
            this.logPartida = "";
            // Manejo en numero de ronda en base a los turnos jugados
            this.jugadorTurnoActual = this.jugadorTurnoActual == this.jugadores[0] ? this.jugadores[1] : this.jugadores[0];
            Carta cartaJugadorA = this.cartasJugadorA[seleccionJugadorA];
            Carta cartaJugadorB = this.cartasJugadorB[seleccionJugadorB];
            if (this.hayTrucoCantado)
            {
                this.sePuedeCantarTruco = false;
                this.logPartida += "Se canto Truco!!\n";
                if (this.estadoTruco == EstadoTruco.Querido)
                {
                    this.logPartida += "Se quiso el Truco!!\n";
                    this.valorDeRonda += 1;
                    this.estadoTruco = EstadoTruco.NoDecidio;
                }
                else if (this.estadoTruco == EstadoTruco.NoQuerido)
                {
                    this.hayGanadorDeRonda = true;
                    this.logPartida += "No se quiso el Truco!!\n";
                    this.estadoTruco = EstadoTruco.NoDecidio;
                    rondaActual = 3;
                    ChequearGanadorDeRonda();
                }
                else if (this.estadoTruco == EstadoTruco.NoDecidio)
                {
                    return;
                }
                this.hayTrucoCantado = false;
                return;
            }
            if (!this.hayGanadorDeRonda && this.estadoTruco == EstadoTruco.NoDecidio)
            {
                if (this.jugadorTurnoActual == jugadores[0])
                {
                    this.cartasEnJuegoJugadorB.Add(cartaJugadorB);
                    this.cartasJugadorB[SeleccionJugadorB].EstaEnJuego = true;
                }
                else
                {
                    this.cartasEnJuegoJugadorA.Add(cartaJugadorA);
                    this.cartasJugadorA[SeleccionJugadorA].EstaEnJuego = true;
                }
            }
            if (this.contadorTurnos < 1)
            {
                this.contadorTurnos++;
                return;
            }
            this.contadorTurnos = 0;
            // Cambio estado de las cartas en la mano
            // Evaluar quien gano la ronda...   
            this.rondaActual++;
            this.logPartida += $"Ronda: {this.rondaActual}.\n";
            foreach (Jugador jugador in this.jugadores)
            {
                this.logPartida += $"{(jugador.EsHumano ? "Elegiste" : $"{jugador.Nombre} eligio")} el {(jugador == this.jugadores[0] ? cartaJugadorA : cartaJugadorB)}.\n";
            }
            if (cartaJugadorA - cartaJugadorB > 0)
            {
                // Gana jugador A
                this.rondasGanadasJugadorA++;
                this.jugadorTurnoActual = this.jugadores[0];
                this.logPartida += $"{this.jugadores[0].Nombre} mato al {cartaJugadorB} con su {cartaJugadorA}.\n";
            }
            else if (cartaJugadorB - cartaJugadorA > 0)
            {
                // Gana jugador B
                this.rondasGanadasJugadorB++;
                this.jugadorTurnoActual = jugadores[1];
                this.logPartida += $"{this.jugadores[1].Nombre} mato al {cartaJugadorA} con su {cartaJugadorB}.\n";
            }
            else
            {
                this.logPartida += "Empate!\n";
            }

            if (this.rondaActual == 1)
            {

            }
            else if (this.rondaActual == 2)
            {
                if (this.rondasGanadasJugadorA == 2 || this.rondasGanadasJugadorB == 2)
                {
                    this.rondaActual = 3;
                }
            }
            if (this.rondaActual == 3)
            {
                // Si es ronda 3, chequear quien gano...
                ChequearGanadorDeRonda();
            }
        }

        private void ChequearGanadorDeRonda()
        {
            this.hayGanadorDeRonda = true;
            if (this.rondasGanadasJugadorA > this.rondasGanadasJugadorB)
            {
                this.logPartida += $"{this.jugadores[0].Nombre} gano la ronda. Mezclando el mazo...\n";
                this.puntajeJugadorA += this.valorDeRonda;
            }
            else
            {
                this.logPartida += $"{this.jugadores[1].Nombre} gano la ronda. Mezclando el mazo...\n";
                this.puntajeJugadorB += this.valorDeRonda;
            }
            if (this.puntajeJugadorA == 4 || this.puntajeJugadorB == 4)
            {
                this.Ganador = this.puntajeJugadorA > this.puntajeJugadorB ? this.jugadores[0] : this.jugadores[1];
                this.Ganador.CantidadVictoriasTruco++;
                if(this.Ganador == Jugadores[0])
                {
                    Jugadores[1].CantidadDerrotasTruco++;
                }
                else
                {
                    Jugadores[0].CantidadDerrotasTruco++;
                }
            }
            this.rondasGanadasJugadorA = 0;
            this.rondasGanadasJugadorB = 0;
        }
    }
}