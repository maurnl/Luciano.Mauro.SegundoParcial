using Biblioteca.Modelos;
using Entidades.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Entidades
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
            this.cantidadVictoriasTruco = 0;
            this.cantidadDerrotasTruco = 0;
            this.cantidadVictoriasJanKenPon = 0;
            this.cantidadDerrotasJanKenPon = 0;
            this.esHumano = false;
        }

        public event EventHandler TurnoDeJugador;
        public event EventHandler ConfirmarTruco;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        public bool EsHumano
        {
            get
            {
                return this.esHumano;
            }
            set
            {
                this.esHumano = value;
            }
        }

        public int CantidadVictoriasTruco
        {
            get
            {
                return this.cantidadVictoriasTruco;
            }
            set
            {
                this.cantidadVictoriasTruco = value;
            }
        }
        public int CantidadDerrotasTruco
        {
            get
            {
                return this.cantidadDerrotasTruco;
            }
            set
            {
                this.cantidadDerrotasTruco = value;
            }
        }
        public int CantidadVictoriasJanKenPon
        {
            get
            {
                return this.cantidadVictoriasJanKenPon;
            }
            set
            {
                this.cantidadVictoriasJanKenPon = value;
            }
        }
        public int CantidadDerrotasJanKenPon
        {
            get
            {
                return this.cantidadDerrotasJanKenPon;
            }
            set
            {
                this.cantidadDerrotasJanKenPon = value;
            }
        }

        public virtual void JugarTurno(Juego juego)
        {
            if(juego is Truco)
            {
                TrucoDatosDeJuego datosDeJuego = (TrucoDatosDeJuego) juego.ObtenerDatosDeJuego();
                // Jugar en base al tipo de juego...
                if(this.esHumano)
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
                    }while(datosDeJuego.RondaActual<3&&(datosDeJuego.Jugadores[0] == this ? datosDeJuego.CartasJugadorA[indiceRandom].EstaEnJuego : datosDeJuego.CartasJugadorB[indiceRandom].EstaEnJuego));
                    if (datosDeJuego.HayTrucoCantado)
                    {
                        datosDeJuego.SetSeleccionTruco(this, new Random().Next(0,2) == 0);
                    }
                    datosDeJuego.SetSeleccionJugador(this, indiceRandom);
                    Thread.Sleep(800);
                }
            } else if(juego is JanKenPon)
            {
                if (this.esHumano)
                {

                }
                else
                {
                    Thread.Sleep(800);
                    JanKenPonDatosDeJuego datosDeJuego = (JanKenPonDatosDeJuego) juego.ObtenerDatosDeJuego();
                    datosDeJuego.SetSeleccionJugador(this, new Random().Next(0, 3));

                }
            }
        }
    }
}