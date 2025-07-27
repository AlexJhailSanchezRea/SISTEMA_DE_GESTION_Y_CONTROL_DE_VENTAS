using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class VehiculoBLL
    {
        private VehiculoDAL vehiculoDAL = new VehiculoDAL();

        public void InsertarVehiculo(string marca, string modelo, int anio, decimal precio, int cantidad)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            vehiculoDAL.InsertarVehiculo(marca, modelo, anio, precio, cantidad);
        }


        public void ActualizarVehiculo(int id, string marca, string modelo, int anio, decimal precio, int cantidad)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            vehiculoDAL.ActualizarVehiculo(id, marca, modelo, anio, precio, cantidad);
        }

        public DataTable ObtenerVehiculos()
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            return vehiculoDAL.ObtenerVehiculos();
        }

    }
}
