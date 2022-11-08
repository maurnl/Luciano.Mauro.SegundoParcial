using Entidades.Interfaces;

namespace Biblioteca.Modelos
{
    public abstract class Juego : IJuego
    {
        public abstract IDatosDeJuego ObtenerDatosDeJuego();
    }
}
