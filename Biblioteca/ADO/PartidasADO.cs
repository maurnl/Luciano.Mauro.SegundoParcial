using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Data.SqlClient;
using System.Data;
using Biblioteca.Modelos;

namespace Biblioteca.ADO
{
    public class PartidasADO
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static PartidasADO()
        {
            cadena_conexion = @"Server=DESKTOP-A0OU09N\SQLEXPRESS;Database=Parcial_Db;Trusted_Connection=True;Encrypt=False";
        }

        public PartidasADO()
        {
            // CREO UN OBJETO SQLCONECTION
            conexion = new SqlConnection(cadena_conexion);
        }

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        public List<PartidaTerminada> ObtenerListaPartidasTerminadas(string juego)
        {
            List<PartidaTerminada> lista = new List<PartidaTerminada>();

            try
            {
                comando = new SqlCommand();

                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT h.id, j.nombre, j2.nombre, h.rondaJugadas, h.juego " +
                    "FROM dbo.HistorialPartidas AS h " +
                    "JOIN dbo.Jugadores AS j ON h.idJugadorGanador = j.id " +
                    "JOIN dbo.Jugadores AS j2 ON h.idJugadorPerdedor = j2.id " +
                    "WHERE h.juego = @juego";

                comando.Parameters.AddWithValue("@juego", juego);

                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    PartidaTerminada item = new PartidaTerminada();

                    item.IdPartida = lector.GetInt32(0);
                    item.NombreGanador = lector.GetString(1);
                    item.NombrePerdedor = lector.GetString(2);
                    item.RondasJugadas = lector.GetInt32(3);
                    item.NombreJuego = lector.GetString(4);

                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return lista;
        }

        public bool AgregarPartidaTerminada(Partida param)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO dbo.HistorialPartidas (idPartida, idJugadorGanador, idJugadorPerdedor, rondaJugadas, juego) " +
                    "VALUES(@idPartida, @idJugadorGanador, @idJugadorPerdedor, @rondaJugadas, @juego)";

                comando = new SqlCommand();

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("@idPartida", param.Id);
                comando.Parameters.AddWithValue("@idJugadorGanador", param.DatosDeJuego.Ganador.Id);
                comando.Parameters.AddWithValue("@idJugadorPerdedor", param.DatosDeJuego.Ganador == param.DatosDeJuego.Jugadores[0] ? param.DatosDeJuego.Jugadores[0].Id : param.DatosDeJuego.Jugadores[1].Id);
                comando.Parameters.AddWithValue("@rondaJugadas", param.RondaActual);
                comando.Parameters.AddWithValue("@juego", param.Juego);

                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }
    }
}
