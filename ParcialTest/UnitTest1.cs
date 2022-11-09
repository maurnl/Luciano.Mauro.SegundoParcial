using Biblioteca.Presentadores;
using Biblioteca.Vistas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParcialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VistaDeMentira vistaDeMentira = new VistaDeMentira();
            PresentadorPrincipal presentador = new PresentadorPrincipal(vistaDeMentira);

        }
    }

    public class VistaDeMentira : IVisaPrincipal
    {
        public void MostrarMenuTruco()
        {
            throw new System.NotImplementedException();
        }
    }
}
