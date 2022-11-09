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
    public class Partida<T> where T : Juego, new()
    {
        private static int contador;
        private int id;
        private T juego;
        private Jugador jugadorA;
        private Jugador jugadorB;
        private CancellationToken tokenCancelacion;
        private CancellationTokenSource fuenteCancelacion;
        private Task taskPartida;
        private bool partidaTerminada;

        public event EventHandler NotificarTerminarPartida;
        public event EventHandler NotificarDatosDeJuegoActualizados;

        static Partida()
        {
            Partida<T>.contador = 0;
        }

        public Partida()
        {
            this.id = contador++;
            this.juego = new T();
            this.fuenteCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = fuenteCancelacion.Token;
            this.partidaTerminada = false;
            this.taskPartida = new Task(() =>  BucleDelJuego(this.tokenCancelacion), this.tokenCancelacion);
        }

        public Task TareaPartida
        {
            get
            {
                return this.taskPartida;
            }
        }

        public bool PartidaTerminada
        {
            get
            {
                return this.partidaTerminada;
            }
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
            this.fuenteCancelacion.CancelAfter(0);
            while (!this.partidaTerminada);
        }

        public void JugarPartida()
        {
            this.taskPartida.Start();
            this.partidaTerminada = true;
        }

        private void BucleDelJuego(CancellationToken tokenCancelacion)
        {
            IDatosDeJuego<Juego> datosDeJuego = juego.ObtenerDatosDeJuego();
            datosDeJuego.Inicializar();
            while (!datosDeJuego.HayGanador && !tokenCancelacion.IsCancellationRequested)
            {
                datosDeJuego.JugadorTurnoActual.JugarTurno(juego);
                datosDeJuego.Actualizar();
                NotificarDatosDeJuegoActualizados?.Invoke(this, EventArgs.Empty);
            }
            NotificarTerminarPartida?.Invoke(this, EventArgs.Empty);
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
