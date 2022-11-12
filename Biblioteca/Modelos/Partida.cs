using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Partida
    {
        private static int contador;
        private int id;
        private IDatosDeJuego<Juego> datosDeJuego;
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

        public Partida(IDatosDeJuego<Juego> datosDeJuego) 
        {
            this.id = contador++;
            this.fuenteCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = fuenteCancelacion.Token;
            this.partidaTerminada = false;
            this.taskPartida = new Task(() => BucleDelJuego(tokenCancelacion), tokenCancelacion);
            this.datosDeJuego = datosDeJuego;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
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
                return this.datosDeJuego.RondaActual;
            }
        }

        public IDatosDeJuego<Juego> DatosDeJuego
        {
            get
            {
                return this.datosDeJuego;
            }
        }

        public string Juego
        {
            get
            {
                string retorno = "Desconocido";
                if(this.datosDeJuego is PiedraPapelTijeraDatosDeJuego)
                {
                    retorno = "PiedraPapelTijera";
                }
                else
                {
                    if(this.datosDeJuego is TrucoDatosDeJuego)
                    {
                        retorno = "Truco";
                    }
                }
                return retorno;
            }
        }

        public void CancelarPartida()
        {
            this.fuenteCancelacion.CancelAfter(0);
            this.datosDeJuego.Ganador = this.datosDeJuego.JugadorTurnoActual;
            while (!this.partidaTerminada) ;
        }

        public void JugarPartida()
        {
            taskPartida.Start();
            this.partidaTerminada = true;
        }

        private void BucleDelJuego(CancellationToken tokenCancelacion)
        {
            this.datosDeJuego.Inicializar();
            while (!this.datosDeJuego.HayGanador && !tokenCancelacion.IsCancellationRequested)
            {
                this.datosDeJuego.JugadorTurnoActual.JugarTurno(this.datosDeJuego);
                this.datosDeJuego.Actualizar();
                this.NotificarDatosDeJuegoActualizados?.Invoke(this, EventArgs.Empty);
            }
            this.NotificarTerminarPartida?.Invoke(this, EventArgs.Empty);
        }

        public void SetJugadores(Jugador jugadorA, Jugador jugadorB)
        {
            this.jugadorA = jugadorA;
            this.jugadorB = jugadorB;
            this.datosDeJuego.Jugadores = new List<Jugador> { jugadorA, jugadorB };
        }

        public override bool Equals(object obj)
        {
            Partida partida = obj as Partida;
            return partida is not null && id == partida.id;
        }

    }
}
