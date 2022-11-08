using Entidades.Interfaces;
using System;
using System.Collections.Generic;

namespace Entidades.Entidades
{
    public class TrucoDatosDeJuego : IDatosDeJuego
    {
        private static Random random;
        private bool banderaTurnoJugadorB;
        private readonly List<Carta> mazo;
        private List<Carta> cartasQueSalieron;
        private bool hayGanador;
        private bool hayGanadorDeRonda;
        private bool hayTrucoCantado;
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

        static TrucoDatosDeJuego()
        {
            TrucoDatosDeJuego.random = new Random();
        }

        public TrucoDatosDeJuego(List<Carta> mazo)
        {
            this.logPartida = "";
            this.cartasQueSalieron = new List<Carta>();
            this.mazo = mazo;
            this.contadorTurnos = 0;
            this.rondaActual = 0;
            this.rondasGanadasJugadorA = 0;
            this.rondasGanadasJugadorB = 0;
            this.puntajeJugadorA = 0;
            this.puntajeJugadorB = 0;
            this.hayGanador = false;
            this.cartasJugadorA = new List<Carta>();
            this.cartasJugadorB = new List<Carta>();
            this.cartasEnJuegoJugadorA = new List<Carta>();
            this.cartasEnJuegoJugadorB = new List<Carta>();
            this.banderaTurnoJugadorB = true;
            this.hayGanadorDeRonda = false;
            this.hayTrucoCantado = false;
            this.estadoTruco = EstadoTruco.NoDecidio;
            this.valorDeRonda = 1;
        }

        public Jugador JugadorTurnoActual
        {
            get
            {
                return this.jugadorTurnoActual;
            }
        }

        public List<Carta> CartasJugadorA
        {
            get
            {
                return this.cartasJugadorA;
            }
        }

        public List<Carta> CartasEnJuegoJugadorA
        {
            get
            {
                return this.cartasEnJuegoJugadorA;
            }
        }

        public List<Carta> CartasJugadorB
        {
            get
            {
                return this.cartasJugadorB;
            }
        }

