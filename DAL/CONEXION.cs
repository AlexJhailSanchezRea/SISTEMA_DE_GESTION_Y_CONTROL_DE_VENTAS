using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAL
{
    public class CONEXION
    {
        // Cadena de conexión a la base de datos.
        private string connectionString = @"SERVER=localhost;DATABASE=BEATIFUL;Integrated Security=true";
        // Nota: Si tienes problemas con la conexión, también puedes probar con:
        // "SERVER=(local);DATABASE=BEATIFUL;Integrated Security=true"


        // Método para abrir la conexión a la base de datos.
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
