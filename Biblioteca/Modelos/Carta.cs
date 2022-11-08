using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Carta
    {
        private int numero;
        private Palo palo;
        private int valorDeJuego;
        private bool estaEnJuego;

        public Carta(int numero, Palo palo, int valorDeJuego)
        {
            this.estaEnJuego = false;
            this.numero = numero;
            this.palo = palo;
            this.valorDeJuego = valorDeJuego;
        }

        public int Numero
        {
            get
            {
                return this.numero;
            }
        }

        public Palo Palo
        {
            get
            {
                return this.palo;
            }
        }
        
        public bool EstaEnJuego
        {
            get
            {
                return this.estaEnJuego;
            }
            set
            {
                this.estaEnJuego = value;
            }
        }

        public static int operator -(Carta cartaA, Carta cartaB)
        {
            return cartaA.valorDeJuego - cartaB.valorDeJuego;
        }

        public override string ToString()
        {
            return $"{this.numero} de {this.palo}";
        }
    }
}
