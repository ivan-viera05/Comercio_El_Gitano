using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Diseño
{
    public partial class consultaLibros : Form
    {
        private NegocioLibros negocioLibros = new NegocioLibros();
        NegocioValidaciones validaciones = new NegocioValidaciones();
        public consultaLibros()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {
            // Validar que no haya números en el texto pegado
            TextBox txt = sender as TextBox;
            if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, @"\d"))
            {
       
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"\d", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }
        private void CargarDatos()
        {
            try
            {
                DataTable dt = negocioLibros.LlenarGrid();
                dtgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string titulo = txtName.Text;
            string autor = txtAutor.Text;
            string codigo = txtCodigo.Text;
            string genero = cbxGenero.SelectedItem?.ToString();
            string editorial = txtEditorial.Text;

            try
            {
                DataTable dt = negocioLibros.BuscarLibros(titulo, autor, codigo, genero, editorial);
                dtgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void consultaLibros_Load(object sender, EventArgs e)
        {


        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtAutor.Clear();
            txtName.Clear();
            txtEditorial.Clear();
            txtCodigo.Clear();
            cbxGenero.SelectedIndex = -1;
            dtgv.DataSource = null;
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
