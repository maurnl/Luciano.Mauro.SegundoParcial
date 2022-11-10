using Entidades.Interfaces;
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

        public virtual void JugarTurno(Juego juego)
        {
            if (juego is Truco)
            {
                TrucoDatosDeJuego datosDeJuego = (TrucoDatosDeJuego)juego.ObtenerDatosDeJuego();
                // Jugar en base al tipo de juego...
                if (esHumano)
                {
                    if (!datosDeJuego.HayGanadorDeRonda)
                    {
                        TurnoDeJugador?.Invoke(this, EventArgs.Empty);
                    }
                    if (datosDeJuego.HayTrucoCantado)
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
                    } while (datosDeJuego.RondaActual < 3 && (datosDeJuego.Jugadores[0] == this ? datosDeJuego.CartasJugadorA[indiceRandom].EstaEnJuego : datosDeJuego.CartasJugadorB[indiceRandom].EstaEnJuego));
                    if (datosDeJuego.HayTrucoCantado)
                    {
                        datosDeJuego.SetSeleccionTruco(this, new Random().Next(0, 2) == 0);
                    }
                    datosDeJuego.SetSeleccionJugador(this, indiceRandom);
                    Thread.Sleep(800);
                }
            }
            else if (juego is JanKenPon)
            {
                if (esHumano)
                {

                }
                else
                {
                    Thread.Sleep(800);
                    JanKenPonDatosDeJuego datosDeJuego = (JanKenPonDatosDeJuego)juego.ObtenerDatosDeJuego();
                    datosDeJuego.SetSeleccionJugador(this, new Random().Next(0, 3));

                }
            }
        }
    }
}