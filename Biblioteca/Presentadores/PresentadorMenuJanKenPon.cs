using Biblioteca.Modelos;
using Biblioteca.Vistas;
using Biblioteca.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorMenuJanKenPon
    {
        private IVistaMenuJanKenPon vistaMenuJankenpon;
        private Jugador jugadorHumano;
        private List<Jugador> jugadoresSimulados;
        private ManejadorPartida<JanKenPon> manejadorPartidasJankenpon;

        public PresentadorMenuJanKenPon(IVistaMenuJanKenPon vistaMenuJankenpon)
        {
            this.vistaMenuJankenpon = vistaMenuJankenpon;
            this.manejadorPartidasJankenpon = new ManejadorPartida<JanKenPon>();
            List<Jugador> jugadoresBBDD = new JugadorADO().ObtenerListaJugadores();
            this.jugadorHumano = jugadoresBBDD[0];
            this.jugadoresSimulados = new List<Jugador>(jugadoresBBDD.GetRange(1, jugadoresBBDD.Count - 1));
            this.vistaMenuJankenpon.ClickeoNuevaPartida += NuevaPartida;
            this.vistaMenuJankenpon.ClickeoAbrirPartida += AbrirComponentePartida;
            this.vistaMenuJankenpon.OnCierreVista += LimpiarEventosVista;
        }

        private void NuevaPartida(object sender, EventArgs e)
        {
            Partida<JanKenPon> partidaNueva = this.manejadorPartidasJankenpon.NuevaPartida(this.vistaMenuJankenpon.EsPartidaSimulada ? jugadoresSimulados[0] : jugadorHumano, jugadoresSimulados[1]);
            if(partidaNueva is null)
            {
                return;
            }
            partidaNueva.NotificarDatosDeJuegoActualizados += ActualizarComponentePartida;
            partidaNueva.NotificarTerminarPartida += EliminarComponentePartida;
            this.vistaMenuJankenpon.CrearComponentePartida(partidaNueva);
            if (!this.vistaMenuJankenpon.EsPartidaSimulada)
            {
                this.vistaMenuJankenpon.AbrirComponentePartida(partidaNueva);
            }
            partidaNueva.JugarPartida();
        }

        private void AbrirComponentePartida(object sender, EventArgs e)
        {
            int idPartida = int.Parse((string)sender);
            foreach (Partida<JanKenPon> partida in this.manejadorPartidasJankenpon.PartidasActivas)
            {
                if (partida.Id == idPartida)
                {
                    this.vistaMenuJankenpon.AbrirComponentePartida(partida);
                    break;
                }
            }
        }

        private void ActualizarComponentePartida(object sender, EventArgs e)
        {
            this.vistaMenuJankenpon.ActualizarComponentePartida((Partida<JanKenPon>)sender);
        }

        private void EliminarComponentePartida(object sender, EventArgs e)
        {
            Partida<JanKenPon> partida = (Partida<JanKenPon>)sender;
            partida.NotificarDatosDeJuegoActualizados -= ActualizarComponentePartida;
            partida.NotificarTerminarPartida -= EliminarComponentePartida;
            this.vistaMenuJankenpon.EliminarComponentePartida(partida);
        }

        public void LimpiarEventosVista(object sender, EventArgs e)
        {
            foreach (Partida<JanKenPon> partida in this.manejadorPartidasJankenpon.PartidasActivas)
            {
                EliminarComponentePartida(partida, e);
            }
            this.manejadorPartidasJankenpon.CancelarPartidasEnCurso();
        }
    }
}
