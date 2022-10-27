using Biblioteca.Modelos;
using Vista;

namespace Biblioteca.Presentadores
{
    public interface IFormPrincipal : IVista
    {
        void MostrarVistaPartidas();

        void MostrarVistaJuego(IJuego juego);
    }
}
