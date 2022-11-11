//using Biblioteca.Modelos;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Threading;

//namespace ParcialTest
//{
//    [TestClass]
//    public class ManejadorPartidaShould
//    {
//        [TestMethod]
//        public void DevolverPartidaNulaEnJugadorNulo()
//        {
//            // Given
//            ManejadorPartida<Truco> manejadorPartidaTruco = new ManejadorPartida<Truco>();
//            Jugador jugadorUno = new Jugador("Jugador", "Uno");
//            Jugador jugadorDos = null;

//            // When
//            Partida<Truco> partidaNula = manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos);

//            // Then
//            Assert.IsNull(partidaNula);
//        }

//        [TestMethod]
//        public void DevolverPartidaNoNulaEnJugadoresValidos()
//        {
//            // Given
//            ManejadorPartida<Truco> manejadorPartidaTruco = new ManejadorPartida<Truco>();
//            Jugador jugadorUno = new Jugador("Jugador", "Uno");
//            Jugador jugadorDos = new Jugador("Jugador", "Dos");

//            // When
//            Partida<Truco> partidaValida = manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos);

//            // Then
//            Assert.IsNotNull(partidaValida);
//        }

//        [TestMethod]
//        public void TenerUnaListaNoNula()
//        {
//            // Given 
//            ManejadorPartida<Truco> manejadorPartidaTruco = new ManejadorPartida<Truco>();

//            // When
//            List<Partida<Truco>> partidas = manejadorPartidaTruco.PartidasActivas;

//            // Then
//            Assert.IsNotNull(partidas);
//        }

//        [TestMethod]
//        [DataRow(10)]
//        [DataRow(3)]
//        [DataRow(26)]
//        [DataRow(11)]
//        public void AgregarPartidaEnListaPartidas(int cantidadPartidas)
//        {
//            // Given
//            ManejadorPartida<Truco> manejadorPartidaTruco = new ManejadorPartida<Truco>();
//            Jugador jugadorUno = new Jugador("Jugador", "Uno");
//            Jugador jugadorDos = new Jugador("Jugador", "Dos");

//            // When
//            for (int i = 0; i < cantidadPartidas; i++)
//            {
//                manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos);
//            }

//            // Then
//            Assert.AreEqual(cantidadPartidas, manejadorPartidaTruco.PartidasActivas.Count);
//        }

//        [TestMethod]
//        public void CancelarTodasLasPartidasEnCurso()
//        {
//            // Given
//            ManejadorPartida<Truco> manejadorPartidaTruco = new ManejadorPartida<Truco>();

//            Jugador jugadorUno = new Jugador("Jugador", "Uno");
//            Jugador jugadorDos = new Jugador("Jugador", "Dos");

//            manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
//            //manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
//            //manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();
//            //manejadorPartidaTruco.NuevaPartida(jugadorUno, jugadorDos).JugarPartida();

//            // When
//            manejadorPartidaTruco.CancelarPartidasEnCurso();

//            // Then
//            foreach (Partida<Truco> partida in manejadorPartidaTruco.PartidasActivas)
//            {
//                if (!partida.PartidaTerminada)
//                {
//                    Assert.Fail();
//                }
//            }
//        }
//    }
//}
