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
    public partial class STOCKVEHICULOS : Form
    {
        private VehiculoBLL vehiculoBLL = new VehiculoBLL();
        private int vehiculoSeleccionadoId; // Almacena el ID del vehículo seleccionado

        public STOCKVEHICULOS()
        {
            InitializeComponent();
            CargarVehiculos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marca = textBox1.Text;
            string modelo = textBox2.Text;
            int anio = int.Parse(textBox3.Text);
            decimal precio = decimal.Parse(textBox4.Text); // Precio en dólares
            int cantidad = int.Parse(textBox6.Text);

            VehiculoBLL vehiculoBLL = new VehiculoBLL();
            vehiculoBLL.InsertarVehiculo(marca, modelo, anio, precio, cantidad);

            MessageBox.Show("Vehículo registrado correctamente en el stock.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarVehiculos(); // Refrescar el DataGridView
            LimpiarCampos(); // Limpiar los campos después de guardar
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vehiculoSeleccionadoId > 0) // Comprueba si se ha seleccionado un vehículo válido
            {
                try
                {
                    string marca = textBox1.Text;
                    string modelo = textBox2.Text;
                    int anio = int.Parse(textBox3.Text);
                    decimal precio = decimal.Parse(textBox4.Text);
                    int cantidad = int.Parse(textBox6.Text);

                    VehiculoBLL vehiculoBLL = new VehiculoBLL();
                    vehiculoBLL.ActualizarVehiculo(vehiculoSeleccionadoId, marca, modelo, anio, precio, cantidad);

                    MessageBox.Show("Vehículo actualizado correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar el DataGridView y limpiar los campos
                    CargarVehiculos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al actualizar el vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vehículo para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarVehiculos()
        {
            VehiculoBLL vehiculoBLL = new VehiculoBLL();
            var vehiculos = vehiculoBLL.ObtenerVehiculos(); // Método que recupera todos los vehículos

            dataGridView1.DataSource = vehiculos;
        }



        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

            vehiculoSeleccionadoId = 0; // Restablecer el ID seleccionado
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["marca"].Value?.ToString() ?? string.Empty;
                textBox2.Text = row.Cells["modelo"].Value?.ToString() ?? string.Empty;
                textBox3.Text = row.Cells["anio"].Value?.ToString() ?? string.Empty;
                textBox4.Text = row.Cells["precio"].Value?.ToString() ?? string.Empty;
                textBox6.Text = row.Cells["cantidad"].Value?.ToString() ?? string.Empty;

                // Declarar la variable id antes del int.TryParse
                int id;
                if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out id))
                {
                    vehiculoSeleccionadoId = id;
                }
                else
                {
                    vehiculoSeleccionadoId = 0; // Restablece a 0 si no se selecciona un ID válido
                }
            }
        }

        private void STOCKVEHICULOS_Load(object sender, EventArgs e)
        {
            VehiculoBLL vehiculoBLL = new VehiculoBLL();
            dataGridView1.DataSource = vehiculoBLL.ObtenerVehiculos();

            // Cambia los encabezados de las columnas
            dataGridView1.Columns["anio"].HeaderText = "Año";
            dataGridView1.Columns["precio"].HeaderText = "Precio Unitario";

            // Configura el color de las celdas, si es necesario
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }
    
    }
}
