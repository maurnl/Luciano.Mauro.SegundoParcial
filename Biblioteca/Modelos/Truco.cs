using Biblioteca.Serializacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Truco : Juego
    {
        private SerializadorJson<List<Carta>> serializadorCartas;

        public Truco()
        {
            serializadorCartas = new SerializadorJson<List<Carta>>("cartas_truco.json");
        }

        public override IDatosDeJuego<Truco> ObtenerDatosDeJuego()
        {
            return new TrucoDatosDeJuego(serializadorCartas.Deserializar() ?? GenerarMazo());
        }

        private static int CalcularValorDeJuego(int numero, Palo palo)
        {
            int valorDeJuego = 0;

            if (numero <= 6 && numero >= 4)
            {
                valorDeJuego = numero - 3;
            }
            else if (numero == 7)
            {
                if (palo == Palo.Basto || palo == Palo.Copa)
                {
                    valorDeJuego = 4;
                }
                else if (palo == Palo.Oro)
                {
                    valorDeJuego = 11;
                }
                else
                {
                    valorDeJuego = 12;
                }
            }
            else if (numero >= 10 && numero <= 12)
            {
                valorDeJuego = numero - 5;
            }
            else if (numero == 1)
            {
                if (palo == Palo.Copa || palo == Palo.Oro)
                {
                    valorDeJuego = 8;
                }
                else if (palo == Palo.Basto)
                {
                    valorDeJuego = 13;
                }
                else
                {
                    valorDeJuego = 14;
                }
            }
            else if (numero >= 2 && numero <= 3)
            {
                valorDeJuego = numero + 7;
            }

            return valorDeJuego;
        }

        private List<Carta> GenerarMazo()
        {
            List<Carta> auxMazo = new List<Carta>();
            foreach (Palo palo in Enum.GetValues(typeof(Palo)))
            {
                for (int i = 1; i < 13; i++)
                {
                    if (i == 8 || i == 9)
                    {
                        continue;
                    }
                    int valorDeJuego = CalcularValorDeJuego(i, palo);
                    Carta cartaNueva = new Carta(i, palo, valorDeJuego);
                    auxMazo.Add(cartaNueva);
                }
            }
            serializadorCartas.Serializar(auxMazo);
            return auxMazo;
        }
    }
}
