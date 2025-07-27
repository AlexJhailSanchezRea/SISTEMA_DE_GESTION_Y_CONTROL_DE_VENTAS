using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DAL;

namespace LOGIN
{
    public partial class MENU : Form
    {
        private Empleado empleadoActivo;
        public MENU(Empleado empleado)
        {
            InitializeComponent();
            empleadoActivo = empleado;
            label3.Text = $"Empleado Activo: {empleadoActivo.DNI} - {empleadoActivo.TipoEmpleadoId}"; // Mostrar el empleado en el menú
        }

        //**movimiento de formulario//
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //**moviento de formulario//

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //********************------MOVIMIENTO DE CADA HERRAMIENTO CON EL EVENTO MOUSE DOWN---------*******
        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuGradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MENU_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //***************************TERMINAR DEL MOVIMIENTO DE MOUSEDOWN**********
        //TIEMPO REAL + FECHA ADEACUDO A LA HRA DE BOLIVIA
        private void timer1_Tick(object sender, EventArgs e)
        {
    
            label2.Text = DateTime.Now.ToLongDateString();
        }
        //--------------------------------------------------------------------------
        //-------APLICACION PARA ABRIR LOS FORMULARIOS------------------------
        private void abrirform(object formhijo)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();

            // Forzar color negro en los Labels del formulario cargado
            foreach (Control control in fh.Controls)
            {
                if (control is Label)
                {
                    control.ForeColor = Color.Black;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirform(new REPORTES()); // Reemplaza 'FormCLIENTE' con el formulario que quieres abrir
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirform(new EMPLEADOS());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirform(new STOCKACESORIOS());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            abrirform(new STOCKVEHICULOS());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirform(new VENTA(empleadoActivo));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
