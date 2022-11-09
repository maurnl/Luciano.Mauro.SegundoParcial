using Biblioteca.Modelos;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Partida<T> where T : IJuego, new()
    {
        private static int contador;
        private int id;
        private T juego;
        private Jugador jugadorA;
        private Jugador jugadorB;
        private CancellationToken tokenCancelacion;
        private CancellationTokenSource fuenteCancelacion;

        public event EventHandler TerminarPartida;
        public event EventHandler DatosDeJuegoActualizados;

        static Partida()
        {
            Partida<T>.contador = 0;
        }

        public Partida()
        {
            this.id = contador++;
            this.juego = new T();
            this.fuenteCancelacion = new CancellationTokenSource();

        }

        public CancellationToken TokenCancelacion
        {
            get
            {
                return this.tokenCancelacion;
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public Jugador JugadorA
        {
            get
            {
                return this.jugadorA;
            }
        }
        public Jugador JugadorB
        {
            get
            {
                return this.jugadorB;
            }
        }
        public int RondaActual
        {
            get
            {
                return this.juego.ObtenerDatosDeJuego().RondaActual;
            }
        }

        public T Juego
        {
            get
            {
                return this.juego;
            }
        }

        public void CancelarPartida()
        {
            this.fuenteCancelacion.Cancel();
            TerminarPartida?.Invoke(this, EventArgs.Empty);
        }

        public void JugarPartida()
        {
            this.tokenCancelacion = fuenteCancelacion.Token;
            Task tarea = new Task(() =>
            {
                IDatosDeJuego datosDeJuego = juego.ObtenerDatosDeJuego();
                datosDeJuego.Inicializar();
                while (!datosDeJuego.HayGanador)
                {
                    if (tokenCancelacion.IsCancellationRequested)
                    {
                        break;
                    }
                    datosDeJuego.JugadorTurnoActual.JugarTurno(juego);
                    datosDeJuego.Actualizar();
                    DatosDeJuegoActualizados?.Invoke(this, EventArgs.Empty);
                }
                TerminarPartida?.Invoke(this, EventArgs.Empty);
            }, tokenCancelacion);
            tarea.Start();
        }

        public void SetJugadores(Jugador jugadorA, Jugador jugadorB)
        {
            this.jugadorA = jugadorA;
            this.jugadorB = jugadorB;
            this.juego.ObtenerDatosDeJuego().Jugadores = new List<Jugador> { jugadorA, jugadorB };
        }

        public override bool Equals(object obj)
        {
            Partida<T> partida = obj as Partida<T>;
            return partida is not null && this.id == partida.id;
        }

    }
}
