using Biblioteca.ADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialTest
{
    [TestClass]
    public class JugadorADOShould
    {
        [TestMethod]
        public void ConectarALaBaseDeDatos()
        {
            // Arrange
            JugadorADO jugadorAdo = new JugadorADO();

            // Act
            bool conexionExitosa = jugadorAdo.ProbarConexion();

            // Assert
            Assert.IsTrue(conexionExitosa);
        }
    }
}
