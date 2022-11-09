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
        private List<Task> tasksPartidas;

        public ManejadorPartida()
        {
            this.partidasActivas = new List<Partida<T>>();
            this.tasksPartidas = new List<Task>();
        }

        public List<Partida<T>> PartidasActivas
        {
            get
            {
                return this.partidasActivas;
            }
        }

        public void CancelarPartidasEnCurso()
        {
            foreach (Partida<T> partida in this.partidasActivas)
            {
                partida.CancelarPartida();
            }
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
            this.tasksPartidas.Add(partida.TareaPartida);
            return partida;
        }
    }
}
