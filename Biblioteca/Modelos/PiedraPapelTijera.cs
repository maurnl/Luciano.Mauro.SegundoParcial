using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class PiedraPapelTijera : Juego
    {
        public PiedraPapelTijera()
        {

        }

        public override IDatosDeJuego<PiedraPapelTijera> ObtenerDatosDeJuego()
        {
            return new PiedraPapelTijeraDatosDeJuego();
        }
    }
}
