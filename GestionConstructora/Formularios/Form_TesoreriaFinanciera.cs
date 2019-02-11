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
using System.Globalization;

namespace GestionConstructora
{

    public partial class Form_TesoreriaFinanciera : Form
    {
        Est_Tesoreria TesoreriaSeleccionada = new Est_Tesoreria();
        string estado = "";
        List<LineasEstFinanciera> LineasInform = new List<LineasEstFinanciera>();
        public Form_TesoreriaFinanciera()
        {
            InitializeComponent();
            Diseño_form();
            CalculoObrasconRelacion();          
           
        }
        public void CargaIni()
        {
            dgfinancieras.DataSource = Est_TesoreriaCN.Listar();
            foreach (DataGridViewRow Row in dgfinancieras.Rows)
            {
                Row.Cells["dcPendiente"].Value = Convert.ToDecimal(Row.Cells["dcptereforma"].Value) - Convert.ToDecimal(Row.Cells["dcrealizado"].Value);
            }
            dgfinancieras.Refresh();
            pbotones.Visible = false;
            pcentral.Enabled = true;
        }

        public void Diseño_form()
        {
            dgfinancieras.AutoGenerateColumns = false;
            dgfinancieras.EnableHeadersVisualStyles = false;
            dgfinancieras.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dgfinancieras.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgfinancieras.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);

            dginforme.AutoGenerateColumns = false;
            dginforme.EnableHeadersVisualStyles = false;
            dginforme.ColumnHeadersDefaultCellStyle.BackColor = Color.Honeydew;
            dginforme.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dginforme.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 9.0F, FontStyle.Bold);
            
            cbidempresa.DataSource = EmpresasCN.Listar();
            cbidempresa.DisplayMember = "Nombre";
            cbidempresa.ValueMember = "Id_Empresa";
            cbidobra.DataSource = ObraCN.Listar(7);
            cbidobra.DisplayMember = "Nombre";
            cbidobra.ValueMember = "Id_Obra";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void CargarFinanciera()
        {
            pbotones.Visible = true;
            pcentral.Enabled = false;
            cbidempresa.SelectedValue = TesoreriaSeleccionada.id_empresa;
            cbidobra.SelectedValue = TesoreriaSeleccionada.id_obra;
            if (TesoreriaSeleccionada.id_empresa == 7 && TesoreriaSeleccionada.id_obra == 0)
            {
                cbidempresa.Text = "";
                cbidobra.Text = "";
                txtptereforma.Enabled = true;
                txtreformarealizada.Enabled = true;
            }
            else
            {
                txtptereforma.Enabled = false;
                txtreformarealizada.Enabled = false;
              
            }



            linfo.Text = "MODIFICANDO la Obra: " + TesoreriaSeleccionada.Nombre;
            txtobra.Text = TesoreriaSeleccionada.Nombre;
            txtprincipal.Text = TesoreriaSeleccionada.principal.ToString(); 
            txttotalcompra.Text = TesoreriaSeleccionada.CompraTotal.ToString();
            txtcarencia.Text = (TesoreriaSeleccionada.Carencia == null) ? "0": TesoreriaSeleccionada.Carencia.ToString();
            //txtpte.Text = TesoreriaSeleccionada.pte.ToString();
            txttipointeres.Text = TesoreriaSeleccionada.tipointeres.ToString("00.00"); 
            txtplazo.Text = TesoreriaSeleccionada.Plazo.ToString();
            txtptereforma.Text = TesoreriaSeleccionada.ptereforma.ToString();
            txtreformarealizada.Text = TesoreriaSeleccionada.Realizado.ToString();
            txtventa.Text = TesoreriaSeleccionada.Venta.ToString();
            fcompra.Value = TesoreriaSeleccionada.Fcompra;
            ffin.Value = TesoreriaSeleccionada.ffin;
            finiprevisto.Value = TesoreriaSeleccionada.finicioprevisto;
            fventa.Value = TesoreriaSeleccionada.fventa;

        }
        public void GuardarEstudio()
        {
            if (estado == "NUEVO") TesoreriaSeleccionada = new Est_Tesoreria();
            TesoreriaSeleccionada.Nombre = txtobra.Text;
            TesoreriaSeleccionada.principal = Convert.ToDecimal(txtprincipal.Text.Replace(".", ""));
            TesoreriaSeleccionada.CompraTotal = Convert.ToDecimal(txttotalcompra.Text.Replace(".", ""));
            TesoreriaSeleccionada.Carencia = Convert.ToInt32(txtcarencia.Text.Replace(".", ""));
            // TesoreriaSeleccionada.pte = Convert.ToDecimal(txtpte.Text.Replace(".", ""));
            TesoreriaSeleccionada.tipointeres = Convert.ToDecimal(txttipointeres.Text.Replace("%", ""));
            TesoreriaSeleccionada.ptereforma = Convert.ToDecimal(txtptereforma.Text.Replace(".", ""));
            TesoreriaSeleccionada.Realizado = Convert.ToDecimal(txtreformarealizada.Text.Replace(".", ""));
            TesoreriaSeleccionada.Fcompra = new DateTime(fcompra.Value.Year, fcompra.Value.Month, 1);
            TesoreriaSeleccionada.ffin = new DateTime(ffin.Value.Year, ffin.Value.Month, 1);
            TesoreriaSeleccionada.finicioprevisto = new DateTime(finiprevisto.Value.Year, finiprevisto.Value.Month, 1);
            TesoreriaSeleccionada.fventa = new DateTime(fventa.Value.Year, fventa.Value.Month, 1);
            TesoreriaSeleccionada.Venta = Convert.ToDecimal(txtventa.Text.Replace(".", ""));
            TesoreriaSeleccionada.Comentario = txtcomentarios.Text;
            TesoreriaSeleccionada.id_empresa = Convert.ToInt32(cbidempresa.SelectedValue);
            TesoreriaSeleccionada.id_obra = Convert.ToInt32(cbidobra.SelectedValue);
            TesoreriaSeleccionada.Comentario = txtcomentarios.Text;
            TesoreriaSeleccionada.Plazo = Convert.ToInt32(txtplazo.Text.Replace(".", ""));
            if (estado == "EDITAR")
            { Est_TesoreriaCN.Editar(TesoreriaSeleccionada); }
            else
            { Est_TesoreriaCN.Añadir(TesoreriaSeleccionada); }
            CargaIni();
        }

