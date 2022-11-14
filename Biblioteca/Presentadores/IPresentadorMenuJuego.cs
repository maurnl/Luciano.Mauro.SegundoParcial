using Biblioteca.Modelos;
using System;
using System.Collections.Generic;

namespace Biblioteca.Presentadores
{
    public interface IPresentadorMenuJuego
    {
        public bool EsPartidaSimulada { get; }

        public event EventHandler OnCierreVista;
        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;
        public event EventHandler ClickeoMostrarHistorialPartidas;

        void CrearComponentePartida(Partida partida);
        void EliminarComponentePartida(Partida partida);
        void AbrirComponentePartida(Partida partida);
        void ActualizarComponentePartida(Partida partica);
        void MostrarHistorialPartidas(List<PartidaTerminada> historialPartidas, string juego);
    }
}
