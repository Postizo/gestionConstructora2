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
using System.Configuration;
using System.Data.OleDb;
using System.Globalization;

namespace GestionConstructora
{
    public partial class Publico : Form
    {
        public Publico()
        {
            InitializeComponent();
        }
        public static List<Obras> Obras_Selecionadas(ListBox Lista)
        {
            List<Obras> l = new List<Obras>();
            foreach (object item in Lista.SelectedItems)
            {
                l.Add((Obras)item);
            }   
            return l;
        }
        public static List<int> Obras_Selecionadas_int(ListBox Lista)
        {
            List<int> l = new List<int>();
            foreach (object item in Lista.SelectedItems)
            {
                l.Add(((Obras)item).Id_Obra);
            }
            return l;
        }
        public static void CargaTree(Obras Obr, Ai.Control.MultiColumnTree Multicolumn, ImageList img,int propaosigrid, bool Totales,bool repercutido,bool lineaconta,bool diseño, List<Obras_Lineas> listadetallle,int fase)
        {
            Multicolumn.Nodes.Clear();  
            // Seleccionamos la lista que vamos a carga en los nodos segun queramos los nuetsros o los de sigrid
            //  0 == Propios 1== los de segrid
            List<Obras_Lineas> l = (propaosigrid == 0) ? Obr.Capitulos.Where(p=> p.Id_Fase ==fase).Where(p=> p.Id_TipoCoste <= 0).ToList() : Obr.Obras_Lineas.Where(p=> p.Id_Fase == fase).ToList();
            if (listadetallle != null) l = listadetallle;

            Ai.Control.TreeNode tn = new Ai.Control.TreeNode();
            foreach (Obras_Lineas lin in l.OrderBy(p => p.Grupos.Orden ))
            {
                if (repercutido && lin.Id_TipoCoste != -1) continue; //SI queremos la vista repercutida (sin indirectos) quitamos esos nodos
                tn = new Ai.Control.TreeNode();
                if (listadetallle != null)
                {
                    tn.Text = lin.Capitulo + " . " + lin.Nombre;
                    Elige_Icono(251, tn, img);              
                }
                else
                {
                    tn.Text = lin.Grupos.Orden.ToString().PadLeft(2, Convert.ToChar("0")) + " . " + lin.Nombre;
                    Elige_Icono(lin.Id_TipoCoste, tn, img);
                }
                AddColumnsNode(tn, Multicolumn, lin, img,Obr);
                foreach (Obras_Lineas SubCap in lin.Subcapitulos.Where(p=> p.Id_Fase ==fase).OrderBy(p=> p.Orden))
                {
                    Ai.Control.TreeNode child = new Ai.Control.TreeNode();
                    child.Text = SubCap.Grupos.Orden.ToString().PadLeft(2, Convert.ToChar("0")) + " . " + SubCap.Nombre; 
                    AddColumnsNode(child, Multicolumn, SubCap, img,Obr);
                    tn.Nodes.Add(child);
                }
                Multicolumn.Nodes.Add(tn);
            }

            if (Totales)
            {
                //AGREGAMOS LA LIENA DE TOTALES SEGUIMIENTO
                Obras_Lineas LineaTotalesSegumi = LineaTotalesSegumiento(Multicolumn);
                tn = new Ai.Control.TreeNode();
                Elige_Icono(LineaTotalesSegumi.Id_TipoCoste, tn, img);
                tn.Text = "Total Seguimiento";
                tn.NodeFont = new Font("Verdana", 8.00F, FontStyle.Bold);
                tn.BackColor = Color.LightGray;
                AddColumnsNode(tn, Multicolumn, LineaTotalesSegumi, img,Obr);
                Multicolumn.Nodes.Add(tn);

                //AGREGAMOS LA LIENA DE TOTALES Resultado
                Obras_Lineas LineaTotalesresul = LineaResultado(Obr, 0, Multicolumn);
                tn = new Ai.Control.TreeNode();
                Elige_Icono(LineaTotalesresul.Id_TipoCoste, tn, img);
                tn.Text = "Total Resultado";
                tn.NodeFont = new Font("Verdana", 8.00F, FontStyle.Bold);
                tn.BackColor = Color.AliceBlue;
                AddColumnsNode(tn, Multicolumn, LineaTotalesresul, img, Obr);
                Multicolumn.Nodes.Add(tn);
                
            }



            if (lineaconta)
            {
                //AGREGAMOS LA LIENA DE TOTALES CONTA
                Obras_Lineas LineaTotalesCont = LineaTotalesConta(Obr, Multicolumn);
                tn = new Ai.Control.TreeNode();
                Elige_Icono(LineaTotalesCont.Id_TipoCoste, tn, img);
                tn.Text = "Total Facturado";
                tn.NodeFont = new Font("Verdana", 8.00F, FontStyle.Bold);
                tn.BackColor = Color.AntiqueWhite;
                AddColumnsNode(tn, Multicolumn, LineaTotalesCont, img,Obr);
                Multicolumn.Nodes.Add(tn);

            }

            if (diseño) Diseño_(Multicolumn);
            Multicolumn.Refresh();

        }
        public static Obras_Lineas LineaTotalesSegumiento(Ai.Control.MultiColumnTree Multicolumn)
        {
            Obras_Lineas lin = new Obras_Lineas();
            int index = 0;
            for (int i = 0; i < Multicolumn.Nodes.Count; i++)
            {
                lin.Nombre = "TOTALES";
                lin.Capitulo = "";
                lin.Medidas = 1;
                lin.Id_TipoCoste = 251;

                if ((index = Busca("Presupuestado", Multicolumn)) != -1) lin.Importe_presu += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);
                if ((index = Busca("Coste_Real", Multicolumn)) != -1) lin.Importe_CosteReal += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);
              //  if ((index = Busca("Coste_RealVenta", Multicolumn)) != -1) lin.Importe_CosteReal_venta += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);               
                if ((index = Busca("Presu_Venta", Multicolumn)) != -1) lin.Importe_P_venta += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);
                if ((index = Busca("Certificado", Multicolumn)) != -1) lin.Importe_Certificado += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);
                if ((index = Busca("CostePrevisto", Multicolumn)) != -1) lin.Importe_CostePrevisto  += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);
                if ((index = Busca("VentaPrevista", Multicolumn)) != -1) lin.Importe_VentaPrevista  += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);

                if ((index = Busca("Pagado", Multicolumn)) != -1) lin.Importe_Pagado += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);              
                if ((index = Busca("CD", Multicolumn)) != -1)  lin.Importe_PresuIndirectos += (Convert.ToInt32(Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value) == -1) ? Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value) : 0;
                if ((index = Busca("CG", Multicolumn)) != -1) lin.Importe_PresuGenerales += (Convert.ToInt32(Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value) == -1) ? Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value) : 0;
                if ((index = Busca("Beneficio", Multicolumn)) != -1) lin.Importe_PresuBeneficio += (Convert.ToInt32(Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value) == -1) ? Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value) : 0;
                if ((index = Busca("SoloCostes", Multicolumn)) != -1) lin.Importe_PresuSOLOCOSTES += Convert.ToDecimal(Multicolumn.Nodes[i].SubItems[index].Value);

            }
            ///lin.desvpor_PresuGastado = lin.Importe_Gastado / lin.Importe_presu;
            return lin;
        }

        public static Obras_Lineas LineaTotalesConta(Obras Obr,Ai.Control.MultiColumnTree Multicolumn)
        {
            Obras_Lineas lin = new Obras_Lineas();
            lin.Nombre = "TotalesConta";
            lin.Medidas = 1;
            lin.Id_TipoCoste = 250;
            lin.Importe_presu = Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosContribuciondirecta2_Conta ;
            lin.Importe_CostePrevisto = Obr.P_Total_Gastosdirectos3_Conta + Obr.P_Total_GastosContribuciondirecta2_Conta;
            lin.Importe_Facturado = Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosContribuciondirecta2_Conta;
            lin.Importe_CosteReal = 0; // Obr.Total_Gastosdirectos3_Conta + Obr.Total_GastosContribuciondirecta2_Conta;
            lin.Importe_P_venta = Obr.P_Total_Ingresos1_Conta;
            lin.Importe_VentaPrevista = Obr.P_Total_Ingresos1_Conta;
            lin.Importe_Certificado  = Obr.Total_Ingresos1_Conta;
            return lin;
        }
        public static Obras_Lineas LineaResultado(Obras Obr, int id_fase, Ai.Control.MultiColumnTree Multicolumn)
        {
            Obras_Lineas lin = new Obras_Lineas();
            lin.Nombre = "TotalesConta";
            lin.Medidas = 1;
            lin.Id_TipoCoste = 256;
            lin.Importe_presu = 0; // Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_presu);
            lin.Importe_CostePrevisto = 0;// Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_CostePrevisto);
            lin.Importe_Facturado = 0; // Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_Facturado);
            lin.Importe_CosteReal = 0; // Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_CosteReal) - Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_CostePrevisto);
            lin.Importe_P_venta = Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_P_venta) - Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_presu);
            lin.Importe_VentaPrevista = Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_VentaPrevista) - Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_CostePrevisto);
            lin.Importe_Certificado = Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_Certificado) - Obr.Obras_Lineas.Where(p => p.Id_Fase == id_fase).Sum(p => p.Importe_CosteReal);
            return lin;
        }
        public static Obras_Lineas LineaTotalesCobrado(Obras Obr, Ai.Control.MultiColumnTree Multicolumn)
        {
            Obras_Lineas lin = new Obras_Lineas();
            lin.Nombre = "TotalesCobrado";
            lin.Medidas = 1;
            lin.Id_TipoCoste = 252;     
            lin.Importe_Certificado = 0;
            return lin;
        }

        public static void Diseño_(Ai.Control.MultiColumnTree Multicolumn)
        {
            int index = 0;
            for (int i = 0; i < Multicolumn.Nodes.Count; i++)
            {
              
                if ((index = Busca("Presupuestado", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Presupuestado", Multicolumn)].BackColor = Color.LavenderBlush;
                if ((index = Busca("Gastado", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Gastado", Multicolumn)].BackColor = Color.LavenderBlush;
                if ((index = Busca("CostePrevisto", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("CostePrevisto", Multicolumn)].BackColor = Color.LavenderBlush;
                if ((index = Busca("Coste_Real", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Coste_Real", Multicolumn)].BackColor = Color.LavenderBlush;

                if ((index = Busca("Coste_RealVenta", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Coste_RealVenta", Multicolumn)].BackColor = Color.AliceBlue;
                if ((index = Busca("Presu_Venta", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Presu_Venta", Multicolumn)].BackColor = Color.AliceBlue;
                if ((index = Busca("VentaPrevista", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("VentaPrevista", Multicolumn)].BackColor = Color.AliceBlue;
                if ((index = Busca("Certificado", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Certificado", Multicolumn)].BackColor = Color.AliceBlue;
                if ((index = Busca("Diferencia", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Diferencia", Multicolumn)].BackColor = Color.FloralWhite;

                if ((index = Busca("%Presupuesto", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("%Presupuesto", Multicolumn)].BackColor = Color.MintCream;
                if ((index = Busca("%Costeprevisto", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("%Costeprevisto", Multicolumn)].BackColor = Color.MintCream;
                if ((index = Busca("%Presu_Venta", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("%Presu_Venta", Multicolumn)].BackColor = Color.MintCream;               
                if ((index = Busca("%Ventaprevista", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("%Ventaprevista", Multicolumn)].BackColor = Color.MintCream;
                
                if ((index = Busca("MedidasC", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("MedidasC", Multicolumn)].Font = new Font("Verdana", 9.00F, FontStyle.Bold);
                //if ((index = Busca("Presupuestado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Presupuestado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                //if ((index = Busca("Gastado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Gastado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                //if ((index = Busca("Pagado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("Pagado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                //if ((index = Busca("desvpresugastado", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("desvpresugastado", Multicolumn)].BackColor = Color.MintCream;
                //if ((index = Busca("desvpresugastadoCON", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("desvpresugastadoCON", Multicolumn)].BackColor = Color.MintCream;   
                //if ((index = Busca("desvporpresugastadoCON", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("desvporpresugastadoCON", Multicolumn)].BackColor = Color.MintCream;
                if ((index = Busca("SoloCostes", Multicolumn)) != -1) Multicolumn.Nodes[i].SubItems[Publico.Busca("SoloCostes", Multicolumn)].BackColor = Color.Red;


                for (int a = 0; a < Multicolumn.Columns.Count ; a++)
                {
                    double number;
                    bool result = false;
                    if (Multicolumn.Nodes[i].SubItems[a].Value != null)
                    {
                        result = double.TryParse(Multicolumn.Nodes[i].SubItems[a].Value.ToString(), out number);
                        if (result)
                            if (Convert.ToDouble(Multicolumn.Nodes[i].SubItems[a].Value) < 0)
                                Multicolumn.Nodes[i].SubItems[a].Color = Color.Red;
                    }
                
                    if ((index = Busca("TipoCoste", Multicolumn)) != -1) if (Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value.ToString() == "250") Multicolumn.Nodes[i].SubItems[a].BackColor = Color.AntiqueWhite;
                    if ((index = Busca("TipoCoste", Multicolumn)) != -1) if (Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value.ToString() == "251") Multicolumn.Nodes[i].SubItems[a].BackColor = Color.LightGray;
                    if ((index = Busca("TipoCoste", Multicolumn)) != -1) if (Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value.ToString() == "252") Multicolumn.Nodes[i].SubItems[a].BackColor  = Color.FloralWhite;
                    if ((index = Busca("TipoCoste", Multicolumn)) != -1) if (Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value.ToString() == "256") Multicolumn.Nodes[i].SubItems[a].BackColor = Color.AliceBlue;
                    if ((index = Busca("TipoCoste", Multicolumn)) != -1) if (Multicolumn.Nodes[i].SubItems[Publico.Busca("TipoCoste", Multicolumn)].Value.ToString() == "256") if (result) if (Convert.ToDouble(Multicolumn.Nodes[i].SubItems[a].Value) >= 0) Multicolumn.Nodes[i].SubItems[a].Color = Color.Green; 

                }

                if (Multicolumn.Nodes[i].Nodes.Count > 0)
                {
                    for (int d  = 0; d < Multicolumn.Nodes[i].Nodes.Count; d++)
                    {
                        if ((index = Busca("MedidasC", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("MedidasC", Multicolumn)].Font = new Font("Verdana", 9.00F, FontStyle.Bold);
                        if ((index = Busca("Presupuestado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("Presupuestado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("Gastado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("Gastado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("Pagado_Unidad", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("Pagado_Unidad", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("desvpresugastado", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("desvpresugastado", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("desvpresugastadoCON", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("desvpresugastadoCON", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("%Incurrido", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("%Incurrido", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("desvporpresugastadoCON", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("desvporpresugastadoCON", Multicolumn)].BackColor = Color.MintCream;
                        if ((index = Busca("SoloCostes", Multicolumn)) != -1) Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("SoloCostes", Multicolumn)].BackColor = Color.Red;
                        for (int a = 0; a < Multicolumn.Columns.Count; a++)
                        {
                            double number;
                            bool result = double.TryParse(Multicolumn.Nodes[i].Nodes[d].SubItems[a].Value.ToString(), out number);
                            if (result)
                                if (Convert.ToDouble(Multicolumn.Nodes[i].Nodes[d].SubItems[a].Value) < 0)
                                    Multicolumn.Nodes[i].Nodes[d].SubItems[a].Color = Color.Red;
                            if ((index = Busca("IsFactu", Multicolumn)) != -1) if (Multicolumn.Nodes[i].Nodes[d].SubItems[Publico.Busca("IsFactu", Multicolumn)].Value.ToString() == "1") Multicolumn.Nodes[i].Nodes[d].SubItems[a].BackColor = Color.LightBlue;                          
                        }                
                    }                                      
                }                
            }
        }
       
        public static void AddColumnsNode(Ai.Control.TreeNode tn, Ai.Control.MultiColumnTree Multicolumn, Obras_Lineas lin, ImageList img,Obras Ob)
        {
            //Elige_Icono(lin.Id_TipoCoste, tn, img);
            tn.UseNodeStyleForSubItems = false;
            double metros = (Ob.M_Construidos !=0)?Ob.M_Construidos:1;
                       

            for (int i = 0; i < Multicolumn.Columns.Count; i++)
            {
                switch (Multicolumn.Columns[i].Name)
                {

                    case "TipoCoste":
                        tn.SubItems.Add(lin.Id_TipoCoste);
                        break;
                    case "id_grupo":
                        tn.SubItems.Add(lin.Id_Grupo);
                        break;
                    case "id_subgrupo":
                        tn.SubItems.Add(lin.Id_Subgrupo.ToString());
                        break;
                        //LOS QUE VALEN 
                    case "Presupuestado":
                        tn.SubItems.Add(lin.Importe_presu);
                        break;
                    case "Presu_Venta":
                        tn.SubItems.Add(lin.Importe_P_venta);
                        break;
                    case "VentaPrevista":
                        tn.SubItems.Add(lin.Importe_VentaPrevista );
                        break;
                    case "CostePrevisto":
                        tn.SubItems.Add(lin.Importe_CostePrevisto);
                        break;
                    case "Certificado":
                        tn.SubItems.Add(lin.Importe_Certificado);
                        break;
                    case "Coste_Real":
                        tn.SubItems.Add(lin.Importe_CosteReal);
                        break;
                    case "%Presupuesto":
                        if (lin.Importe_presu != 0) { tn.SubItems.Add(lin.Importe_CosteReal / lin.Importe_presu); } else { tn.SubItems.Add(0); };
                        break;
                    case "%Costeprevisto":
                        if (lin.Importe_CostePrevisto != 0) { tn.SubItems.Add(lin.Importe_CosteReal / lin.Importe_CostePrevisto); } else { tn.SubItems.Add(0); };
                        break;
                    case "%Presu_Venta":
                        if (lin.Importe_P_venta != 0) { tn.SubItems.Add(lin.Importe_Certificado / lin.Importe_P_venta ); } else { tn.SubItems.Add(0); };
                        break;
                    case "%Ventaprevista":
                        if (lin.Importe_VentaPrevista != 0) { tn.SubItems.Add(lin.Importe_Certificado / lin.Importe_VentaPrevista ); } else { tn.SubItems.Add(0); };
                        break;
                    case "Diferencia":
                        tn.SubItems.Add(lin.Importe_Certificado - lin.Importe_CosteReal);
                        break;
                    case "%Diferencia":
                        decimal por_costereal, por_realizado;
                        if (lin.Importe_presu != 0) { por_costereal = (lin.Importe_CosteReal / lin.Importe_presu); } else { por_costereal = 0; };
                        if (lin.Importe_P_venta != 0) { por_realizado = (lin.Importe_Certificado / lin.Importe_P_venta); } else { por_realizado = 0; };
                        if (por_costereal != 0 && por_realizado != 0) { tn.SubItems.Add(por_realizado - por_costereal); } else { tn.SubItems.Add(0); }
                        break;

                    case "CstRealm":                       
                        tn.SubItems.Add(lin.Importe_CosteReal / Convert.ToDecimal(metros));                      
                        break;
                    case "Certm":
                       tn.SubItems.Add(lin.Importe_Certificado / Convert.ToDecimal(metros));
                       break;
                    case "CostePrevistom":
                        tn.SubItems.Add(lin.Importe_CostePrevisto / Convert.ToDecimal(metros));
                        break;
                    //-----------------------------------------//

                    case "Unidad_Medida":
                        tn.SubItems.Add(lin.Unidad_Medida);
                        break;
                    case "Medidas":
                        tn.SubItems.Add(lin.Medidas);
                        break;
                    case "MedidasC":
                        tn.SubItems.Add(lin.Medidas  + " " +lin.Unidad_Medida);
                        break;
                        
                  

                    case "CD":
                        tn.SubItems.Add(lin.Importe_PresuIndirectos);
                        break;
                    case "CG":
                        tn.SubItems.Add(lin.Importe_PresuGenerales);
                        break;
                    case "Beneficio":
                        tn.SubItems.Add(lin.Importe_PresuBeneficio);
                        break;
                                         
                   
                    case "Coste_teorico_Incurrido":
                        if (lin.Importe_P_venta != 0) { tn.SubItems.Add(lin.Importe_presu * (lin.Importe_Certificado / lin.Importe_P_venta)); } else { tn.SubItems.Add(0); }
                        break;
                    case "Dif_CosteTeo-CosteReal":
                        if (lin.Importe_P_venta != 0) { tn.SubItems.Add((lin.Importe_presu * (lin.Importe_Certificado / lin.Importe_P_venta)) - lin.Importe_CosteReal ); } else { tn.SubItems.Add(0); }
                        break;
                    case "%CosteReal":
                        if (lin.Importe_presu != 0) { tn.SubItems.Add(lin.Importe_CosteReal / lin.Importe_presu); } else { tn.SubItems.Add(0); };
                        break;
                  
                    case "IsFactu":
                        tn.SubItems.Add(0);
                        break;
                    case "Codigo":
                        tn.SubItems.Add(lin.Capitulo);
                        break;
                   default:
                        break;
                }
            }
        }
        public static int Busca(string clave,Ai.Control.MultiColumnTree Multicolumn)
        {
            for (int i = 0; i < Multicolumn.Columns.Count; i++)
            {
                if (Multicolumn.Columns[i].Name == clave) return i;
            }
            return -1;
        }
        public static void Elige_Icono(int tipo, Ai.Control.TreeNode tn, ImageList img)
        {
            switch (tipo)
            {
                case -1:
                    tn.Image = img.Images[4];
                    tn.ExpandedImage = img.Images[6];
                    break;
                case -2:
                    tn.Image = img.Images[8];
                    tn.ExpandedImage = img.Images[6];
                    break;
                case -3:
                    tn.Image = img.Images[7];
                    tn.ExpandedImage = img.Images[6];
                    break;
                case -4:
                    tn.Image = img.Images[5];
                    tn.ExpandedImage = img.Images[6];
                    break;

                case 10:
                    tn.Image = img.Images[9];
                    tn.ExpandedImage = img.Images[9];
                    break;
                case 11:
                    tn.Image = img.Images[10];
                    tn.ExpandedImage = img.Images[10];
                    break;
                case 250:
                    tn.Image = img.Images[9];
                    tn.ExpandedImage = img.Images[9];
                    break;
                case 251:
                    tn.Image = img.Images[10];
                    tn.ExpandedImage = img.Images[10];
                    break;
                case 252:
                    tn.Image = img.Images[3];
                    tn.ExpandedImage = img.Images[3];
                    break;
                case 256:
                    tn.Image = img.Images[2];
                    tn.ExpandedImage = img.Images[2];
                    break;
            }
        }
        public static void CargaTree_ComparaObras(List<Obras> Obrs, Ai.Control.MultiColumnTree Multicolumn, ImageList img, bool repercutido,string metros_s,int fase)
        {
            double metros = 1;
            List<Grupos> Grups = new List<Grupos>();
            if (Obrs[0].Id_Empresa == 7)
            {
                Grups = GruposCN.Listar_solocontructora();
            }
            else
            {
                Grups = GruposCN.Listar_soloelectrica();
            }


            int i = 1;
            Multicolumn.Columns.Add("Nombre");
            Multicolumn.Columns[0].Width = 350;

            foreach (Obras Obr in Obrs)
            {
                Multicolumn.Columns.Add(Obr.Nombre);
                Multicolumn.Columns[i].ColumnAlign = HorizontalAlignment.Right;
                Multicolumn.Columns[i].CustomFormat = "##,##0.00";
                Multicolumn.Columns[i].Format = Ai.Control.ColumnFormat.Custom;
                i += 1;
            }

            foreach (Grupos Grup in Grups.OrderBy(p => p.Orden).Select(p => p))
            {
                Ai.Control.TreeNode tn = new Ai.Control.TreeNode();
                tn.Text = Grup.Orden.ToString().PadLeft(2, Convert.ToChar("0")) + "." + Grup.Nombre;
                Elige_Icono(-1, tn, img);

                //Agregamos todas las obras
                foreach (Obras Obr in Obrs)
                {
                    Decimal Valor = 0;
                    switch (metros_s)
                    {
                        case "m_escriturados":
                            metros = Obr.M_Escriturados;
                            break;
                        case "m_construidos":
                            metros = Obr.M_Construidos;
                            break;
                        case "m_utiles":
                            metros = Obr.M_Utiles;
                            break;
                        
                    }

                    Obras_Lineas lin = (Obr.Capitulos.Where(p=> p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).Count() > 0) ? Obr.Capitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).ToList()[0] : null;

                    if (lin != null)
                    {
                        Elige_Icono(lin.Id_TipoCoste, tn, img);
                        switch (Obr.campocompara)
                        {
                            case "CstRealm":
                                Valor = lin.Importe_CosteReal / Convert.ToDecimal(metros);
                                break;
                            case "Certm":
                                Valor = lin.Importe_P_venta / Convert.ToDecimal(metros);
                                break;
                            case "CostePrevistom":
                                Valor = lin.Importe_CostePrevisto / Convert.ToDecimal(metros);
                                break;
                        }
                        tn.SubItems.Add(Valor);
                    }
                    else
                    {
                        tn.SubItems.Add(0);
                    }

                }

                foreach (Subgrupos sub in Grup.Subgrupos)
                {
                    Ai.Control.TreeNode tsub = new Ai.Control.TreeNode();
                    tsub.Text = sub.Id_Grupo.ToString().PadLeft(2, Convert.ToChar("0")) + "." + sub.Nombre;

                    foreach (Obras Obr in Obrs)
                    {
                        switch (metros_s)
                        {
                            case "m_escriturados":
                                metros = Obr.M_Escriturados;
                                break;
                            case "m_construidos":
                                metros = Obr.M_Construidos;
                                break;
                            case "m_utiles":
                                metros = Obr.M_Utiles;
                                break;
                        }
                        decimal valorsub = 0;
                        Obras_Lineas lin = (Obr.Capitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).Count() > 0) ? Obr.Capitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).ToList()[0] : null;
                        if (lin != null)
                        {
                            Obras_Lineas linsub = (Obr.Capitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).ToList()[0].Subcapitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Subgrupo == sub.Id_Subgrupo).Count() > 0) ? Obr.Capitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Grupo == Grup.Id_Grupo).ToList()[0].Subcapitulos.Where(p => p.Id_Fase == fase).Where(p => p.Id_Subgrupo == sub.Id_Subgrupo).ToList()[0] : null;
                            if (linsub != null)
                            {
                                switch (Obr.campocompara)
                                {
                                    case "CstRealm":
                                        valorsub = linsub.Importe_CosteReal / Convert.ToDecimal(metros);
                                        break;
                                    case "Certm":
                                        valorsub = linsub.Importe_P_venta / Convert.ToDecimal(metros);
                                        break;
                                    case "CostePrevistom":
                                        valorsub = linsub.Importe_CostePrevisto / Convert.ToDecimal(metros);
                                        break;
                                }
                                tsub.SubItems.Add(valorsub);
                            }
                            else
                            {
                                tsub.SubItems.Add(0);
                            }
                        }
                    }
                    tn.Nodes.Add(tsub);
                }
                Multicolumn.Nodes.Add(tn);
            }
            //TOTALES
            Ai.Control.TreeNode tt = new Ai.Control.TreeNode();
            tt = new Ai.Control.TreeNode();
            Elige_Icono(251, tt, img);
            tt.Text = "Total Seguimiento";
            tt.NodeFont = new Font("Verdana", 8.00F, FontStyle.Bold);
            tt.BackColor = Color.LightGray;
            foreach (Obras Obr in Obrs)
            {
                switch (metros_s)
                {
                    case "m_escriturados":
                        metros = Obr.M_Escriturados;
                        break;
                    case "m_construidos":
                        metros = Obr.M_Construidos;
                        break;
                    case "m_utiles":
                        metros = Obr.M_Utiles;
                        break;
                }
                decimal valorsub = 0;
                switch (Obr.campocompara)
                {
                    case "CstRealm":
                        valorsub = Obr.Obras_Lineas.Sum(p=> p.Importe_CosteReal) / Convert.ToDecimal(metros);
                        break;
                    case "Certm":
                        valorsub = Obr.Obras_Lineas.Sum(p => p.Importe_Certificado) / Convert.ToDecimal(metros);
                        break;
                    case "CostePrevistom":
                        valorsub = Obr.Obras_Lineas.Sum(p => p.Importe_CostePrevisto) / Convert.ToDecimal(metros);
                        break;
                }
                tt.SubItems.Add(valorsub);               
            }
            Multicolumn.Nodes.Add(tt);
        }
        #region "Cosas para todo"
        public static List<FacturasDetalles> DevuelveFactuli(Obras Obr,int busqueda, string codpartida, int id_grupo, int? id_subgrupo )
        {
            //0 - busqueda por capitulo
            //1 - Busqueda por id_grupo
            //2-  Busqueda por id_grupo y id_subgrupo
            //3- Busqueda todo
      
            List<FacturasDetalles> Li = new List<FacturasDetalles>();
            List<Facturas_li> LineasdeBusqueda = new List<Facturas_li>();
       
            foreach (Facturas_ca Fac in Obr.Facturas_ca.ToList())
            {             
              
                {
                 
                    switch (busqueda)
                    {
                        case 0:
                            LineasdeBusqueda = Fac.Facturas_li.Where(p => p.Cap_sigrid == codpartida).ToList();
                            break;
                        case 1:
                            LineasdeBusqueda = Fac.Facturas_li.Where(p => p.Id_grupo  == id_grupo).ToList();
                            break;
                        case 2:
                            LineasdeBusqueda = Fac.Facturas_li.Where(p => p.Id_grupo == id_grupo && p.id_subgrupo  == id_subgrupo ).ToList();
                            break;
                        case 3:
                            LineasdeBusqueda = Fac.Facturas_li.ToList();
                            break;

                    }

                    foreach (Facturas_li linea in LineasdeBusqueda)
                    {
                        FacturasDetalles i = Fac.Facturas_li.Select(g => new FacturasDetalles
                        {
                            Fecha = Fac.Fecha,
                            Factura = Fac.Ref_Fac,
                            Proveedor = Fac.Proveedor,
                            Descripcion = linea.Descripcion,
                            Precio = linea.Pre,
                            Cantidad = linea.Cantidad,
                            Importe = linea.Base,
                            Cap_Sigrid = linea.Cap_sigrid
                        }).ToList()[0];
                        Li.Add(i);
                    }
                }
            }
            return Li.ToList();
        }
        public static List<FacturasDetalles> DevuelveAlbaranes(Obras Obr,int busqueda, string codpartida, int id_grupo, int? id_subgrupo)
        {
            List<FacturasDetalles> Li = new List<FacturasDetalles>();
            List<Albaran_li> LineasdeBusqueda = new List<Albaran_li>();
            foreach (Albaranes_ca Alb in Obr.Albaranes_ca.ToList())
            {
                {
                    switch (busqueda)
                    {
                        case 0:
                            LineasdeBusqueda = Alb.Albaran_li.Where(p => p.Cap_sigrid == codpartida).ToList();
                            break;
                        case 1:
                            LineasdeBusqueda = Alb.Albaran_li.Where(p => p.Id_grupo == id_grupo).ToList();
                            break;
                        case 2:
                            LineasdeBusqueda = Alb.Albaran_li.Where(p => p.Id_grupo == id_grupo && p.id_subgrupo == id_subgrupo).ToList();
                            break;
                        case 3:
                            LineasdeBusqueda = Alb.Albaran_li.ToList();
                            break;
                    }
                    
                    foreach (Albaran_li linea in LineasdeBusqueda)
                    {
                        FacturasDetalles i = Alb.Albaran_li.Select(g => new FacturasDetalles
                        {
                            Fecha = Alb.Fecha,
                            Factura = Alb.Ref_Alb,
                            Proveedor = Alb.Proveedor,
                            Descripcion = linea.Descripcion,
                            Precio = linea.Pre,
                            Cantidad = linea.Cantidad,
                            Importe = linea.Base,
                            Cap_Sigrid = linea.Cap_sigrid
                        }).ToList()[0];
                        Li.Add(i);
                    }
                }
            }
            return Li.ToList();
        }
        public static List<FacturasDetalles> DevuelveParteTrabajo(Obras Obr,int busqueda, string codpartida, int id_grupo, int? id_subgrupo)
        {
            List<ParteTrabajo> LineasdeBusqueda = new List<ParteTrabajo>();
            switch (busqueda)
            {
                case 0:
                    LineasdeBusqueda = Obr.ParteTrabajo.Where(p => p.Cap_Sigrid == codpartida).ToList();
                    break;
                case 1:
                    LineasdeBusqueda = Obr.ParteTrabajo.Where(p => p.Id_Grupo == id_grupo).ToList();
                    break;
                case 2:
                    LineasdeBusqueda = Obr.ParteTrabajo.Where(p => p.Id_Grupo == id_grupo && p.Id_Subgrupo == id_subgrupo).ToList();
                    break;
                case 3:
                    LineasdeBusqueda = Obr.ParteTrabajo.ToList();
                    break;

            }
            List<FacturasDetalles> Li = new List<FacturasDetalles>();
            foreach (ParteTrabajo linea in LineasdeBusqueda)
            {
                FacturasDetalles i = Obr.ParteTrabajo.Select(g => new FacturasDetalles
                {
                    Fecha = linea.fecha,
                    Factura = linea.Ref_Parte,
                    Proveedor = linea.Empleado,
                    Descripcion = "",
                    Precio = linea.Precio,
                    Cantidad = Convert.ToInt32(linea.Horas),
                    Importe = linea.TotalImporte,
                    Cap_Sigrid = linea.Cap_Sigrid
                }).ToList()[0];
                Li.Add(i);
            }

            return Li.ToList();
        }
        public static void ExceltoDt(string filename,DataTable dt)
        {
            // Connection String to the previously selected file. 
            // HDR=Yes advises that spreadsheet has columns. 
            DataTable dtExcelSchema;
            string sheet;
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
            + "Data Source=" + filename + ";"
            + "Extended Properties='Excel 12.0 Xml;HDR=No'";
            OleDbConnection con = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            cmdExcel.Connection = con;
            con.Open();        
            dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            con.Close();
            if (dtExcelSchema.Rows.Count == 0) return;
            sheet = dtExcelSchema.Rows[0][2].ToString();                    
            string strSQL = "SELECT * FROM ["+ sheet +"]";
           // The Command that we will use with our DataAdapter.
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
        }
        public static string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        #endregion

    }
}