        public List<Carta> CartasEnJuegoJugadorB
        {
            get
            {
                return this.cartasEnJuegoJugadorB;
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

        public bool HayGanadorDeRonda
        {
            get
            {
                return this.hayGanadorDeRonda;
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

        public bool HayTrucoCantado
        {
            get
            {
                return this.hayTrucoCantado;
            }
            set
            {
                this.hayTrucoCantado = value;
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

        public string LogPartida
        {
            get
            {
                return this.logPartida;
            }
        }

        public void SetSeleccionJugador(Jugador jugador, int seleccion)
        {
            if (hayTrucoCantado && estadoTruco == EstadoTruco.NoDecidio)
            {
                return;
            }
            if (jugador.Equals(this.jugadores[0]))
            {
                this.seleccionJugadorA = seleccion;
            }
            else if (jugador.Equals(this.jugadores[1]))
            {
                this.seleccionJugadorB = seleccion;
            }
        }

        public void SetSeleccionTruco(Jugador jugador, bool seleccion)
        {
            this.estadoTruco = seleccion ? EstadoTruco.Querido : EstadoTruco.NoQuerido;
            if (estadoTruco == EstadoTruco.NoQuerido)
            {
                if (jugador.Equals(this.jugadores[0]))
                {
                    rondasGanadasJugadorB++;
                }
                else if (jugador.Equals(this.jugadores[1]))
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
                    cartaRandom = this.mazo[indiceRandom];
                } while (cartasQueSalieron.Contains(cartaRandom));
                this.cartasQueSalieron.Add(cartaRandom);
                cartasRetorno.Add(cartaRandom);
            }
            return cartasRetorno;
        }

        public void Inicializar()
        {
            RepartirCartas();
        }

        private void RepartirCartas()
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
            this.jugadorTurnoActual = this.jugadores[0];
            this.hayTrucoCantado = false;
            this.valorDeRonda = 1;
            this.estadoTruco = EstadoTruco.NoDecidio;
        }

        public void Actualizar()
        {
            if (rondaActual == 3)
            {
                if (banderaTurnoJugadorB)
                {
                    banderaTurnoJugadorB = false;
                    return;
                }
                rondaActual = 0;
                RepartirCartas();
                return;
            }
            banderaTurnoJugadorB = true;
            this.logPartida = "";
            // Manejo en numero de ronda en base a los turnos jugados
            this.jugadorTurnoActual = jugadorTurnoActual == jugadores[0] ? jugadores[1] : jugadores[0];
            Carta cartaJugadorA = cartasJugadorA[seleccionJugadorA];
            Carta cartaJugadorB = cartasJugadorB[seleccionJugadorB];
            if (hayTrucoCantado)
            {
                this.logPartida += "Se canto Truco!!\n";
                if (estadoTruco == EstadoTruco.Querido)
                {
                    this.logPartida += "Se quiso el Truco!!\n";
                    valorDeRonda += 1;
                    estadoTruco = EstadoTruco.NoDecidio;
                }
                else if (estadoTruco == EstadoTruco.NoQuerido)
                {
                    hayGanadorDeRonda = true;
                    this.logPartida += "No se quiso el Truco!!\n";
                    estadoTruco = EstadoTruco.NoDecidio;
                    rondaActual = 3;
                    ChequearGanadorDeRonda();
                }
                else if (estadoTruco == EstadoTruco.NoDecidio)
                {
                    return;
                }
                hayTrucoCantado = false;
                return;
            }
            //if (hayEnvidoCantado)
            //{
            //    this.logPartida += "Se canto Envido!!\n";
            //    if (estadoTruco == EstadoTruco.Querido)
            //    {
            //        this.logPartida += "Se quiso el Envido!!\n";
            //        valorDeRonda += 1;
            //        estadoTruco = EstadoTruco.NoDecidio;
            //    }
            //    else if (estadoTruco == EstadoTruco.NoQuerido)
            //    {
            //        hayGanadorDeRonda = true;
            //        this.logPartida += "No se quiso el Envido!!\n";
            //        estadoTruco = EstadoTruco.NoDecidio;
            //        if(JugadorTurnoActual == jugadores[0])
            //        {
            //            puntajeJugadorB++;
            //        } else
            //        {
            //            puntajeJugadorA++;
            //        }
            //        //rondaActual = 3;
            //        // sumarle un punto al contrario
            //        //ChequearGanadorDeRonda();
            //    }
            //    else if (estadoTruco == EstadoTruco.NoDecidio)
            //    {
            //        return;
            //    }
            //    hayTrucoCantado = false;
            //    return;
            //}
            if (!hayGanadorDeRonda && estadoTruco == EstadoTruco.NoDecidio)
            {
                if (jugadorTurnoActual == jugadores[0])
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
            if (contadorTurnos < 1)
            {
                this.contadorTurnos++;
                return;
            }
            contadorTurnos = 0;
            // Cambio estado de las cartas en la mano
            // Evaluar quien gano la ronda...   
            rondaActual++;
            this.logPartida += $"Ronda: {rondaActual}.\n";
            foreach (Jugador jugador in jugadores)
            {
                this.logPartida += $"{(jugador.EsHumano ? "Elegiste" : $"{jugador.Nombre} eligio")} el {(jugador == jugadores[0] ? cartaJugadorA : cartaJugadorB)}.\n";
            }
            if (cartaJugadorA - cartaJugadorB > 0)
            {
                // Gana jugador A
                rondasGanadasJugadorA++;
                jugadorTurnoActual = jugadores[0];
                this.logPartida += $"{jugadores[0].Nombre} mato al {cartaJugadorB} con su {cartaJugadorA}.\n";
            }
            else if (cartaJugadorB - cartaJugadorA > 0)
            {
                // Gana jugador B
                rondasGanadasJugadorB++;
                jugadorTurnoActual = jugadores[1];
                this.logPartida += $"{jugadores[1].Nombre} mato al {cartaJugadorA} con su {cartaJugadorB}.\n";
            }
            else
            {
                this.logPartida += "Empate!\n";
            }

            if (rondaActual == 1)
            {

            }
            else if (rondaActual == 2)
            {
                if (rondasGanadasJugadorA == 2 || rondasGanadasJugadorB == 2)
                {
                    rondaActual = 3;
                }
            }
            if (rondaActual == 3)
            {
                // Si es ronda 3, chequear quien gano...
                ChequearGanadorDeRonda();
            }
        }

        private void ChequearGanadorDeRonda()
        {
            this.hayGanadorDeRonda = true;
            if (rondasGanadasJugadorA > rondasGanadasJugadorB)
            {
                this.logPartida += $"{jugadores[0].Nombre} gano la ronda. Mezclando el mazo...\n";
                puntajeJugadorA += valorDeRonda;
            }
            else
            {
                this.logPartida += $"{jugadores[1].Nombre} gano la ronda. Mezclando el mazo...\n";
                puntajeJugadorB += valorDeRonda;
            }
            if (puntajeJugadorA == 4 || puntajeJugadorB == 4)
            {
                Ganador = puntajeJugadorA > puntajeJugadorB ? jugadores[0] : jugadores[1];
            }
            rondasGanadasJugadorA = 0;
            rondasGanadasJugadorB = 0;
        }
    }
}