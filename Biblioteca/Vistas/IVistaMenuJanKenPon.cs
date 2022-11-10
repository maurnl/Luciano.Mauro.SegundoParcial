using Biblioteca.Modelos;
using System;

namespace Biblioteca.Vistas
{
    public interface IVistaMenuJanKenPon
    {
        public bool EsPartidaSimulada { get; }

        public event EventHandler OnCierreVista;
        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;

        void CrearComponentePartida(Partida<JanKenPon> partida);
        void EliminarComponentePartida(Partida<JanKenPon> partida);
        void AbrirComponentePartida(Partida<JanKenPon> partida);
        void ActualizarComponentePartida(Partida<JanKenPon> partica);
    }
}
