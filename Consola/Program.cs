using Biblioteca.Modelos;
using Biblioteca.Presentadores;
using Biblioteca.Vistas;
using Entidades.Entidades;
using System;

namespace Consola
{
    public class Vista : IVistaMenuTruco
    {
        public bool EsPartidaSimulada => throw new NotImplementedException();

        public event EventHandler ClickeoNuevaPartida;

        public void AbrirComponentePartida(Partida<Truco> partida)
        {
            throw new NotImplementedException();
        }

        public void CrearComponentePartida(Partida<Truco> partida)
        {
            throw new NotImplementedException();
        }

        public void EliminarComponentePartida(Partida<Truco> partida)
        {
            throw new NotImplementedException();
        }
    }
    public class Program : IVistaMenuTruco
    {
        public bool EsPartidaSimulada => false;

        public event EventHandler ClickeoNuevaPartida;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PresentadorMenuTruco presentadorTruco = new PresentadorMenuTruco(this);
            ClickeoNuevaPartida?.Invoke(this, EventArgs.Empty);
            Console.ReadKey();
        }

        public void AbrirComponentePartida(Partida<Truco> partida)
        {
            return;
        }

        public void CrearComponentePartida(Partida<Truco> partida)
        {
            Console.WriteLine($"Nueva partida: Ronda - {partida.RondaActual} - Jugadores: {partida.JugadorA} vs {partida.JugadorB}");
        }

        public void EliminarComponentePartida(Partida<Truco> partida)
        {
            throw new NotImplementedException();
        }
    }
}
