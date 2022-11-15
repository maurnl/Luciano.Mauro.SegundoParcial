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

        private Action<Partida> delegadoGuardarPartida;

        public event EventHandler NotificarTerminarPartida;
        public event EventHandler NotificarDatosDeJuegoActualizados;

        static Partida()
        {
            contador = 0;
        }

        /// <summary>
        /// Para construir una partida se requiere una implementación de IDatosDeJuego, dos entidades Jugador y un delegado
        /// de tipo Action<Partida>. Sin reglas de juego, dos jugadores y una forma de guardar la partida no se podrá crear
        /// una instancia de Partida.
        /// </summary>
        /// <param name="datosDeJuego">Datos/Reglas del juego</param>
        /// <param name="jugadorA">Jugador uno</param>
        /// <param name="jugadorB">Jugador dos</param>
        /// <param name="delegadoGuardarPartida">Delegado output de la partida</param>
        public Partida(IDatosDeJuego<Juego> datosDeJuego, Jugador jugadorA, Jugador jugadorB, Action<Partida> delegadoGuardarPartida)
        {
            this.id = contador++;
            this.delegadoGuardarPartida = delegadoGuardarPartida;
            this.fuenteCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = fuenteCancelacion.Token;
            this.taskPartida = new Task(() =>
            {
                BucleDelJuego(tokenCancelacion);
                this.delegadoGuardarPartida?.Invoke(this);
                this.NotificarTerminarPartida?.Invoke(this, EventArgs.Empty);
            }, tokenCancelacion);
            this.datosDeJuego = datosDeJuego;
            this.jugadorA = jugadorA;
            this.jugadorB = jugadorB;
            this.datosDeJuego.Jugadores = new List<Jugador> { jugadorA, jugadorB };
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
        }

        public void JugarPartida()
        {
            taskPartida.Start();
        }

        private void BucleDelJuego(CancellationToken tokenCancelacion)
        {
            this.datosDeJuego.Inicializar();
            while (!this.datosDeJuego.HayGanador)
            {
                this.datosDeJuego.JugadorTurnoActual.JugarTurno(this.datosDeJuego);
                this.datosDeJuego.Jugar();
                this.NotificarDatosDeJuegoActualizados?.Invoke(this, EventArgs.Empty);
                if (tokenCancelacion.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Partida partida = obj as Partida;
            return partida is not null && id == partida.id;
        }

    }
}
