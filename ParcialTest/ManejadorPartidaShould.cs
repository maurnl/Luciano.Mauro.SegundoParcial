using Biblioteca.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace ParcialTest
{
    [TestClass]
    public class ManejadorPartidaShould
    {
        private ManejadorPartida manejadorPartidasTruco;

        [TestInitialize]
        public void InicializarManejador()
        {
            this.manejadorPartidasTruco = new ManejadorPartida(new Truco());
        }

        [TestMethod]
        public void NuevaPartida_Falla()
        {
            // Arrange
            Jugador jugadorUno = new Jugador("Jugador", "Uno");
            Jugador jugadorDos = null;

            // Act
            Partida partidaNula = manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos);

            // Assert
            Assert.IsNull(partidaNula);
        }

        [TestMethod]
        public void NuevaPartida_Ok()
        {
            // Arrange
            Jugador jugadorUno = new Jugador("Jugador", "Uno");
            Jugador jugadorDos = new Jugador("Jugador", "Dos");

            // Act
            Partida partidaValida = manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos);

            // Assert
            Assert.IsNotNull(partidaValida);
        }

        [TestMethod]
        public void PartidasActivas_Ok()
        {
            // Arrange 
            // Act
            List<Partida> partidas = manejadorPartidasTruco.PartidasActivas;

            // Assert
            Assert.IsNotNull(partidas);
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(3)]
        [DataRow(26)]
        [DataRow(11)]
        public void IncrementarPartidasActivas_Ok(int cantidadPartidas)
        {
            // Arrange
            Jugador jugadorUno = new Jugador("Jugador", "Uno");
            Jugador jugadorDos = new Jugador("Jugador", "Dos");

            // Act
            for (int i = 0; i < cantidadPartidas; i++)
            {
                manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos);
            }

            // Assert
            Assert.AreEqual(cantidadPartidas, manejadorPartidasTruco.CantidadPartidasActivas);
        }

        [TestMethod]
        public void CancelarTodasLasPartidas_Ok()
        {
            // Arrange
            Jugador jugadorUno = new Jugador("Jugador", "Uno");
            Jugador jugadorDos = new Jugador("Jugador", "Dos");

            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();

            // Act
            manejadorPartidasTruco.CancelarPartidasEnCurso();
            Thread.Sleep(1500);
            // Assert
            foreach (Partida partida in manejadorPartidasTruco.PartidasActivas)
            {
                if (!partida.TokenCancelacion.IsCancellationRequested)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
