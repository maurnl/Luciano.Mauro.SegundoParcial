using Biblioteca.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParcialTest
{
    [TestClass]
    public class PartidaShould
    {
        [TestMethod]
        public void GuardarTextoPartidaFinalizada_Ok()
        {
            // Arrange
            Truco truco = new Truco();
            TrucoDatosDeJuego datosDeJuego = (TrucoDatosDeJuego) truco.ObtenerDatosDeJuego();
            Jugador jugadorUno = new Jugador("Nombre", "Apellido");
            Jugador jugadorDos = new Jugador("OtroNombre", "OtroApellido");
            string logPartidaTerminada = "";
            Action<Partida> guardarPartida = (partida) => logPartidaTerminada += datosDeJuego.LogPartidaCompleto;
            Partida partida = new Partida(datosDeJuego, jugadorDos, jugadorUno, guardarPartida);

            // Act
            partida.JugarPartida();

            Thread.Sleep(4000);
            Console.WriteLine("Esperando a jugar turnos...");
            partida.CancelarPartida();
            Console.WriteLine("Partida cancelada.");
            Thread.Sleep(1000);

            // Assert
            Console.WriteLine("********Log partida**********");
            Console.WriteLine(datosDeJuego.LogPartidaCompleto);
            Console.WriteLine("*********esperado************");

            Assert.AreEqual(logPartidaTerminada, datosDeJuego.LogPartidaCompleto);
        }
    }
}
