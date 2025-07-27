using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL
{
    public class EmpleadoBLL
    {
        private EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public Empleado IniciarSesion(string usuario, string contrasena)
        {
            return empleadoDAL.ValidarCredenciales(usuario, contrasena);
        }

        public void InsertarEmpleado(string dni, string nombre, string direccion, string telefono, string tipoEmpleadoId, string usuario, string contrasena)
        {
            empleadoDAL.InsertarEmpleado(dni, nombre, direccion, telefono, tipoEmpleadoId, usuario, contrasena);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return empleadoDAL.ObtenerEmpleados();
        }

        public void ActualizarEmpleado(string dni, string nombre, string direccion, string telefono, string tipoEmpleadoId, string usuario, string contrasena)
        {
            empleadoDAL.ActualizarEmpleado(dni, nombre, direccion, telefono, tipoEmpleadoId, usuario, contrasena);
        }


        public List<Empleado> BuscarEmpleados(string criterioBusqueda)
        {
            EmpleadoDAL empleadoDAL = new EmpleadoDAL();
            return empleadoDAL.BuscarEmpleados(criterioBusqueda);
        }


    }
}
