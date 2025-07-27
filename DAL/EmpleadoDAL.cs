using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class EmpleadoDAL : CONEXION
    {
        public Empleado ValidarCredenciales(string usuario, string contrasena)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT dni, tipo_empleado_id FROM EMPLEADO WHERE usuario = @usuario AND contrasena = @contrasena";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Empleado
                    {
                        DNI = reader["dni"].ToString(),
                        TipoEmpleadoId = reader["tipo_empleado_id"].ToString() // Usa TipoEmpleadoId en lugar de TipoEmpleado
                    };
                }
                return null; // Retorna null si las credenciales son incorrectas
            }
        }


        public void InsertarEmpleado(string dni, string nombre, string direccion, string telefono, string tipoEmpleadoId, string usuario, string contrasena)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Inserta en la tabla PERSONA
                    string queryPersona = "INSERT INTO PERSONA (dni, nombre, direccion, telefono) VALUES (@dni, @nombre, @direccion, @telefono)";
                    SqlCommand cmdPersona = new SqlCommand(queryPersona, connection, transaction);
                    cmdPersona.Parameters.AddWithValue("@dni", dni);
                    cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                    cmdPersona.Parameters.AddWithValue("@direccion", direccion);
                    cmdPersona.Parameters.AddWithValue("@telefono", telefono);
                    cmdPersona.ExecuteNonQuery();

                    // Inserta en la tabla EMPLEADO
                    string queryEmpleado = "INSERT INTO EMPLEADO (dni, tipo_empleado_id, usuario, contrasena) VALUES (@dni, @tipoEmpleadoId, @usuario, @contrasena)";
                    SqlCommand cmdEmpleado = new SqlCommand(queryEmpleado, connection, transaction);
                    cmdEmpleado.Parameters.AddWithValue("@dni", dni);
                    cmdEmpleado.Parameters.AddWithValue("@tipoEmpleadoId", tipoEmpleadoId);
                    cmdEmpleado.Parameters.AddWithValue("@usuario", usuario);
                    cmdEmpleado.Parameters.AddWithValue("@contrasena", contrasena);
                    cmdEmpleado.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT p.dni, p.nombre, p.direccion, p.telefono, e.tipo_empleado_id, e.usuario, e.contrasena 
                                 FROM PERSONA p
                                 JOIN EMPLEADO e ON p.dni = e.dni";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado
                    {
                        DNI = reader["dni"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        TipoEmpleadoId = reader["tipo_empleado_id"].ToString(),
                        Usuario = reader["usuario"].ToString(),
                        Contrasena = reader["contrasena"].ToString()
                    };
                    empleados.Add(empleado);
                }
            }
            return empleados;
        }

        public void ActualizarEmpleado(string dni, string nombre, string direccion, string telefono, string tipoEmpleadoId, string usuario, string contrasena)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Actualizar en la tabla PERSONA
                    string queryPersona = "UPDATE PERSONA SET nombre = @nombre, direccion = @direccion, telefono = @telefono WHERE dni = @dni";
                    SqlCommand cmdPersona = new SqlCommand(queryPersona, connection, transaction);
                    cmdPersona.Parameters.AddWithValue("@dni", dni);
                    cmdPersona.Parameters.AddWithValue("@nombre", nombre);
                    cmdPersona.Parameters.AddWithValue("@direccion", direccion);
                    cmdPersona.Parameters.AddWithValue("@telefono", telefono);
                    cmdPersona.ExecuteNonQuery();

                    // Actualizar en la tabla EMPLEADO
                    string queryEmpleado = "UPDATE EMPLEADO SET tipo_empleado_id = @tipoEmpleadoId, usuario = @usuario, contrasena = @contrasena WHERE dni = @dni";
                    SqlCommand cmdEmpleado = new SqlCommand(queryEmpleado, connection, transaction);
                    cmdEmpleado.Parameters.AddWithValue("@dni", dni);
                    cmdEmpleado.Parameters.AddWithValue("@tipoEmpleadoId", tipoEmpleadoId);
                    cmdEmpleado.Parameters.AddWithValue("@usuario", usuario);
                    cmdEmpleado.Parameters.AddWithValue("@contrasena", contrasena);
                    cmdEmpleado.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        public List<Empleado> BuscarEmpleados(string criterioBusqueda)
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT p.dni, p.nombre, p.direccion, p.telefono, e.tipo_empleado_id, e.usuario, e.contrasena 
                         FROM PERSONA p
                         JOIN EMPLEADO e ON p.dni = e.dni
                         WHERE p.dni LIKE @criterio OR p.nombre LIKE @criterio";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@criterio", "%" + criterioBusqueda + "%");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado
                    {
                        DNI = reader["dni"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        TipoEmpleadoId = reader["tipo_empleado_id"].ToString(),
                        Usuario = reader["usuario"].ToString(),
                        Contrasena = reader["contrasena"].ToString()
                    };
                    empleados.Add(empleado);
                }
            }
            return empleados;
        }

    }
    public class Empleado
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TipoEmpleadoId { get; set; } // ID del tipo de empleado
        public string TipoEmpleado { get; set; }   // Descripción del tipo de empleado
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
