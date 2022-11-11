using Biblioteca.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class ManejadorPartida
    {
        private Juego juego;
        private List<Partida> partidasActivas;

        public ManejadorPartida(Juego juego)
        {
            this.juego = juego;
            this.partidasActivas = new List<Partida>();
        }

        public List<Partida> PartidasActivas
        {
            get
            {
                return this.partidasActivas;
            }
        }

        public List<PartidaTerminada> ObtenerHistorialPartidas()
        {
            List<PartidaTerminada> historialPartidas = new PartidasADO().ObtenerListaPartidasTerminadas();
            if(historialPartidas == null)
            {
                historialPartidas = new List<PartidaTerminada>();
            }
            return historialPartidas;
        }

        public void CancelarPartidasEnCurso()
        {
            foreach (Partida partida in this.partidasActivas)
            {
                partida.CancelarPartida();
            }
            Thread.Sleep(500);
        }

        public Partida NuevaPartida(Jugador jugadorA, Jugador jugadorB)
        {
            if (jugadorA == null || jugadorB == null)
            {
                return null;
            }
            Partida partida = new Partida(juego.ObtenerDatosDeJuego());
            partida.SetJugadores(jugadorA, jugadorB);
            this.partidasActivas.Add(partida);
            return partida;
        }
    }
}
