using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;//movimiento de formulario
using System.Data.SqlClient;
using BLL;
using DAL;
namespace LOGIN
{
    public partial class Login : Form
    {
        private EmpleadoBLL empleadoBLL = new EmpleadoBLL();
        private Empleado empleadoActivo;
        public Login()
        {
            InitializeComponent();
        }
        //**movimiento de formulario//
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //**moviento de formulario//


        //PARA QUE SE DESPLIEGUE LAS LETRAS DE LOS TEXBOXTS
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.AliceBlue;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.AliceBlue;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.AliceBlue;

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.AliceBlue;
                textBox2.UseSystemPasswordChar = false;

            }
        }
        /////////////////////////////////////////////////////////////
        //**MOVIMIENTO DE CADA HERRAMIENTO CON EL EVENTO DE MOUSEDOW//
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        ////////////////////FIN DEL EVENTO DE MOUSE DOW////////////////
        private void button5_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;

            empleadoActivo = empleadoBLL.IniciarSesion(usuario, contrasena);

            if (empleadoActivo != null)
            {
                MessageBox.Show($"Bienvenido, {usuario}. Rol: {empleadoActivo.TipoEmpleadoId}", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el formulario de ventas y pasar el empleado activo
                MENU A = new MENU(empleadoActivo);
                A.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