        private void dgfinancieras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TesoreriaSeleccionada = Est_TesoreriaCN.Listar(Convert.ToInt32(dgfinancieras.CurrentRow.Cells["dcidtesoreria"].Value));
            estado = "EDITAR";
            CargarFinanciera();
        }

        private void bttnuevo_Click(object sender, EventArgs e)
        {
            pbotones.Visible = true;
            estado = "NUEVO";
            pcentral.Enabled = false;
            linfo.Text = "NUEVA OBRA: ";
            txtobra.Text = "";
            txttotalcompra.Text = "0";
            txtprincipal.Text = "0" ;
            txtcarencia.Text = "0";
            //txtpte.Text = TesoreriaSeleccionada.pte.ToString();
            txttipointeres.Text = "01,00";
            txtplazo.Text = "0";
            txtptereforma.Text = "0";
            txtreformarealizada.Text = "0";
            txtventa.Text = "0";
            fcompra.Value = DateTime.Today;
            ffin.Value = DateTime.Today;
            finiprevisto.Value = DateTime.Today;
            fventa.Value = DateTime.Today;
            cbidempresa.SelectedValue = 7;
            cbidobra.SelectedValue = 0;
            cbidempresa.Text = "";
            cbidobra.Text = "";


        }

        private void bttborrar_Click(object sender, EventArgs e)
        {
            if (dgfinancieras.SelectedRows.Count <= 0) return;
            DialogResult result;
            result = MessageBox.Show("Va eliminar una obra del analisis de la tesoreria.¿Desea continuar?", "Alerta", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Est_TesoreriaCN.Borrar(Convert.ToInt32(dgfinancieras.SelectedRows[0].Cells["dcidtesoreria"].Value));
                CargaIni();
            }

        }
        private void entrada(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "0") campo.Text = "";

        }
        private void salida(object sender, EventArgs e)
        {
            TextBox campo;
            campo = (TextBox)sender;
            if (campo.Text == "") campo.Text = "0";
            decimal numero = 0;
            bool result = decimal.TryParse(campo.Text, out numero);
            if (result == false) campo.Text = "0";


        }
        private void EventodeCalculo(object sender, EventArgs e)
        {
            try
            {
                TextBox campo;
                campo = (TextBox)sender;
                double numero = Convert.ToDouble(campo.Text);
                campo.Text = numero.ToString("N0");
                campo.Select(campo.Text.Length, 0);
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgfinancieras.Enabled = true;
            GuardarEstudio();
        }

        private void btteditar_Click(object sender, EventArgs e)
        {
            if (dgfinancieras.SelectedRows.Count <= 0) return;
            TesoreriaSeleccionada = Est_TesoreriaCN.Listar(Convert.ToInt32(dgfinancieras.SelectedRows[0].Cells["dcidtesoreria"].Value));
            estado = "EDITAR";
            dgfinancieras.Enabled = false;
            CargarFinanciera();
        }

        private void cbidempresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbidempresa.SelectedValue = 7;
            cbidobra.SelectedValue = 0;
            cbidempresa.Text = "";
            cbidobra.Text = "";
            txtptereforma.Text = "0";
            txtreformarealizada.Text = "0";
            Est_TesoreriaCN.EditarPteandRealizado(TesoreriaSeleccionada.Id_tesoreria, 0, 0);
            txtptereforma.Enabled = true;
            txtreformarealizada.Enabled = true;
        }

        private void cbidempresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                cbidobra.DataSource = ObraCN.Listar(Convert.ToInt32(cbidempresa.SelectedValue));
                cbidobra.DisplayMember = "Nombre";
                cbidobra.ValueMember = "Id_Obra";
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreacionInforme();
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            DiseñoGrid();
        }
        private void CreacionInforme()
        {
            decimal GastosFijos = Convert.ToDecimal(txtgastofijos.Text);
            decimal Saldo = Convert.ToDecimal(txtsaldodispon.Text);
            int mesespendientes = 0;
            List<Est_Tesoreria> Obras = Est_TesoreriaCN.Listar();
            LineasInform.Clear();
            int meses = Convert.ToInt32(txtmesesafuturo.Text);
            for (int i = 0; i < meses; i++)
            {
                DateTime Fechames = new DateTime(DateTime.Today.AddMonths(i).Year, DateTime.Today.AddMonths(i).Month, 1);
                foreach (Est_Tesoreria Obra in Obras)
                {
                    
                    mesespendientes = (new DateTime(DateTime.Today.AddMonths(0).Year, DateTime.Today.AddMonths(0).Month, 1) >= Obra.finicioprevisto) ? Publico.GetMonthDifference(new DateTime(DateTime.Today.AddMonths(0).Year, DateTime.Today.AddMonths(0).Month, 1), Obra.ffin) : Publico.GetMonthDifference(Obra.finicioprevisto, Obra.ffin); 
                    if (Fechames < Obra.Fcompra) continue;
                    LineasEstFinanciera Mes = new LineasEstFinanciera();
                    DataTable dt = new DataTable();
                    Form_Financiero.TablaAmortizacion(Convert.ToDouble(Obra.principal), Convert.ToDouble(Obra.tipointeres), Obra.Plazo * 12, dt);
                  
                    Mes.NombreObra = Obra.Nombre;
                    Mes.Id_Mes = i;
                    Mes.MesAño = Publico.MonthName(Fechames.Month) + Fechames.Year.ToString();
                    //Mes.PagoxCompra
                    if (Fechames == Obra.Fcompra)  Mes.pagoxcompra = Obra.CompraTotal - Obra.principal;
                    if (Fechames < Obra.fventa)
                    {
                        //Mes.GastoFijo
                        Mes.GastoFijo = (Obras.Where(p => Fechames < p.fventa  && Fechames >= p.Fcompra).ToList().Count > 0) ? Math.Round(GastosFijos / Obras.Where(p => Fechames < p.fventa && Fechames >= p.Fcompra).ToList().Count, 2) : 0;
                        //Mes.GastoHipotecas  
                        if (Fechames >= Obra.Fcompra.AddMonths(Convert.ToInt32(Obra.Carencia)))
                        {
                            if (dt.Rows.Count > 0) Mes.GastoHipoetas = Math.Round(Convert.ToDecimal(dt.Rows[0]["Cuota"]), 2);
                        }                                         
                        //Mes.GastoObra
                        if (Fechames >= Obra.finicioprevisto && Fechames < Obra.ffin)  Mes.GastoObra = Obra.Est_TesoreriaMes.Where (p=> p.mes == Fechames.Month && p.año == Fechames.Year).Sum(p=> p.importe);
                        //Mes.TotGasto
                        Mes.TotGasto = Mes.GastoFijo + Mes.GastoHipoetas + Mes.GastoObra;
                    }
                    //Mes.Venta
                    if (Fechames == Obra.fventa)
                    {                      
                        if (Obra.Carencia == 0 || Obra.Carencia ==null)
                        {
                            // La Obra se vende normal
                            Mes.Venta = Obra.Venta;
                            int mesesencartera = Publico.GetMonthDifference(Obra.Fcompra, Obra.fventa) - 1;
                            Mes.HiotecaPendiente = Convert.ToDecimal(dt.Rows[mesesencartera]["Saldo"]);
                        }
                        else
                        {
                            if (Fechames >= Obra.Fcompra.AddMonths(Convert.ToInt32(Obra.Carencia)))
                            {
                                // Si la obra se vende despues de acabar la carencia
                                Mes.Venta = Obra.Venta;
                                decimal interesespendientes = 0;
                                int mesesencartera = Publico.GetMonthDifference(Obra.Fcompra, Obra.fventa) - 1;
                                for (int a = 0; a < Obra.Carencia; a++)
                                {
                                    interesespendientes += Convert.ToDecimal(dt.Rows[a]["Intereses"]);
                                }
                                Mes.HiotecaPendiente = Convert.ToDecimal(dt.Rows[mesesencartera - Convert.ToInt32(Obra.Carencia)]["Saldo"]) + interesespendientes;
                            }
                            else
                            {
                                // Si la Obra se Vende antes de que acabe la carencia
                                Mes.Venta = Obra.Venta;
                                decimal interesespendientes = 0;
                                int mesesencartera = Publico.GetMonthDifference(Obra.Fcompra, Obra.fventa) - 1;
                                for (int a = 0; a < mesesencartera; a++)
                                {
                                    interesespendientes += Convert.ToDecimal(dt.Rows[a]["Intereses"]);
                                }
                                Mes.HiotecaPendiente = Obra.principal + interesespendientes;
                            }
                        }                        
                    }   
                     
                    if(Mes.TotGasto != 0 || Mes.HiotecaPendiente !=0) LineasInform.Add(Mes);
                }
            }
            foreach (LineasEstFinanciera lin in LineasInform)
            {
                lin.Saldo = (Saldo + LineasInform.Where(p => p.Id_Mes <= lin.Id_Mes).Sum(p => p.Venta)) - (LineasInform.Where(p => p.Id_Mes <= lin.Id_Mes).Sum(p => p.TotGasto) + LineasInform.Where(p => p.Id_Mes <= lin.Id_Mes).Sum(p => p.pagoxcompra) + LineasInform.Where(p => p.Id_Mes <= lin.Id_Mes).Sum(p => p.HiotecaPendiente)) ;

            }

            dginforme.DataSource = LineasInform
             .GroupBy(p => p.Id_Mes,
                     (k, c) => new LineasEstFinanciera()
                     {
                         Id_Mes = k,
                         MesAño = c.Max(x => x.MesAño),
                         Saldo = c.Max(x => x.Saldo),
                         Venta = c.Sum(x => x.Venta),
                         GastoFijo = c.Sum(x => x.GastoFijo),
                         GastoHipoetas = c.Sum(x => x.GastoHipoetas),
                         GastoObra = c.Sum(x => x.GastoObra),
                         TotGasto = c.Sum(x => x.TotGasto),
                         HiotecaPendiente = c.Sum(x => x.HiotecaPendiente),
                         pagoxcompra = c.Sum(x => x.pagoxcompra)

                     }
                    ).ToList();
          
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            R_TesoreriaFinanciera f = new R_TesoreriaFinanciera(LineasInform);
            f.ShowDialog();
        }
        private  void CalculoObrasconRelacion()
        {
            foreach (Est_Tesoreria Obr in Est_TesoreriaCN.Listar())
            {
                if (TesoreriaSeleccionada.id_empresa != 7 && TesoreriaSeleccionada.id_obra != 0)
                {
                    //los que tienen relacion ya no vale de nada
                    decimal pte, realizado;
                    pte = Obr.Obras.Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_presu);
                    realizado = Obr.Obras.Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_Certificado);
                    Est_TesoreriaCN.EditarPteandRealizado(Obr.Id_tesoreria, pte, realizado);
                }
                else
                {
                    // esto es lo que vale ahora porque calcula lo pendiente ne funcion de los meses que han pasdao
                    decimal pte, realizado;
                    pte = Obr.Est_TesoreriaMes.Sum(p => p.importe);
                    realizado = Obr.Est_TesoreriaMes.Where(p => p.año < DateTime.Today.Year || (p.mes < DateTime.Today.Month && p.año == DateTime.Today.Year)).Sum(p => p.importe);
                    Est_TesoreriaCN.EditarPteandRealizado(Obr.Id_tesoreria, pte, realizado);

                }
            }
        }

        private void cbidobra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            decimal pte, realizado;
            pte = ObraCN.Listar(Convert.ToInt32(cbidobra.SelectedValue), Convert.ToInt32(cbidempresa.SelectedValue)).Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_presu);
            realizado = ObraCN.Listar(Convert.ToInt32(cbidobra.SelectedValue), Convert.ToInt32(cbidempresa.SelectedValue)).Obras_Lineas.Where(p => p.Id_Fase == 0).Sum(p => p.Importe_Certificado);

            txtptereforma.Enabled = false;
            txtreformarealizada.Enabled = false;
            txtptereforma.Text = pte.ToString();
            txtreformarealizada.Text = realizado.ToString();
            Est_TesoreriaCN.EditarPteandRealizado(TesoreriaSeleccionada.Id_tesoreria, pte, realizado);
        }

        private void Form_TesoreriaFinanciera_Load(object sender, EventArgs e)
        {
            txtsaldodispon.Text = "1000000";
            CargaIni();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_TesoreriaMes f = new Form_TesoreriaMes(TesoreriaSeleccionada);
            f.ShowDialog();
            TesoreriaSeleccionada = Est_TesoreriaCN.Listar(Convert.ToInt32(dgfinancieras.SelectedRows[0].Cells["dcidtesoreria"].Value));
            txtptereforma.Text = TesoreriaSeleccionada.Est_TesoreriaMes.Sum(p => p.importe).ToString();
            txtreformarealizada.Text = TesoreriaSeleccionada.Est_TesoreriaMes.Where(p=> p.año < DateTime.Today.Year || ( p.mes < DateTime.Today.Month && p.año == DateTime.Today.Year)).Sum(p => p.importe).ToString();
            Est_TesoreriaCN.EditarPteandRealizado(TesoreriaSeleccionada.Id_tesoreria, Convert.ToDecimal(txtptereforma.Text), Convert.ToDecimal(txtreformarealizada.Text));
        }
        public void DiseñoGrid()
        {
            foreach (DataGridViewRow Row in dginforme.Rows)
            {
                foreach (DataGridViewCell cell in Row.Cells)
                {
                    if (cell.ValueType.Name == "Double" || cell.ValueType.Name == "Decimal")
                    {
                        if (Convert.ToDecimal(cell.Value) < 0)
                        {
                            cell.Style.ForeColor = Color.Red;
                        }
                    }
                }

            }
            dginforme.Refresh();
        }
    }
}
