using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace GestionConstructora
{
    public partial class Form_FacturaDetalle : Form
    {
        Facturas_ca Factura = new Facturas_ca();
        public Form_FacturaDetalle(Facturas_ca factura)
        {
            InitializeComponent();
            Factura = factura;
            DiseñoGrid();
            Cargadatos();
        }
        public void DiseñoGrid()
        {
            dglineas .AutoGenerateColumns = false;
            dglineas.EnableHeadersVisualStyles = false;
            dglineas.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dglineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dglineas.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            foreach (DataGridViewColumn col in dglineas.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        public void Cargadatos()
        {
            txtfecha.Text = Factura.Fecha.ToShortDateString();
            txtref_fac.Text = Factura.Ref_Fac;
            txt_suref .Text = Factura.Su_ref;
            txtnombreprovee .Text = Factura.Proveedor;
            txtcifprovee.Text = Factura.Cif;
            txtdireprovee.Text = Factura.Direccion;
            txtcuota.Text = Factura.Cuota.ToString();
            txtbase .Text = Factura.Base.ToString() ;
            txtimporte.Text = Factura.TotImporte.ToString();
            dglineas.DataSource = Factura.Facturas_li.ToList();

        }

        private void Form_FacturaDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            FacturasCN.Cambiar_estado(Factura.Id_Factura, Convert.ToDateTime(txtfecha.Text));
        }
    }
}
