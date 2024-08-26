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
    public partial class ConsultaLibroHistorial : Form
    {
        private NegocioLibros negocioLibros = new NegocioLibros();
        NegocioValidaciones validaciones = new NegocioValidaciones();

        public ConsultaLibroHistorial()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string titulo = txtName.Text;
            string isbn = txtCodigo.Text;
            DateTime? desde = dateTimePickerStart.Checked ? dateTimePickerStart.Value : (DateTime?)null;
            DateTime? hasta = dateTimePickerStart.Checked ? dateTimePickerStart.Value : (DateTime?)null;

            DataTable historial = negocioLibros.ObtenerHistorialModificaciones(titulo, isbn, desde, hasta);
            dtgv.DataSource = historial;
        }

        private void ConsultaLibroHistorial_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = negocioLibros.ObtenerHistorialModificacion();
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat = " ";
            dateTimePickerStart.Checked = false;

            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = " ";
            dateTimePickerEnd.Checked = false;
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStart.Checked)
            {
                dateTimePickerStart.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dateTimePickerStart.CustomFormat = " ";
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Checked)
            {
                dateTimePickerEnd.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dateTimePickerEnd.CustomFormat = " ";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (validaciones.ContieneNumeros(txt.Text))
            {
                // Eliminar los números del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"\d", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga números.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar texto que no sean números
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
