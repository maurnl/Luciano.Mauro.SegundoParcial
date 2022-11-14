using Biblioteca.Modelos;
using Biblioteca.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorMenuJuego
    {
        private IPresentadorMenuJuego vistaMenuJuego;
        private ManejadorPartida manejadorPartidas;
        private Jugador jugadorHumano;
        private List<Jugador> jugadoresSimulados;
        private Juego juego;

        public PresentadorMenuJuego(IPresentadorMenuJuego vistaMenuJankenpon, Juego juego, IDatosJugadores jugadoresAdo)
        {
            this.juego = juego;
            this.vistaMenuJuego = vistaMenuJankenpon;
            this.manejadorPartidas = new ManejadorPartida(this.juego);
            List<Jugador> jugadoresBBDD = jugadoresAdo.ObtenerListaJugadores();
            this.jugadorHumano = jugadoresBBDD[0];
            this.jugadoresSimulados = new List<Jugador>(jugadoresBBDD.GetRange(1, jugadoresBBDD.Count - 1));
            this.vistaMenuJuego.ClickeoNuevaPartida += NuevaPartida;
            this.vistaMenuJuego.ClickeoAbrirPartida += AbrirComponentePartida;
            this.vistaMenuJuego.ClickeoMostrarHistorialPartidas += MostrarHistorialPartidas;
            this.vistaMenuJuego.OnCierreVista += LimpiarEventosVista;
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            Random random = new Random();
            int indiceRandomUno = random.Next(0, jugadoresSimulados.Count);
            int indiceRandomDos;
            do
            {
                indiceRandomDos = random.Next(0, jugadoresSimulados.Count);
            } while (indiceRandomDos == indiceRandomUno);
            Partida partidaNueva = this.manejadorPartidas.NuevaPartida(this.vistaMenuJuego.EsPartidaSimulada ? jugadoresSimulados[indiceRandomUno] : jugadorHumano, jugadoresSimulados[indiceRandomDos]);
            if(partidaNueva is null)
            {
                return;
            }
            partidaNueva.NotificarDatosDeJuegoActualizados += ActualizarComponentePartida;
            partidaNueva.NotificarTerminarPartida += EliminarComponentePartida;
            this.vistaMenuJuego.CrearComponentePartida(partidaNueva);
            if (!this.vistaMenuJuego.EsPartidaSimulada)
            {
                this.vistaMenuJuego.AbrirComponentePartida(partidaNueva);
            }
            partidaNueva.JugarPartida();
        }

        private void AbrirComponentePartida(object sender, EventArgs e)
        {
            int idPartida = int.Parse((string)sender);
            foreach (Partida partida in this.manejadorPartidas.PartidasActivas)
            {
                if (partida.Id == idPartida)
                {
                    this.vistaMenuJuego.AbrirComponentePartida(partida);
                    break;
                }
            }
        }

        private void ActualizarComponentePartida(object sender, EventArgs e)
        {
            this.vistaMenuJuego.ActualizarComponentePartida((Partida)sender);
        }

        private void EliminarComponentePartida(object sender, EventArgs e)
        {
            Partida partida = (Partida)sender;
            partida.NotificarDatosDeJuegoActualizados -= ActualizarComponentePartida;
            partida.NotificarTerminarPartida -= EliminarComponentePartida;
            this.vistaMenuJuego.EliminarComponentePartida(partida);
        }

        private void MostrarHistorialPartidas(object sender, EventArgs e)
        {
            string nombreJuego = this.juego.GetType().Name;
            List<PartidaTerminada> historialPartidas = this.manejadorPartidas.ObtenerHistorialPartidas(nombreJuego);
            this.vistaMenuJuego.MostrarHistorialPartidas(historialPartidas, nombreJuego);
        }

        public void LimpiarEventosVista(object sender, EventArgs e)
        {
            foreach (Partida partida in this.manejadorPartidas.PartidasActivas)
            {
                EliminarComponentePartida(partida, e);
            }
            this.manejadorPartidas.CancelarPartidasEnCurso();
        }
    }
}
