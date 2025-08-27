using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appWeb._4.Infraestructura.Data
{
    public class conexionDAO
    {
        private string cadenaConexion;

        public conexionDAO()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}