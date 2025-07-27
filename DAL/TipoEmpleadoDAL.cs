using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
   public class TipoEmpleadoDAL : CONEXION
    {
        public List<KeyValuePair<string, string>> ObtenerTiposDeEmpleado()
        {
            List<KeyValuePair<string, string>> tiposDeEmpleado = new List<KeyValuePair<string, string>>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT id, descripcion FROM TIPO_EMPLEADO";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tiposDeEmpleado.Add(new KeyValuePair<string, string>(reader["id"].ToString(), reader["descripcion"].ToString()));
                }
            }
            return tiposDeEmpleado;
        }
    }
}
