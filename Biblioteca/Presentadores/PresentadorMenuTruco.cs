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
        private ManejadorPartida<Truco> manejadorPartidaTruco;
        private List<Partida<Truco>> partidasTrucoActivas;

        public PresentadorMenuTruco(IVistaMenuTruco vistaMenuTruco)
        {
            this.partidasTrucoActivas = new List<Partida<Truco>>();
            this.vistaMenuTruco = vistaMenuTruco;
            this.manejadorPartidaTruco = new ManejadorPartida<Truco>();
            List<Jugador> jugadoresBBDD = new JugadorADO().ObtenerListaJugadores();
            this.jugadorHumano = jugadoresBBDD[0];
            this.jugadoresSimulados = new List<Jugador>(jugadoresBBDD.GetRange(1, jugadoresBBDD.Count - 1));
            this.vistaMenuTruco.ClickeoNuevaPartida += NuevaPartida;
            this.vistaMenuTruco.ClickeoAbrirPartida += AbrirComponentePartida;
        }

        private async void NuevaPartida(object sender, EventArgs e)
        {
            Partida<Truco> partidaNueva = this.manejadorPartidaTruco.NuevaPartida(this.vistaMenuTruco.EsPartidaSimulada ? jugadoresSimulados[0] : jugadorHumano, jugadoresSimulados[1]);
            //partida.DatosDeJuegoActualizados += ActualizarDatosBoton;
            partidaNueva.TerminarPartida += EliminarComponentePartida;
            this.vistaMenuTruco.CrearComponentePartida(partidaNueva);
            this.vistaMenuTruco.AbrirComponentePartida(partidaNueva);
            this.partidasTrucoActivas.Add(partidaNueva);
            await partidaNueva.JugarPartida();
        }

        private void AbrirComponentePartida(object sender, EventArgs e)
        {
            int idPartida = int.Parse((string)sender);
            foreach (Partida<Truco> partida in this.partidasTrucoActivas)
            {
                if(partida.Id == idPartida)
                {
                    this.vistaMenuTruco.AbrirComponentePartida(partida);
                    break;
                }
            }
        }

        private void EliminarComponentePartida(object sender, EventArgs e)
        {
            this.vistaMenuTruco.EliminarComponentePartida((Partida<Truco>)sender);
        }
    }
}
