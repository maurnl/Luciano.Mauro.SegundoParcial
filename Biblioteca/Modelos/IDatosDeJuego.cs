using System.Collections.Generic;
using System.Threading;

namespace Biblioteca.Modelos
{
    public interface IDatosDeJuego<out T> where T : Juego
    {
        List<Jugador> Jugadores { get; set; }
        bool HayGanador { get; }
        bool HayGanadorDeRonda { get; }
        Jugador JugadorTurnoActual { get; }
        Jugador Ganador { get; set; }
        int RondaActual { get; }
        void Inicializar();
        void Actualizar();
    }
}