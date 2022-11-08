﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades.Entidades;
using System.Reflection;

namespace Entidades.ADO
{
    public class JugadorADO
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static JugadorADO()
        {
            cadena_conexion = @"Server=DESKTOP-A0OU09N\SQLEXPRESS;Database=Parcial_Db;Trusted_Connection=True;";
        }

        public JugadorADO()
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

        public List<Jugador> ObtenerListaJugadores()
        {
            List<Jugador> lista = new List<Jugador>();

            try
            {
                comando = new SqlCommand();

                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM dbo.Jugadores";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Jugador item = new Jugador();

                    item.Id = lector.GetInt32(0);
                    item.EsHumano = lector.GetBoolean(1);
                    item.Nombre = lector.GetString(2);
                    item.Apellido = lector.GetString(3);
                    item.CantidadVictorias = lector.GetInt32(4);

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

        public bool AgregarJugador(Jugador param)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO dbo.Jugadores (id, esHumano, nombre, apellido, cantidadVictorias) " +
                    "VALUES(@id, @esHumano, @nombre, @apellido, @cantidadVictorias)";

                comando = new SqlCommand();

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("@id", param.Id);
                comando.Parameters.AddWithValue("@esHumano", param.EsHumano);
                comando.Parameters.AddWithValue("@nombre", param.Nombre);
                comando.Parameters.AddWithValue("@apellido", param.Apellido);
                comando.Parameters.AddWithValue("@cantidadVictorias", param.CantidadVictorias);
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

        public bool ModificarJugador(Jugador param)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@id", param.Id);
                comando.Parameters.AddWithValue("@esHumano", param.EsHumano);
                comando.Parameters.AddWithValue("@nombre", param.Nombre);
                comando.Parameters.AddWithValue("@apellido", param.Apellido);
                comando.Parameters.AddWithValue("@cantidadVictorias", param.CantidadVictorias);

                string sql = "UPDATE dbo.Jugadores ";
                sql += "SET esHumano = @esHumano, nombre = @nombre, apellido = @apellido, cantidadVictorias = @cantidadVictorias";
                sql += "WHERE id = @id";

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

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
        public bool EliminarJugador(int id)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();
                string sql = "DELETE FROM dbo.Jugadores WHERE id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

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
    }
}
