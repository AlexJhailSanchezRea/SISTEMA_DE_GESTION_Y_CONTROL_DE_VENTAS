using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;


namespace LOGIN
{
    public partial class CLIENTE : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();
        public CLIENTE()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = textBox1.Text;
            string nombre = textBox2.Text;
            string direccion = textBox3.Text;
            string telefono = textBox4.Text;

            clienteBLL.AgregarCliente(dni, nombre, direccion, telefono);
            MessageBox.Show("Cliente registrado correctamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            CargarClientes(); // Actualiza el DataGridView
        }

        private void CargarClientes()
        {
            dataGridView1.DataSource = clienteBLL.ObtenerClientes();
            ConfigurarEstiloDataGridView();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void ConfigurarEstiloDataGridView()
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Establece el color del texto a negro
            dataGridView1.DefaultCellStyle.BackColor = Color.White; // Establece el color de fondo a blanco
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray; // Color al seleccionar
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black; // Color del texto al seleccionar
        }

    }
}
