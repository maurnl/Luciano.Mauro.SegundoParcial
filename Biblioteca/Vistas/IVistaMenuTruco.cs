using Biblioteca.Modelos;
using Entidades.Entidades;
using System;

namespace Biblioteca.Vistas
{
    public interface IVistaMenuTruco
    {
        public bool EsPartidaSimulada { get; }

        public event EventHandler ClickeoNuevaPartida;
        void CrearComponentePartida(object sender, EventArgs e);
        void EliminarComponentePartida(object sender, EventArgs e);
    }
}