using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace stefanini2.Modelo
{
    public class steffDbo
    {
        SqlConnection conexion = new SqlConnection();

        string mostrarError;

        public string MostrarError
        {
            get { return mostrarError; }
            set { mostrarError = value; }
        }

        public bool conectar()
        {
            bool respuesta = false;
            string cadenaconex = @"Data Source=622FLC2;Initial Catalog=AdventureWorks;User ID=sqlusuario;Password=Sqlusuario123";
            try
            {
                conexion.ConnectionString = cadenaconex;
                conexion.Open();
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                mostrarError = "Fallo al conectar con el servidor. Excepcion: " + ex.Message.ToString();
            }
            return respuesta;
        }
        public bool Registrar(String tabla, string campos, string valores)
        {
            bool respuesta = false;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "INSERT INTO Person.BusinessEntity (rowguid) VALUES (default)";
                comando.CommandText = "INSERT INTO " + tabla + "(" + campos + ") VALUES (" + valores + ");";
                if (conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mostrarError = "Excepcion: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public bool Modificar(String tabla, string campos, string condicion)
        {
            bool respuesta = false;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion + ";";
                if (conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mostrarError = "Excepcion: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
        public bool Eliminar(String tabla, string condicion)
        {
            bool respuesta = false;
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "DELETE FROM " + tabla + " WHERE BusinessEntityID=" + condicion + ";";
                if (conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mostrarError = "Excepcion: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public DataSet MostrarRegistros(string campos, string tabla, string filtro)
        {
            DataSet respuesta = new DataSet();
            try
            {
                if (filtro.Length > 0) {
                    filtro = " WHERE FirstName LIKE '%" + filtro +"%'";
                }
                string _query = "SELECT " + campos + " FROM " + tabla + filtro +";";
                SqlDataAdapter adaptador = new SqlDataAdapter(_query, conexion);
                if (conectar())
                {
                    adaptador.Fill(respuesta, tabla);
                }
            }
            catch (Exception ex)
            {
                mostrarError = "Excepcion: " + ex.Message.ToString();
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
    }
}