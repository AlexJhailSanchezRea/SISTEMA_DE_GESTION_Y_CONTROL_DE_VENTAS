using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
   public class ClienteDAL : CONEXION
    {
         public void InsertarCliente(string dni, string nombre, string direccion, string telefono)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Cliente (ci, nombre, direccion, telefono) VALUES (@ci, @nombre, @direccion, @telefono)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ci", dni);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.ExecuteNonQuery();
                }
            }
            public DataTable ObtenerClientes()
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ci, nombre, direccion, telefono FROM Cliente";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable clientes = new DataTable();
                    adapter.Fill(clientes);
                    return clientes;
                }
            }


    }
    
}
