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

        private void GuardarPartidaFinalizada(object sender, EventArgs e)
        {
            Partida partidaDelEvento = (Partida)sender;
            new PartidasADO().AgregarPartidaTerminada(partidaDelEvento);
        }

        public List<PartidaTerminada> ObtenerHistorialPartidas(string nombreJuego)
        {
            List<PartidaTerminada> historialPartidas = new PartidasADO().ObtenerListaPartidasTerminadas(nombreJuego);
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
            Thread.Sleep(1500);
        }

        public Partida NuevaPartida(Jugador jugadorA, Jugador jugadorB)
        {
            if (jugadorA == null || jugadorB == null)
            {
                return null;
            }
            Partida partida = new Partida(juego.ObtenerDatosDeJuego());
            partida.SetJugadores(jugadorA, jugadorB);
            partida.NotificarTerminarPartida += GuardarPartidaFinalizada;
            this.partidasActivas.Add(partida);
            return partida;
        }
    }
}
