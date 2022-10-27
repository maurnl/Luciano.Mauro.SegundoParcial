using Biblioteca.Modelos;
using System;

namespace Biblioteca.Presentadores
{
    public interface IFormPrincipal : IVista
    {
        void MostrarVistaPartidas();

        void MostrarVistaJuego(IJuego juego);
    }
}
