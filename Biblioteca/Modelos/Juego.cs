using Entidades.Interfaces;

namespace Biblioteca.Modelos
{
    public abstract class Juego
    {
        public abstract IDatosDeJuego<Juego> ObtenerDatosDeJuego();
    }
}
