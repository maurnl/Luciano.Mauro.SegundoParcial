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
        private int cantidadVictoriasPiedraPapelTijera;
        private int cantidadDerrotasPiedraPapelTijera;

        public Jugador()
        {

        }

        public Jugador(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cantidadVictoriasTruco = 0;
            this.cantidadDerrotasTruco = 0;
            this.cantidadVictoriasPiedraPapelTijera = 0;
            this.cantidadDerrotasPiedraPapelTijera = 0;
            this.esHumano = false;
        }

        public event EventHandler TurnoDeJugador;

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
        public int CantidadVictoriasPiedraPapelTijera
        {
            get
            {
                return cantidadVictoriasPiedraPapelTijera;
            }
            set
            {
                cantidadVictoriasPiedraPapelTijera = value;
            }
        }
        public int CantidadDerrotasPiedraPapelTijera
        {
            get
            {
                return cantidadDerrotasPiedraPapelTijera;
            }
            set
            {
                cantidadDerrotasPiedraPapelTijera = value;
            }
        }

        public void JugarTurno(IDatosDeJuego<Juego> datosDeJuego)
        {
            // Jugar en base al tipo de juego...
            if (datosDeJuego is TrucoDatosDeJuego)
            {
                TrucoDatosDeJuego datosDeTruco = (TrucoDatosDeJuego)datosDeJuego;
                if (esHumano)
                {
                    if (!datosDeTruco.HayGanadorDeRonda)
                    {
                        TurnoDeJugador?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    int indiceRandom;
                    do
                    {
                        indiceRandom = new Random().Next(0, 3);
                    } while (datosDeTruco.RondaActual < 3 && (datosDeTruco.Jugadores[0] == this ? datosDeTruco.CartasJugadorA[indiceRandom].EstaEnJuego : datosDeTruco.CartasJugadorB[indiceRandom].EstaEnJuego));
                    // calculo si tiene truco
                    if (datosDeTruco.HayTrucoCantado)
                    {
                        datosDeTruco.SetSeleccionTruco(this, new Random().Next(0, 2) == 0);
                    }
                    datosDeTruco.SetSeleccionJugador(this, indiceRandom);
                    Thread.Sleep(800);
                }
            }
            else if (datosDeJuego is PiedraPapelTijeraDatosDeJuego)
            {
                PiedraPapelTijeraDatosDeJuego datosPiedraPapelTijera = (PiedraPapelTijeraDatosDeJuego)datosDeJuego;
                if (esHumano)
                {

                }
                else
                {
                    Thread.Sleep(800);
                    datosPiedraPapelTijera.SetSeleccionJugador(this, new Random().Next(0, 3));
                }
            }
        }
    }
}