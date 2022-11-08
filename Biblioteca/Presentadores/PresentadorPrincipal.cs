using Biblioteca.Modelos;
using Biblioteca.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorPrincipal : IVisaPrincipal
    {
        private readonly IVisaPrincipal vistaPrincipal;

        public PresentadorPrincipal(IVisaPrincipal vistaPrincipal)
        {
            this.vistaPrincipal = vistaPrincipal;
        }

        public void MostrarMenuTruco()
        {
            vistaPrincipal.MostrarMenuTruco();
        }
    }
}
