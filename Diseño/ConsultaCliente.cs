using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;

namespace Diseño
{
    public partial class ConsultaCliente : Form
    {
        private NegocioClientes negocioClientes = new NegocioClientes();
        NegocioValidaciones validaciones = new NegocioValidaciones();
        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefonoCliente.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;

            dtgv.DataSource = negocioClientes.BuscarClientes(nombre, apellido, dni, telefono, email, direccion);

        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = negocioClientes.ObtenerTodosLosClientes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtDni.Clear();
            txtTelefonoCliente.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDni.Text = dtgv.CurrentRow.Cells[0].Value.ToString();
            txtNombreCliente.Text = dtgv.CurrentRow.Cells[1].Value.ToString();
            txtApellidoCliente.Text=dtgv.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dtgv.CurrentRow.Cells[3].Value.ToString();
            txtTelefonoCliente.Text = dtgv.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dtgv.CurrentRow.Cells[5].Value.ToString();
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
            
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtTelefonoCliente_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
                MessageBox.Show("El campo solo acepta números.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtTelefonoCliente_KeyDown(object sender, KeyEventArgs e)
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void txtApellidoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
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
