using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using appWeb._3.Dominio.Entidad;
using appWeb._4.Infraestructura.Data;

namespace appWeb._4.Infraestructura.Repositorio
{
    public class herramientaDAO
    {
        private conexionDAO conexion;

        public herramientaDAO()
        {
            conexion = new conexionDAO();
        }

        public List<Herramienta> Listado()
        {
            List<Herramienta> lista = new List<Herramienta>();
            
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarHerramientas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Herramienta herramienta = new Herramienta()
                        {
                            idHer = reader["idHer"].ToString(),
                            desHer = reader["desHer"].ToString(),
                            medHer = reader["medHer"].ToString(),
                            idcategoria = Convert.ToInt32(reader["idcategoria"]),
                            Nombrecategoria = reader["Nombrecategoria"].ToString(),
                            preUni = Convert.ToDecimal(reader["preUni"]),
                            stock = Convert.ToInt32(reader["stock"])
                        };
                        lista.Add(herramienta);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar herramientas: " + ex.Message);
                }
            }
            
            return lista;
        }

        public Herramienta BuscarPorId(string idHer)
        {
            Herramienta herramienta = null;
            
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_BuscarHerramientaPorId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHer", idHer);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        herramienta = new Herramienta()
                        {
                            idHer = reader["idHer"].ToString(),
                            desHer = reader["desHer"].ToString(),
                            medHer = reader["medHer"].ToString(),
                            idcategoria = Convert.ToInt32(reader["idcategoria"]),
                            Nombrecategoria = reader["Nombrecategoria"].ToString(),
                            preUni = Convert.ToDecimal(reader["preUni"]),
                            stock = Convert.ToInt32(reader["stock"])
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar herramienta: " + ex.Message);
                }
            }
            
            return herramienta;
        }

        public bool Agregar(Herramienta herramienta)
        {
            bool resultado = false;
            
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_AgregarHerramienta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@idHer", herramienta.idHer);
                    cmd.Parameters.AddWithValue("@desHer", herramienta.desHer);
                    cmd.Parameters.AddWithValue("@medHer", herramienta.medHer);
                    cmd.Parameters.AddWithValue("@idcategoria", herramienta.idcategoria);
                    cmd.Parameters.AddWithValue("@preUni", herramienta.preUni);
                    cmd.Parameters.AddWithValue("@stock", herramienta.stock);
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar herramienta: " + ex.Message);
                }
            }
            
            return resultado;
        }

        public bool Actualizar(Herramienta herramienta)
        {
            bool resultado = false;
            
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarHerramienta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@idHer", herramienta.idHer);
                    cmd.Parameters.AddWithValue("@desHer", herramienta.desHer);
                    cmd.Parameters.AddWithValue("@medHer", herramienta.medHer);
                    cmd.Parameters.AddWithValue("@idcategoria", herramienta.idcategoria);
                    cmd.Parameters.AddWithValue("@preUni", herramienta.preUni);
                    cmd.Parameters.AddWithValue("@stock", herramienta.stock);
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar herramienta: " + ex.Message);
                }
            }
            
            return resultado;
        }
    }
}