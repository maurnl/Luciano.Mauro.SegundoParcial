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
    public class PartidasADOShould
    {
        [TestMethod]
        public void ConectarALaBaseDeDatos_Ok()
        {
            // Arrange
            PartidasADO partidasAdo = new PartidasADO();

            // Act
            bool conexionExitosa = partidasAdo.ProbarConexion();

            // Assert
            Assert.IsTrue(conexionExitosa);
        }
    }
}
