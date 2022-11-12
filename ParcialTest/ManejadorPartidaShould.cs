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
        public void DevolverPartidaNulaEnJugadorNulo()
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
        public void DevolverPartidaNoNulaEnJugadoresValidos()
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
        public void TenerUnaListaNoNula()
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
        public void AgregarPartidaEnListaPartidas(int cantidadPartidas)
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
            Assert.AreEqual(cantidadPartidas, manejadorPartidasTruco.PartidasActivas.Count);
        }

        [TestMethod]
        public void CancelarTodasLasPartidasEnCurso()
        {
            // Arrange
            Jugador jugadorUno = new Jugador("Jugador", "Uno");
            Jugador jugadorDos = new Jugador("Jugador", "Dos");

            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
            manejadorPartidasTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();

            // Act
            manejadorPartidasTruco.CancelarPartidasEnCurso();

            // Assert
            foreach (Partida partida in manejadorPartidasTruco.PartidasActivas)
            {
                if (!partida.PartidaTerminada)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
