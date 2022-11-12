using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class PiedraPapelTijera : Juego
    {
        private PiedraPapelTijeraDatosDeJuego datosDeJuego;

        public PiedraPapelTijera()
        {
            this.datosDeJuego = new PiedraPapelTijeraDatosDeJuego();
        }

        public override IDatosDeJuego<PiedraPapelTijera> ObtenerDatosDeJuego()
        {
            return this.datosDeJuego;
        }
    }
}
