using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Presentadores
{
    public class PresentadorPrincipal
    {
        private readonly IFormPrincipal vistaPrincipal;

        public PresentadorPrincipal(IFormPrincipal vistaPrincipal)
        {
            this.vistaPrincipal = vistaPrincipal;
        }

    }
}
