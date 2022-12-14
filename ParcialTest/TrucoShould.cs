using Biblioteca.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTest
{
    [TestClass]
    public class TrucoShould
    {
        [TestMethod]
        public void ObtenerDatosDeJuegoRetornaTipo_Ok()
        {
            // Arrange
            Truco truco = new Truco();

            // Act
            IDatosDeJuego<Juego> datosDeJuego = truco.ObtenerDatosDeJuego();

            // Assert
            Assert.IsInstanceOfType(datosDeJuego, typeof(IDatosDeJuego<Truco>));
        }

        [TestMethod]
        public void ObtenerDatosDeJuegoRetornaTipo_Falla()
        {
            // Arrange
            Truco truco = new Truco();

            // Act
            IDatosDeJuego<Juego> datosDeJuego = truco.ObtenerDatosDeJuego();

            // Assert
            Assert.IsNotInstanceOfType(datosDeJuego, typeof(IDatosDeJuego<PiedraPapelTijera>));
        }

        [TestMethod]
        public void ObtenerDatosDeJuegoNuevos_Ok()
        {
            // Arrange
            Truco truco = new Truco();

            // Act
            IDatosDeJuego<Truco> datosDeJuegoUno = truco.ObtenerDatosDeJuego();
            IDatosDeJuego<Truco> datosDeJuegoDos = truco.ObtenerDatosDeJuego();

            // Assert
            Assert.AreNotEqual(datosDeJuegoUno, datosDeJuegoDos);
        }

    }
}
