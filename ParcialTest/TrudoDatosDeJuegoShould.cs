using Biblioteca.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ParcialTest
{
    [TestClass]
    public class TrucoDatosDeJuegoShould
    {
        private Truco truco;
        private TrucoDatosDeJuego datosDeTruco;

        [TestInitialize]
        public void Inicializar()
        {
            this.truco = new Truco();
            this.datosDeTruco = (TrucoDatosDeJuego)this.truco.ObtenerDatosDeJuego();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void SetearSeleccionDelJugadorCorrectamente(int seleccion)
        {
            // Arrange
            Jugador jugador = new Jugador("Jugador", "Prueba");
            
            List<Jugador> jugadores = new List<Jugador>();
            jugadores.Add(jugador);
            this.datosDeTruco.Jugadores = jugadores;

            // Act
            this.datosDeTruco.SetSeleccionJugador(jugador, seleccion);

            // Assert
            Assert.AreEqual(seleccion, this.datosDeTruco.SeleccionJugadorA);
        }
    }
}
