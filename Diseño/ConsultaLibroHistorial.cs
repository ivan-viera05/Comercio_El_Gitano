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
    }
}
