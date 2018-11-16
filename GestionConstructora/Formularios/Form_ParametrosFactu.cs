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
    public partial class Form_ParametrosFactu : Form
    {
        public Empresas Emp { get; set; }
        List<Facturas_ca> Factus;
        public Form_ParametrosFactu(List<Facturas_ca> factus)
        {
            InitializeComponent();
            Factus = factus;
            cbempresa.DataSource = EmpresasCN.Listar();
            cbempresa.DisplayMember = "Nombre";
            cbempresa.ValueMember = "Id_Empresa";
            cbempresa.SelectedValue = Factus[0].Obras.Id_Empresa;  
            Emp = EmpresasCN.Listar(Factus[0].Obras.Id_Empresa);
            fvencimiento.Value = factus[0].Fecha;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Val_Datos() == false) return;
            foreach (Facturas_ca Fac in Factus)
            {
                switch (cbformapago.Text)
                {
                    case "Pagare 60 Dias\t":
                        FacturasCN.AñadirMetodoPago(Fac.Id_Factura, 1, fvencimiento.Value);
                        break;
                    case "Transferencia/Cheque":
                        FacturasCN.AñadirMetodoPago(Fac.Id_Factura, 2, fvencimiento.Value);
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }
             
        private void cbformapago_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbformapago.Text)
            {
                case "Pagare 60 Dias\t":
                    fvencimiento.Value =fvencimiento.Value.AddDays(60);
                    fvencimiento.Visible = true;
                    lvencimiento.Visible = true;
                    lvencimiento.Text = "Fecha Vencimiento:";
                    break;
                case "Transferencia/Cheque":
                    fvencimiento.Visible = true;
                    lvencimiento.Visible = true;
                    lvencimiento.Text = "Fecha Vencimiento:";
                    break;
                default:
                    break;
            }
        }

        private void cbempresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Emp = EmpresasCN.Listar(Convert.ToInt32(cbempresa.SelectedValue));
        }
        public bool Val_Datos()
        {
            bool Erro = true;
            //Comprobamos si tiene numero de Factura
            if (Convert.ToInt32(cbformapago.SelectedIndex) == -1)
            {
                errorProvider1.SetError(cbformapago, "Debe introducir el número de factura");
                Erro = false;
            }
            else
            {
                errorProvider1.SetError(cbformapago, null);
            }
            return Erro;

        } 

        private void Form_ParametrosFactu_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (cbformapago.SelectedIndex == -1) e.Cancel = true; 
        }
    }
}
