using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
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
            contador = 0;
        }

        public Partida()
        {
            id = contador++;
            juego = new T();
            fuenteCancelacion = new CancellationTokenSource();
            tokenCancelacion = fuenteCancelacion.Token;
            partidaTerminada = false;
            taskPartida = new Task(() => BucleDelJuego(tokenCancelacion), tokenCancelacion);
        }

        public Task TareaPartida
        {
            get
            {
                return taskPartida;
            }
        }

        public bool PartidaTerminada
        {
            get
            {
                return partidaTerminada;
            }
        }

        public CancellationToken TokenCancelacion
        {
            get
            {
                return tokenCancelacion;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }

        public Jugador JugadorA
        {
            get
            {
                return jugadorA;
            }
        }
        public Jugador JugadorB
        {
            get
            {
                return jugadorB;
            }
        }
        public int RondaActual
        {
            get
            {
                return juego.ObtenerDatosDeJuego().RondaActual;
            }
        }

        public T Juego
        {
            get
            {
                return juego;
            }
        }

        public void CancelarPartida()
        {
            fuenteCancelacion.CancelAfter(0);
            while (!partidaTerminada) ;
        }

        public void JugarPartida()
        {
            taskPartida.Start();
            partidaTerminada = true;
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
            juego.ObtenerDatosDeJuego().Jugadores = new List<Jugador> { jugadorA, jugadorB };
        }

        public override bool Equals(object obj)
        {
            Partida<T> partida = obj as Partida<T>;
            return partida is not null && id == partida.id;
        }

    }
}
