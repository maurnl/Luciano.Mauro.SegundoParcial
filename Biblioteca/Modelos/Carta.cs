using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Carta
    {
        private int numero;
        private Palo palo;
        private int valorDeJuego;
        private bool estaEnJuego;

        public Carta(int numero, Palo palo, int valorDeJuego)
        {
            estaEnJuego = false;
            this.numero = numero;
            this.palo = palo;
            this.valorDeJuego = valorDeJuego;
        }

        public int Numero
        {
            get
            {
                return numero;
            }
        }

        public Palo Palo
        {
            get
            {
                return palo;
            }
        }

        public bool EstaEnJuego
        {
            get
            {
                return estaEnJuego;
            }
            set
            {
                estaEnJuego = value;
            }
        }

        public static int operator -(Carta cartaA, Carta cartaB)
        {
            return cartaA.valorDeJuego - cartaB.valorDeJuego;
        }

        public override string ToString()
        {
            return $"{numero} de {palo}";
        }
    }
}
