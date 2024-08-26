using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class BajaCliente : Form
    {
        private NegocioClientes clientesNegocio = new NegocioClientes();
        private NegocioValidaciones validaciones = new NegocioValidaciones();
        
        public BajaCliente()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellidoCliente.Clear();
            txtMail.Clear();
            txtDireccion.Clear();
            txtDni.Clear();
           
            txtNombreCliente.Clear();
            
            txtTelefonoCliente.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDni.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombreCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellidoCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text =dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTelefonoCliente.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
         private void LoadClientes()
        {
            dataGridView1.DataSource = clientesNegocio.ObtenerTodosLosClientes();
        }

        private void BajaCliente_Load(object sender, EventArgs e)
        {
          
            
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefonoCliente.Text;
            string mail=txtMail.Text;
            string direccion = txtDireccion.Text;
            

            dataGridView1.DataSource = clientesNegocio.BuscarClientes(nombre, apellido, dni, telefono,mail,direccion);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("¿Estás seguro de que quieres eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (clientesNegocio.EliminarCliente(dni))
                    {
                        MessageBox.Show("Cliente eliminado correctamente.");
                        LoadClientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
             
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!validaciones.EsLongitudValida(txt.Text, 13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, 13);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto

        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar texto que no sean números
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (validaciones.ContieneNumeros(txt.Text))
            {
                MessageBox.Show("El campo solo acepta letras.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Eliminar los números del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"\d", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga números.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtTelefonoCliente_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
            
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!validaciones.EsLongitudValida(txt.Text, 13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0,13);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtApellidoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtApellidoCliente_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (validaciones.ContieneNumeros(txt.Text))
            {
                MessageBox.Show("El campo solo acepta letras.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Eliminar los números del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"\d", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtApellidoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga números.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
