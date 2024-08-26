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
    public partial class ModificarProveedor : Form
    {

        NegocioProveedores negocioProveedores = new NegocioProveedores();
        private NegocioValidaciones validaciones = new NegocioValidaciones();
        public ModificarProveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
           dtgv.DataSource= negocioProveedores.LlenarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgv.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dtgv.Rows[rowIndex].Cells[0].Value);

            try
            {
                NegocioProveedores negocioProveedores = new NegocioProveedores();
                negocioProveedores.ModificarProveedor(
                    id,
                    txtName.Text,
                    txtEmail.Text,
                    txtTelefono.Text,
                    txtDireccion.Text
                );
                MessageBox.Show("Proveedor modificado correctamente.");
                dtgv.DataSource = negocioProveedores.LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgv.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dtgv.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dtgv.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dtgv.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dtgv.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();

            // Validar que solo contenga caracteres numéricos y hasta 20 caracteres
            
            if (!validaciones.ValidarNumerosYLongitud(telefono, 20))
            {
              
                // Limitar la longitud del texto a 20 caracteres
                if (telefono.Length > 20)
                {
                    txtTelefono.Text = telefono.Substring(0, 20);
                    txtTelefono.SelectionStart = txtTelefono.Text.Length; // Para colocar el cursor al final del texto
                }
            }
        }
    }
}
