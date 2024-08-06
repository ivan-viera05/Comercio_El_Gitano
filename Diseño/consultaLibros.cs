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
        public consultaLibros()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {

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
    }
}
