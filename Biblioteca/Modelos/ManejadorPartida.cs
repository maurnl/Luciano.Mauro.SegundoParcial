using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class ManejadorPartida<T> where T : Juego, new()
    {
        private List<Partida<T>> partidasActivas;
        private CancellationTokenSource fuenteCancelacion;
        private CancellationToken tokenCancelacion;
        private Action delegadoCancelacion;

        public ManejadorPartida()
        {
            this.partidasActivas = new List<Partida<T>>();
            this.fuenteCancelacion = new CancellationTokenSource();
            this.tokenCancelacion = fuenteCancelacion.Token;
        }

        public List<Partida<T>> PartidasActivas
        {
            get
            {
                return this.partidasActivas;
            }
        }

        public async void CancelarPartidasEnCurso()
        {
            this.tokenCancelacion.Register(delegadoCancelacion);
            await Task.Run(() =>
            {
                this.tokenCancelacion.WaitHandle.WaitOne();
            });
            this.fuenteCancelacion.Cancel();
        }

        public Partida<T> NuevaPartida(Jugador jugadorA, Jugador jugadorB)
        {
            if (jugadorA == null || jugadorB == null)
            {
                return null;
            }
            Partida<T> partida = new Partida<T>();
            partida.SetJugadores(jugadorA, jugadorB);
            this.partidasActivas.Add(partida);
            delegadoCancelacion += () => partida.CancelarPartida();
            return partida;
        }
    }
}
