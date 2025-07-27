using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAL
{
    public class VehiculoDAL : CONEXION
    {
        public void InsertarVehiculo(string marca, string modelo, int anio, decimal precio, int cantidad)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Inserta en la tabla AUTO_NUEVO
                    string queryAuto = "INSERT INTO AUTO_NUEVO (marca, modelo, anio, precio) OUTPUT INSERTED.id VALUES (@marca, @modelo, @anio, @precio)";
                    SqlCommand cmdAuto = new SqlCommand(queryAuto, connection, transaction);
                    cmdAuto.Parameters.AddWithValue("@marca", marca);
                    cmdAuto.Parameters.AddWithValue("@modelo", modelo);
                    cmdAuto.Parameters.AddWithValue("@anio", anio);
                    cmdAuto.Parameters.AddWithValue("@precio", precio);
                    int autoId = (int)cmdAuto.ExecuteScalar(); // Obtiene el ID del vehículo recién insertado

                    // Inserta en la tabla STOCK
                    string queryStock = "INSERT INTO STOCK (auto_id, cantidad) VALUES (@autoId, @cantidad)";
                    SqlCommand cmdStock = new SqlCommand(queryStock, connection, transaction);
                    cmdStock.Parameters.AddWithValue("@autoId", autoId);
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdStock.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public void ActualizarVehiculo(int id, string marca, string modelo, int anio, decimal precio, int cantidad)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Actualiza los datos del vehículo en la tabla AUTO_NUEVO
                    string queryAuto = "UPDATE AUTO_NUEVO SET marca = @marca, modelo = @modelo, anio = @anio, precio = @precio WHERE id = @id";
                    SqlCommand cmdAuto = new SqlCommand(queryAuto, connection, transaction);
                    cmdAuto.Parameters.AddWithValue("@marca", marca);
                    cmdAuto.Parameters.AddWithValue("@modelo", modelo);
                    cmdAuto.Parameters.AddWithValue("@anio", anio);
                    cmdAuto.Parameters.AddWithValue("@precio", precio);
                    cmdAuto.Parameters.AddWithValue("@id", id);
                    cmdAuto.ExecuteNonQuery();

                    // Actualiza la cantidad en el stock en la tabla STOCK
                    string queryStock = "UPDATE STOCK SET cantidad = @cantidad WHERE auto_id = @id";
                    SqlCommand cmdStock = new SqlCommand(queryStock, connection, transaction);
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdStock.Parameters.AddWithValue("@id", id);
                    cmdStock.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public DataTable ObtenerVehiculos()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT a.id, a.marca, a.modelo, a.anio, a.precio, s.cantidad 
                             FROM AUTO_NUEVO a
                             JOIN STOCK s ON a.id = s.auto_id";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

    }
}
