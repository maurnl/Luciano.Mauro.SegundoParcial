using Biblioteca.Modelos;
using System;

namespace Biblioteca.Vistas
{
    public interface IVistaMenuTruco
    {
        public bool EsPartidaSimulada { get; }

        public event EventHandler OnCierreVista;
        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;
        void CrearComponentePartida(Partida<Truco> partida);
        void EliminarComponentePartida(Partida<Truco> partida);
        void AbrirComponentePartida(Partida<Truco> partida);
        void ActualizarComponentePartida(Partida<Truco> partica);
    }
}