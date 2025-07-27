using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace LOGIN
{
    public partial class VENTA : Form
    {
        private Empleado empleadoActivo;
        public VENTA(Empleado empleado)
        {
            InitializeComponent();
            empleadoActivo = empleado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CLIENTE menu = new CLIENTE();
            menu.Show();
        }
    }
}
