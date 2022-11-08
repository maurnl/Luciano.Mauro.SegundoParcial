using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class ManejadorPartida<T> where T : Juego, new()
    {
        private List<Partida<T>> partidasActivas;

        public ManejadorPartida()
        {
            this.partidasActivas = new List<Partida<T>>();
        }

        public List<Partida<T>> PartidasActivas
        {
            get
            {
                return this.partidasActivas;
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
            return partida;
        }
    }
}
