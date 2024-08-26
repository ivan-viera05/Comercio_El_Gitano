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

namespace Diseño
{
    public partial class AltaProveedor : Form
    {
        NegocioProveedores negocioProveedores = new NegocioProveedores();
        NegocioValidaciones validaciones = new NegocioValidaciones();
        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string nombre = txtNombreProveedor.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefonoProveedor.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el formato del correo electrónico sea correcto
           
            if (!validaciones.ValidarEmail(email))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar insertar el proveedor
            bool success = negocioProveedores.InsertarProveedor(nombre, email, telefono, direccion);
            if (success)
            {
                MessageBox.Show("Proveedor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al agregar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = negocioProveedores.LlenarGrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNombreProveedor.Clear();
            txtTelefonoProveedor.Clear();
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
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

        private void txtNombreProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga números.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtTelefonoProveedor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
               
                // Eliminar los caracteres no numéricos del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (!validaciones.ValidarNumerosYLongitud(txtTelefonoProveedor.Text, 20))
            {
                MessageBox.Show("El campo solo puede contener hasta 255 caracteres numéricos.", "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Puedes optar por limitar manualmente la longitud si ya supera los 20 caracteres
                if (txtTelefonoProveedor.Text.Length > 255)
                {
                    txtTelefonoProveedor.Text = txtTelefonoProveedor.Text.Substring(0, 255);
                    txtTelefonoProveedor.SelectionStart = txtTelefonoProveedor.Text.Length; // Para colocar el cursor al final del texto
                }
            }
        }
    }
}
