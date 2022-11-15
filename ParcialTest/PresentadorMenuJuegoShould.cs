using Biblioteca.Modelos;
using Biblioteca.Presentadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTest
{
    [TestClass]
    public class PresentadorMenuJuegoShould
    {
        // o.o
        private PresentadorMenuJuego presentadorMenuJuego;
        private VistaMock vistaMock;
        private AdoMock adoMock;

        [TestInitialize]
        public void Inicializar()
        {
            Truco truco = new Truco();
            this.adoMock = new AdoMock();
            this.vistaMock = new VistaMock();
            this.presentadorMenuJuego = new PresentadorMenuJuego(this.vistaMock, truco, this.adoMock);
        }

        [TestMethod]
        [DataRow("abrir")]
        [DataRow("mostrar")]
        [DataRow("nueva")]
        public void ResponderEventosDeLaVista(string evento)
        {
            switch (evento)
            {
                case "abrir":
                    this.vistaMock.ClickAbrirPartida();
                    if (!this.vistaMock.EventoAbrirOk)
                    {
                        Assert.Fail();
                    }
                    break;
                case "mostrar":
                    this.vistaMock.ClickMostrarHistorial();
                    if (!this.vistaMock.EventoMostrarOk)
                    {
                        Assert.Fail();
                    }
                    break;
                case "nueva":
                    this.vistaMock.ClickNuevaPartida();
                    if (!this.vistaMock.EventoCrearOk)
                    {
                        Assert.Fail();
                    }
                    break;
            }
        }

        [TestMethod]
        public void 
    }

    internal class AdoMock : IDatosJugadores
    {
        public List<Jugador> ObtenerListaJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();
            jugadores.Add(new Jugador("Nombre", "Apellido"));
            jugadores.Add(new Jugador("Nombre", "Apellido"));
            jugadores.Add(new Jugador("Nombre", "Apellido"));
            jugadores.Add(new Jugador("Nombre", "Apellido"));
            jugadores.Add(new Jugador("Nombre", "Apellido"));
            return jugadores;
        }
    }

    internal class VistaMock : IPresentadorMenuJuego
    {
        public bool EsPartidaSimulada => true;
        public bool EventoAbrirOk  { get; set; }
        public bool EventoActualizarOk { get; set; }
        public bool EventoCrearOk { get; set; }
        public bool EventorEliminarOk { get; set; }
        public bool EventoMostrarOk { get; set; }
        public int CantidadPartidas { get; set; }

        public event EventHandler OnCierreVista;
        public event EventHandler ClickeoNuevaPartida;
        public event EventHandler ClickeoAbrirPartida;
        public event EventHandler ClickeoMostrarHistorialPartidas;

        public void ClickNuevaPartida()
        {
            ClickeoNuevaPartida?.Invoke(this, EventArgs.Empty);
        }

        public void ClickAbrirPartida()
        {
            ClickeoAbrirPartida?.Invoke("0", EventArgs.Empty);
        }

        public void ClickMostrarHistorial()
        {
            ClickeoMostrarHistorialPartidas?.Invoke(this, EventArgs.Empty);
        }

        public void AbrirComponentePartida(Partida partida)
        {
            EventoAbrirOk = true;
        }
        public void CrearComponentePartida(Partida partida)
        {
            EventoCrearOk = true;
        }
        public void MostrarHistorialPartidas(List<PartidaTerminada> historialPartidas, string juego)
        {
            EventoMostrarOk = true;
        }

        public void ActualizarComponentePartida(Partida partica)
        {
        }


        public void EliminarComponentePartida(Partida partida)
        {
        }

        public void MostrarCantidadPartidas(int cantidadPartidas)
        {
            this.CantidadPartidas = cantidadPartidas;
        }
    }
}
