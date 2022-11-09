using Biblioteca.Modelos;
using Biblioteca.Vistas;
using Entidades.ADO;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorMenuTruco
    {
        private IVistaMenuTruco vistaMenuTruco;
        private Jugador jugadorHumano;
        private List<Jugador> jugadoresSimulados;
        private ManejadorPartida<Truco> manejadorPartidasTruco;

        public PresentadorMenuTruco(IVistaMenuTruco vistaMenuTruco)
        {
            this.vistaMenuTruco = vistaMenuTruco;
            this.manejadorPartidasTruco = new ManejadorPartida<Truco>();
            List<Jugador> jugadoresBBDD = new JugadorADO().ObtenerListaJugadores();
            this.jugadorHumano = jugadoresBBDD[0];
            this.jugadoresSimulados = new List<Jugador>(jugadoresBBDD.GetRange(1, jugadoresBBDD.Count - 1));
            this.vistaMenuTruco.ClickeoNuevaPartida += NuevaPartida;
            this.vistaMenuTruco.ClickeoAbrirPartida += AbrirComponentePartida;
            this.vistaMenuTruco.OnCierreVista += LimpiarEventosVista;
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            Partida<Truco> partidaNueva = this.manejadorPartidasTruco.NuevaPartida(this.vistaMenuTruco.EsPartidaSimulada ? jugadoresSimulados[0] : jugadorHumano, jugadoresSimulados[1]);
            partidaNueva.NotificarDatosDeJuegoActualizados += ActualizarComponentePartida;
            partidaNueva.NotificarTerminarPartida += EliminarComponentePartida;
            this.vistaMenuTruco.CrearComponentePartida(partidaNueva);
            if (!this.vistaMenuTruco.EsPartidaSimulada)
            {
                this.vistaMenuTruco.AbrirComponentePartida(partidaNueva);
            }
            partidaNueva.JugarPartida();
        }

        private void AbrirComponentePartida(object sender, EventArgs e)
        {
            int idPartida = int.Parse((string)sender);
            foreach (Partida<Truco> partida in this.manejadorPartidasTruco.PartidasActivas)
            {
                if(partida.Id == idPartida)
                {
                    this.vistaMenuTruco.AbrirComponentePartida(partida);
                    break;
                }
            }
        }

        private void ActualizarComponentePartida(object sender, EventArgs e)
        {
            this.vistaMenuTruco.ActualizarComponentePartida((Partida<Truco>)sender);
        }

        private void EliminarComponentePartida(object sender, EventArgs e)
        {
            Partida<Truco> partida = (Partida<Truco>)sender;
            partida.NotificarDatosDeJuegoActualizados -= ActualizarComponentePartida;
            partida.NotificarTerminarPartida -= EliminarComponentePartida;
            this.vistaMenuTruco.EliminarComponentePartida((Partida<Truco>)sender);
        }

        public void LimpiarEventosVista(object sender, EventArgs e)
        {
            foreach (Partida<Truco> partida in this.manejadorPartidasTruco.PartidasActivas)
            {
                EliminarComponentePartida(partida, e);
            }
            this.manejadorPartidasTruco.CancelarPartidasEnCurso();
        }
    }
}
