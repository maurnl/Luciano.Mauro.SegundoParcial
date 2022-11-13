using Biblioteca.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ParcialTest
{
    [TestClass]
    public class TrudoDatosDeJuegoShould
    {
        private delegate List<Carta> TrudoDatosDeJuegoDelegate();
        private Truco truco;
        private TrucoDatosDeJuego datosDeTruco;

        [TestInitialize]
        public void Inicializar()
        {
            this.truco = new Truco();
            this.datosDeTruco = (TrucoDatosDeJuego)this.truco.ObtenerDatosDeJuego();
        }
    }
}
