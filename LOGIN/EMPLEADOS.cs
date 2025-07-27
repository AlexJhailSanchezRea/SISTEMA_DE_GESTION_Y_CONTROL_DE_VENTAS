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
    public partial class EMPLEADOS : Form
    {
        public EMPLEADOS()
        {
            InitializeComponent();
        }

        private void EMPLEADOS_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar tipos de empleado en comboBox1
                TipoEmpleadoBLL tipoEmpleadoBLL = new TipoEmpleadoBLL();
                var tiposDeEmpleado = tipoEmpleadoBLL.ObtenerTiposDeEmpleado();

                if (tiposDeEmpleado != null && tiposDeEmpleado.Any())
                {
                    comboBox1.DataSource = new BindingSource(tiposDeEmpleado, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";
                }
                else
                {
                    MessageBox.Show("No se encontraron tipos de empleado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Configurar color de texto en el DataGridView
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;

                // Cargar empleados en el DataGridView
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = textBox7.Text;
            string nombre = textBox1.Text;
            string direccion = textBox2.Text;
            string telefono = textBox3.Text;
            string tipoEmpleadoId = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string usuario = textBox4.Text;
            string contrasena = textBox5.Text;

            EmpleadoBLL empleadoBLL = new EmpleadoBLL();
            empleadoBLL.InsertarEmpleado(dni, nombre, direccion, telefono, tipoEmpleadoId, usuario, contrasena);

            MessageBox.Show("Empleado registrado correctamente", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarEmpleados(); // Actualizar el DataGridView
            LimpiarCampos(); // Limpiar los campos después de guardar
        }
        private void CargarEmpleados()
        {
            EmpleadoBLL empleadoBLL = new EmpleadoBLL();
            dataGridView1.DataSource = empleadoBLL.ObtenerEmpleados();

            // Ocultar las columnas de tipoEmpleado, usuario y contrasena
            if (dataGridView1.Columns["tipoEmpleado"] != null)
            {
                dataGridView1.Columns["tipoEmpleado"].Visible = false;
            }
            if (dataGridView1.Columns["usuario"] != null)
            {
                dataGridView1.Columns["usuario"].Visible = false;
            }
            if (dataGridView1.Columns["contrasena"] != null)
            {
                dataGridView1.Columns["contrasena"].Visible = false;
            }
        }
        private void LimpiarCampos()
        {
            textBox7.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string dni = textBox7.Text;
            string nombre = textBox1.Text;
            string direccion = textBox2.Text;
            string telefono = textBox3.Text;
            string tipoEmpleadoId = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string usuario = textBox4.Text;
            string contrasena = textBox5.Text;

            EmpleadoBLL empleadoBLL = new EmpleadoBLL();
            empleadoBLL.ActualizarEmpleado(dni, nombre, direccion, telefono, tipoEmpleadoId, usuario, contrasena);

            MessageBox.Show("Empleado actualizado correctamente", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarEmpleados(); // Refrescar la lista de empleados en el DataGridView
            LimpiarCampos(); // Limpiar los campos después de actualizar
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["dni"].Value.ToString();
                textBox1.Text = row.Cells["nombre"].Value.ToString();
                textBox2.Text = row.Cells["direccion"].Value.ToString();
                textBox3.Text = row.Cells["telefono"].Value.ToString();
                textBox4.Text = row.Cells["usuario"].Value.ToString();
                textBox5.Text = row.Cells["contrasena"].Value.ToString();

                // Verifica que el nombre de la columna coincida con el del DataGridView
                string tipoEmpleadoId = row.Cells["TipoEmpleadoId"].Value.ToString(); // Usa el nombre correcto de la columna

                // Código para seleccionar el valor correcto en el ComboBox
                if (comboBox1.Items.Cast<KeyValuePair<string, string>>().Any(item => item.Key == tipoEmpleadoId))
                {
                    comboBox1.SelectedValue = tipoEmpleadoId;
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                    MessageBox.Show("El tipo de empleado seleccionado no está disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.PasswordChar = '\0'; // Muestra la contraseña
            }
            else
            {
                textBox5.PasswordChar = '*'; // Oculta la contraseña
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string criterioBusqueda = textBox6.Text.Trim();

            EmpleadoBLL empleadoBLL = new EmpleadoBLL();
            var empleadosFiltrados = empleadoBLL.BuscarEmpleados(criterioBusqueda);

            dataGridView1.DataSource = empleadosFiltrados;
        }
    }
}
