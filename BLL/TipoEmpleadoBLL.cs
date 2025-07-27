using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoEmpleadoBLL
    {
        private TipoEmpleadoDAL tipoEmpleadoDAL = new TipoEmpleadoDAL();

        public List<KeyValuePair<string, string>> ObtenerTiposDeEmpleado()
        {
            return tipoEmpleadoDAL.ObtenerTiposDeEmpleado();
        }
    }
}
