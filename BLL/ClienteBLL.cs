using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(string dni, string nombre, string direccion, string telefono)
        {
            clienteDAL.InsertarCliente(dni, nombre, direccion, telefono);
        }

        public DataTable ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes();
        }
    }
}
