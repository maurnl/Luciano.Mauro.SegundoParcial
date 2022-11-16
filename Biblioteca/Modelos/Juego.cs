namespace Biblioteca.Modelos
{
    /// <summary>
    /// Clase base para crear juegos. Debe implementar el método de instancia ObtenerDatosDeJuego y devolver una implementación de IDatosDeJuego
    /// que corresponda al tipo creado.
    /// </summary>
    public abstract class Juego
    {
        public abstract IDatosDeJuego<Juego> ObtenerDatosDeJuego();
    }
}
