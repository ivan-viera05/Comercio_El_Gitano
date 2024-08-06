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
    public partial class ConsultaProveedorHistorial : Form
    {
        NegocioProveedores negocioProveedores = new NegocioProveedores();
        public ConsultaProveedorHistorial()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            int? proveedorID = null;
            if (!string.IsNullOrEmpty(txtCodigoProveedor.Text))
            {
                proveedorID = Convert.ToInt32(txtCodigoProveedor.Text);
            }

            string nombre = txtNombreProveedor.Text;
            DateTime? fechaDesde = dateTimePickerStart.Value.Date != DateTime.MinValue ? dateTimePickerStart.Value : (DateTime?)null;
            DateTime? fechaHasta = dateTimePickerEnd.Value.Date != DateTime.MinValue ? dateTimePickerEnd.Value : (DateTime?)null;

            DataTable dt = negocioProveedores.BuscarHistorialModificaciones(proveedorID, nombre, fechaDesde, fechaHasta);
            dtgv.DataSource = dt;
        }

        private void ConsultaProveedorHistorial_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = negocioProveedores.ObtenerHistorialModificaciones();
        }
    }
}
