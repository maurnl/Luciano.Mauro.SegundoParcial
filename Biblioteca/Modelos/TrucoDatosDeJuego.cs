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
            RepartirCartas();
        }

        private void RepartirCartas()
        {
            foreach (Carta carta in mazo)
            {
                carta.EstaEnJuego = false;
            }
            cartasQueSalieron.Clear();
            cartasJugadorA.Clear();
            cartasJugadorB.Clear();
            cartasEnJuegoJugadorA.Clear();
            cartasEnJuegoJugadorB.Clear();
            cartasJugadorA = ObtenerCartasAleatorias();
            cartasJugadorB = ObtenerCartasAleatorias();
            hayGanadorDeRonda = false;
            jugadorTurnoActual = jugadores[0];
            hayTrucoCantado = false;
            valorDeRonda = 1;
            estadoTruco = EstadoTruco.NoDecidio;
        }

        public void Jugar()
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
            logPartida = "";
            // Manejo en numero de ronda en base a los turnos jugados
            jugadorTurnoActual = jugadorTurnoActual == jugadores[0] ? jugadores[1] : jugadores[0];
            Carta cartaJugadorA = cartasJugadorA[seleccionJugadorA];
            Carta cartaJugadorB = cartasJugadorB[seleccionJugadorB];
            if (hayTrucoCantado)
            {
                logPartida += "Se canto Truco!!\n";
                if (estadoTruco == EstadoTruco.Querido)
                {
                    logPartida += "Se quiso el Truco!!\n";
                    valorDeRonda += 1;
                    estadoTruco = EstadoTruco.NoDecidio;
                }
                else if (estadoTruco == EstadoTruco.NoQuerido)
                {
                    hayGanadorDeRonda = true;
                    logPartida += "No se quiso el Truco!!\n";
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
                    cartasEnJuegoJugadorB.Add(cartaJugadorB);
                    cartasJugadorB[SeleccionJugadorB].EstaEnJuego = true;
                }
                else
                {
                    cartasEnJuegoJugadorA.Add(cartaJugadorA);
                    cartasJugadorA[SeleccionJugadorA].EstaEnJuego = true;
                }
            }
            if (contadorTurnos < 1)
            {
                contadorTurnos++;
                return;
            }
            contadorTurnos = 0;
            // Cambio estado de las cartas en la mano
            // Evaluar quien gano la ronda...   
            rondaActual++;
            logPartida += $"Ronda: {rondaActual}.\n";
            foreach (Jugador jugador in jugadores)
            {
                logPartida += $"{(jugador.EsHumano ? "Elegiste" : $"{jugador.Nombre} eligio")} el {(jugador == jugadores[0] ? cartaJugadorA : cartaJugadorB)}.\n";
            }
            if (cartaJugadorA - cartaJugadorB > 0)
            {
                // Gana jugador A
                rondasGanadasJugadorA++;
                jugadorTurnoActual = jugadores[0];
                logPartida += $"{jugadores[0].Nombre} mato al {cartaJugadorB} con su {cartaJugadorA}.\n";
            }
            else if (cartaJugadorB - cartaJugadorA > 0)
            {
                // Gana jugador B
                rondasGanadasJugadorB++;
                jugadorTurnoActual = jugadores[1];
                logPartida += $"{jugadores[1].Nombre} mato al {cartaJugadorA} con su {cartaJugadorB}.\n";
            }
            else
            {
                logPartida += "Empate!\n";
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
            hayGanadorDeRonda = true;
            if (rondasGanadasJugadorA > rondasGanadasJugadorB)
            {
                logPartida += $"{jugadores[0].Nombre} gano la ronda. Mezclando el mazo...\n";
                puntajeJugadorA += valorDeRonda;
            }
            else
            {
                logPartida += $"{jugadores[1].Nombre} gano la ronda. Mezclando el mazo...\n";
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