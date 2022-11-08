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
        private int cantidadVictorias;

        public Jugador()
        {

        }

        public Jugador(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cantidadVictorias = 0;
            this.esHumano = false;
        }
        public delegate void PedirJugada();

        public event PedirJugada TurnoDeJugador;
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
        public int CantidadVictorias
        {
            get
            {
                return this.cantidadVictorias;
            }
            set
            {
                this.cantidadVictorias = value;
            }
        }


        public virtual void JugarTurno(IJuego juego)
        {
            if(juego is Truco truco)
            {
                TrucoDatosDeJuego datosDeJuego = (TrucoDatosDeJuego) truco.ObtenerDatosDeJuego();
                // Jugar en base al tipo de juego...
                if(this.esHumano)
                {
                    if (!datosDeJuego.HayGanadorDeRonda)
                    {
                        TurnoDeJugador?.Invoke();
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
                        //datosDeJuego.SetSeleccionTruco(this, true);
                        //datosDeJuego.SetSeleccionTruco(this, false);
                        datosDeJuego.SetSeleccionTruco(this, new Random().Next(0,2) == 0);
                    }
                    datosDeJuego.SetSeleccionJugador(this, indiceRandom);
                    Thread.Sleep(100);
                }
            }
        }
    }
}