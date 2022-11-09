using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class JanKenPon : Juego
    {
        private JanKenPonDatosDeJuego datosDeJuego;

        public JanKenPon()
        {
            this.datosDeJuego = new JanKenPonDatosDeJuego();
        }

        public override IDatosDeJuego<JanKenPon> ObtenerDatosDeJuego()
        {
            return this.datosDeJuego;
        }
    }
}
