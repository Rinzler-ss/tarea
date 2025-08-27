using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using appWeb._3.Dominio.Entidad;
using appWeb._4.Infraestructura.Data;

namespace appWeb._3.Dominio.Repositorio
{
    public class categoriaDAO
    {
        private conexionDAO conexion;

        public categoriaDAO()
        {
            conexion = new conexionDAO();
        }

        public List<Categoria> Listado()
        {
            List<Categoria> lista = new List<Categoria>();
            
            using (SqlConnection con = conexion.ObtenerConexion())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_ListarCategorias", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria()
                        {
                            Idcategoria = Convert.ToInt32(reader["Idcategoria"]),
                            Nombrecategoria = reader["Nombrecategoria"].ToString()
                        };
                        lista.Add(categoria);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar categorías: " + ex.Message);
                }
            }
            
            return lista;
        }
    }
}