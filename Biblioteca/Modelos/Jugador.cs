using Biblioteca.Modelos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Jugador
    {
        private int id;
        private bool esHumano;
        private string nombre;
        private string apellido;
        private int cantidadVictoriasTruco;
        private int cantidadDerrotasTruco;
        private int cantidadVictoriasJanKenPon;
        private int cantidadDerrotasJanKenPon;

        public Jugador()
        {

        }

        public Jugador(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            cantidadVictoriasTruco = 0;
            cantidadDerrotasTruco = 0;
            cantidadVictoriasJanKenPon = 0;
            cantidadDerrotasJanKenPon = 0;
            esHumano = false;
        }

        public event EventHandler TurnoDeJugador;
        public event EventHandler ConfirmarTruco;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }
        public bool EsHumano
        {
            get
            {
                return esHumano;
            }
            set
            {
                esHumano = value;
            }
        }

        public int CantidadVictoriasTruco
        {
            get
            {
                return cantidadVictoriasTruco;
            }
            set
            {
                cantidadVictoriasTruco = value;
            }
        }
        public int CantidadDerrotasTruco
        {
            get
            {
                return cantidadDerrotasTruco;
            }
            set
            {
                cantidadDerrotasTruco = value;
            }
        }
        public int CantidadVictoriasJanKenPon
        {
            get
            {
                return cantidadVictoriasJanKenPon;
            }
            set
            {
                cantidadVictoriasJanKenPon = value;
            }
        }
        public int CantidadDerrotasJanKenPon
        {
            get
            {
                return cantidadDerrotasJanKenPon;
            }
            set
            {
                cantidadDerrotasJanKenPon = value;
            }
        }

        public virtual void JugarTurno(IDatosDeJuego<Juego> datosDeJuego)
        {
            if (datosDeJuego is TrucoDatosDeJuego)
            {
                TrucoDatosDeJuego datosDeTruco = (TrucoDatosDeJuego)datosDeJuego;
                // Jugar en base al tipo de juego...
                if (esHumano)
                {
                    if (!datosDeTruco.HayGanadorDeRonda)
                    {
                        TurnoDeJugador?.Invoke(this, EventArgs.Empty);
                    }
                    if (datosDeTruco.HayTrucoCantado)
                    {
                        ConfirmarTruco?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    int indiceRandom;
                    do
                    {
                        indiceRandom = new Random().Next(0, 3);
                    } while (datosDeTruco.RondaActual < 3 && (datosDeTruco.Jugadores[0] == this ? datosDeTruco.CartasJugadorA[indiceRandom].EstaEnJuego : datosDeTruco.CartasJugadorB[indiceRandom].EstaEnJuego));
                    if (datosDeTruco.HayTrucoCantado)
                    {
                        datosDeTruco.SetSeleccionTruco(this, new Random().Next(0, 2) == 0);
                    }
                    datosDeTruco.SetSeleccionJugador(this, indiceRandom);
                    Thread.Sleep(800);
                }
            }
            else if (datosDeJuego is JanKenPonDatosDeJuego)
            {
                JanKenPonDatosDeJuego datosDeJanKenPon = (JanKenPonDatosDeJuego)datosDeJuego;
                if (esHumano)
                {

                }
                else
                {
                    Thread.Sleep(800);
                    datosDeJanKenPon.SetSeleccionJugador(this, new Random().Next(0, 3));

                }
            }
        }
    }
}