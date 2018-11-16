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

namespace GestionConstructora
{
    public partial class Form_Obrasmetros : Form
    {
        public Form_Obrasmetros()
        {
            InitializeComponent();
            dgobras.AutoGenerateColumns = false;
            dgobras.EnableHeadersVisualStyles = false;
            dgobras.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dgobras.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgobras.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            dgobras.DataSource = ObraCN.ListarObras_Metros();
        }

        private void dgobras_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string name = null;
            name = dgobras.Columns[e.ColumnIndex].Name;
            if (name == "m_escriturados" || name == "m_construidos" || name == "m_utiles")
            {
                try
                {
                    // Valor actual de la celda 
                    string value = dgobras.CurrentCell.EditedFormattedValue.ToString();
                    // Reemplazamos el punto por la coma decimal. 
                    value = value.Replace(".", ",");
                    // Escribimos el nuevo valor. 
                    decimal cellValue = Convert.ToDecimal(value);
                    dgobras.CurrentCell.Value = cellValue;
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void dgobras_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
                ObraCN.Modificarmetros( Convert.ToInt32(dgobras["Id_Obra", e.RowIndex].Value.ToString()), Convert.ToInt32(dgobras["id_empresa", e.RowIndex].Value.ToString()), Convert.ToInt32(dgobras["m_escriturados", e.RowIndex].Value.ToString()), Convert.ToInt32(dgobras["m_construidos", e.RowIndex].Value.ToString()), Convert.ToInt32(dgobras["m_Utiles", e.RowIndex].Value.ToString())); 
            
        }
    }
}
