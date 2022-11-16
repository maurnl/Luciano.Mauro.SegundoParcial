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
        private Action delegadoCancelaciones;
        private List<Partida> partidasActivas;
        private int cantidadPartidasActivas;

        /// <summary>
        /// Clase manejadora de entidades Partida. Recibe un tipo de Juego y lo usará para crear instancias a partir de Juego que implementen
        /// IDatosDeJuego y correspondan al juego en cuestión. 
        /// </summary>
        /// <param name="juego">Tipo de juego del que se crearán partidas.</param>
        public ManejadorPartida(Juego juego)
        {
            this.juego = juego;
            this.partidasActivas = new List<Partida>();
        }

        public int CantidadPartidasActivas
        {
            get
            {
                return this.cantidadPartidasActivas;
            }
        }

        public List<Partida> PartidasActivas
        {
            get
            {
                return this.partidasActivas;
            }
        }

        private void GuardarPartidaFinalizada(Partida sender)
        {
            JugadorADO jugadorAdo = new JugadorADO();
            Partida partidaDelEvento = sender;
            new PartidasADO().AgregarPartidaTerminada(partidaDelEvento);
            jugadorAdo.ModificarJugador(partidaDelEvento.JugadorA);
            jugadorAdo.ModificarJugador(partidaDelEvento.JugadorB);
            this.cantidadPartidasActivas--;
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
            this.cantidadPartidasActivas = 0;
            delegadoCancelaciones?.Invoke();
            Thread.Sleep(1500);
        }

        public Partida NuevaPartida(Jugador jugadorA, Jugador jugadorB)
        {
            if (jugadorA == null || jugadorB == null)
            {
                return null;
            }
            Partida partida = new Partida(juego.ObtenerDatosDeJuego(), jugadorA, jugadorB, GuardarPartidaFinalizada);
            this.partidasActivas.Add(partida);
            this.delegadoCancelaciones += () => partida.CancelarPartida();
            this.cantidadPartidasActivas++;
            return partida;
        }
    }
}
