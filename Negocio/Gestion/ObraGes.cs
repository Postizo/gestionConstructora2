using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Negocio.Gestion
{
    public class ObraGes
    {
        // lista de atributos con setters y getters

        public ObservableCollection<Capitulo> Children { get; set; }
        public int Ide { get; set; }
        public string cod { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Imp_Presupuestado { get; set; }
        public double Imp_Coste { get; set; }
        public double Imp_Oferta { get; set; }
        public double Imp_Venta { get; set; }
        public double Desv_Propia { get; set; }
        public double Desv_Propia_Por { get; set; }
        public double Desv_Venta { get; set; }
        public List<Fase> Fases { get; set; }
        public List<Capitulo> Capitulos { get; set; }
        public int estudio { get; set; }
        public int oferta { get; set; }
        // métodos
        public ObraGes()
        {
            Capitulos = new List<Capitulo>();
            Fases = new List<Fase>();
            Children = new ObservableCollection<Capitulo>();
        }

        public DataTable Listar(String Filtro)
        {
            Conexion.IniciarSesion("192.0.0.181", "Eunate", "Fernando", "8080");
            return Conexion.GDatos.TraerDataTableSql("SELECT o.ide,c.cod, c.res,o.dir1 FROM obr o, con c WHERE c.ide = o.ide " + Filtro);
        }

        public ObraGes(int Ide, int fas)
        {
            Conexion.IniciarSesion("192.0.0.181", "Eunate", "Fernando", "8080");
            Capitulos = new List<Capitulo>();
            Fases = new List<Fase>();
            Children = new ObservableCollection<Capitulo>();
            AgregaFasesd(Ide);

            DataTable dtobra = Conexion.GDatos.TraerDataTableSql("SELECT o.ide,c.cod, c.res,o.dir1 FROM obr o, con c WHERE c.ide = o.ide AND o.ide = " + Ide.ToString() + "");
            DataTable dtcapitulos = Conexion.GDatos.TraerDataTableSql("Select * FROM Obrparpar where obride = " + Ide.ToString() + " AND tip = 0 AND padide = 0  ORDER By pos");
            DataTable dtversionestudio = Conexion.GDatos.TraerDataTableSql("SELECT top 1 fas FROM obrparpre WHERE  obride = " + Ide.ToString() +" and tipdes = 0 AND amb =2 ORDER BY fas desc");
            DataTable dtoferta = Conexion.GDatos.TraerDataTableSql("SELECT top 1 fas FROM obrparpre WHERE  obride = " + Ide.ToString() + " and tipdes = 0 AND amb =3 ORDER BY fas desc");
            estudio = 0;
            oferta = 0;
            if (dtversionestudio.Rows.Count > 0) estudio = Convert.ToInt32(dtversionestudio.Rows[0][0]);
            if (dtoferta.Rows.Count > 0) oferta = Convert.ToInt32(dtoferta.Rows[0][0]);

            if (dtobra.Rows.Count == 0) return;

            Ide = Convert.ToInt32(dtobra.Rows[0][0]);
            cod = Convert.ToString(dtobra.Rows[0][1]);
            Nombre = Convert.ToString(dtobra.Rows[0][2]);
            Direccion = Convert.ToString(dtobra.Rows[0][2]);

            //Insertamos los capitulos 
            int n = 123;

            foreach (DataRow row in dtcapitulos.Rows)
            {

              if (Convert.ToString(row["cod"]) == "" ) row["cod"] = "CD";
                if (int.TryParse(Convert.ToString(row["cod"]).Substring(0, 1), out n) == false)
                {
                    ///////////////////////////DESGLOSADAS cuando ponen lo de CD//////////////////////////////////////
                    if (Convert.ToInt32(row["tipcos"]) == 2)
                    {
                        //para coger los gastos PROPORCIONALES
                        Capitulos.Add(addCapitulos(row, Ide));
                        CalculosTotales(fas);
                    }
                    DataTable dtcapitulosdesglosados = Conexion.GDatos.TraerDataTableSql("Select * FROM Obrparpar where obride = " + Ide + " AND padide = " + Convert.ToInt32(row["Ide"]) + "  ORDER By Cod");
                    foreach (DataRow r in dtcapitulosdesglosados.Rows)
                    {
                        //Cuando tiene desglose por capitulos
                        DataTable dtcapitulosdesglosa = Conexion.GDatos.TraerDataTableSql("Select * FROM Obrparpar where obride = " + Ide + " AND padide = " + Convert.ToInt32(r["Ide"]) + "  ORDER By Cod");
                        Capitulos.AddRange(addCapitulos(dtcapitulosdesglosa, Ide));
                    }
                    CalculosTotales(fas);
                }
                else
                {
                    //cuando no tiene desglose
                    Capitulos.Add(addCapitulos(row, Ide));
                    CalculosTotales(fas);
                }
            }
            Conexion.FinalizarSesion();
        }
        public void AgregaFasesd(int Ide)
        {

            DataTable dtfases = Conexion.GDatos.TraerDataTableSql("SELECT ide, obride, mes, ano,CAST(CAST(fecini as varchar(10)) as date) as 'fecini',CAST(CAST(fecfin as varchar(10)) as date) as 'fecfin', res, tex, fasnum, numedi FROM obrfas WHERE obride = " + Ide.ToString() + "ORDER BY fasnum");
            Fase Fas0 = new Fase();
            Fas0.Ide = 0; ;
            Fas0.Nombre = "GENERAL";
            Fas0.Mes = 0;
            Fas0.Año = 0;
            Fas0.fasnum = 0;
            Fases.Add(Fas0);

            foreach (DataRow row in dtfases.Rows)
            {
                Fase Fas = new Fase();
                Fas.Ide = Convert.ToInt32(row["Ide"]);
                Fas.Nombre = Convert.ToString(row["res"]);
                Fas.Mes = Convert.ToInt32(row["mes"]);
                Fas.Año = Convert.ToInt32(row["ano"]);
                Fas.F_inicio = Convert.ToDateTime(row["fecini"]);
                Fas.F_fin = Convert.ToDateTime(row["fecfin"]);
                Fas.fasnum = Convert.ToInt32(row["fasnum"]);
                Fases.Add(Fas);
            }
        }
        public List<Capitulo> addCapitulos(DataTable Data_Capitulos, int idobra)
        {
            List<Capitulo> l = new List<Capitulo>();
            foreach (DataRow Fila_Capitulo in Data_Capitulos.Rows)
            {
                var Capitulo = new Capitulo();
                Capitulo.Ide = Convert.ToInt32(Fila_Capitulo["Ide"]);
                Capitulo.Tipo = Convert.ToInt32(Fila_Capitulo["tip"]);
                Capitulo.Cod = Convert.ToString(Fila_Capitulo["cod"]);
                Capitulo.Nombre = Convert.ToString(Fila_Capitulo["res"]);
                Capitulo.Texto = Convert.ToString(Fila_Capitulo["tex"]);
                if (Capitulo.SubCapitulos.Count == 0)
                {
                    AddPartida(Fila_Capitulo, Capitulo);
                }
                AddSubcapitulos(Capitulo, idobra);
                l.Add(Capitulo);
            }
            return l;
        }
        public Capitulo addCapitulos(DataRow Fila_Cap, int idobra)
        {
            var Capitulo = new Capitulo();
            Capitulo.Ide = Convert.ToInt32(Fila_Cap["Ide"]);
            Capitulo.Tipo = Convert.ToInt32(Fila_Cap["tip"]);
            Capitulo.Cod = Convert.ToString(Fila_Cap["cod"]);
            Capitulo.Nombre = Convert.ToString(Fila_Cap["res"]);
            Capitulo.Texto = Convert.ToString(Fila_Cap["tex"]);
            if (Capitulo.SubCapitulos.Count == 0) { AddPartida(Fila_Cap, Capitulo); }
            AddSubcapitulos(Capitulo, idobra);
            return Capitulo;
        }
        public List<Capitulo> AddSubcapitulos(Capitulo Capitulo, int idobra)
        {
            List<Capitulo> l = new List<Capitulo>();
            DataTable dtsubcapitulos = Conexion.GDatos.TraerDataTableSql("Select * FROM Obrparpar where obride = " + idobra + " AND padide = " + Capitulo.Ide + "  ORDER By Cod");

            foreach (DataRow subca in dtsubcapitulos.Rows)
            {
                var Subcapitulo = new Capitulo();
                if ((Int32)subca["tip"] == 0)
                {

                    Subcapitulo.Ide = Convert.ToInt32(subca["Ide"]);
                    Subcapitulo.Tipo = Convert.ToInt32(subca["tip"]);
                    Subcapitulo.Cod = Convert.ToString(subca["cod"]);
                    Subcapitulo.Nombre = Convert.ToString(subca["res"]);
                    Subcapitulo.Texto = Convert.ToString(subca["tex"]);
                    AddSubcapitulos(Subcapitulo, idobra);
                    Capitulo.SubCapitulos.Add(Subcapitulo);
                }
                else
                {
                    //Traemos las partidas de los capitulos normales
                    AddPartida(subca, Capitulo);
                }
                l.Add(Subcapitulo);
            }
            return l;
        }

        public void AddPartida(DataRow fila, Capitulo Cap)
        {
            DataTable dtpartidascapitulos = Conexion.GDatos.TraerDataTableSql("SELECT * FROM obrparpre  WHERE paride = " + fila["Ide"].ToString() + " and tipdes = 0 ORDER BY fas,amb");          
            if (dtpartidascapitulos.Rows.Count == 0) return;
            foreach (Fase fas in Fases.OrderBy(p => p.fasnum))
            {
                Partida Partida = new Partida();
                Partida.Ide = Convert.ToInt32(fila["Ide"]);
                Partida.Tipo = Convert.ToInt32(fila["tipcos"]);
                Partida.Cod = Convert.ToString(fila["cod"]);
                Partida.Nombre = Convert.ToString(fila["res"]);
                Partida.Texto = Convert.ToString(fila["tex"]);
                Partida.Fas = fas.fasnum;               
                
                if (Cap.Partidas.Exists(x => x.Fas == estudio && x.Ide == Partida.Ide))
                {
                    Partida.Imp_Presupuestado = Cap.Partidas.Find(x => x.Fas == estudio && x.Ide == Partida.Ide).Imp_Presupuestado;
                    Partida.Pre_Presupuestado = Cap.Partidas.Find(x => x.Fas == estudio && x.Ide == Partida.Ide).Pre_Presupuestado;
                    Partida.Can_Presupuestado = Cap.Partidas.Find(x => x.Fas == estudio && x.Ide == Partida.Ide).Can_Presupuestado;                   
                }
                else
                {
                    Partida.Imp_Presupuestado = 0;
                    Partida.Pre_Presupuestado = 0;
                    Partida.Can_Presupuestado = 0;
                }

                if (Cap.Partidas.Exists(x => x.Fas == oferta && x.Ide == Partida.Ide))
                {                  

                    Partida.Imp_Oferta = Cap.Partidas.Find(x => x.Fas == oferta && x.Ide == Partida.Ide).Imp_Oferta;
                    Partida.Pre_Oferta = Cap.Partidas.Find(x => x.Fas == oferta && x.Ide == Partida.Ide).Pre_Oferta;
                    Partida.Can_Oferta = Cap.Partidas.Find(x => x.Fas == oferta && x.Ide == Partida.Ide).Can_Oferta;
                }
                else
                {  
                    Partida.Imp_Oferta = 0;
                    Partida.Pre_Oferta = 0;
                    Partida.Can_Oferta = 0;
                }
                
                var results = from myRow in dtpartidascapitulos.AsEnumerable()
                              where myRow.Field<int>("fas") == fas.fasnum
                              select myRow;


                ///if (results.Count() == 0) continue;
                foreach (DataRow fila1 in results)
                {

                    if (Convert.ToInt32(fila1["amb"]) == 2)
                    {

                        Partida.Imp_Presupuestado = Math.Round(Math.Round(Convert.ToDouble(fila1["can"]), 2) * Math.Round(Convert.ToDouble(fila1["pre"]), 2), 2);
                        Partida.Pre_Presupuestado = Convert.ToDouble(fila1["pre"]);
                        Partida.Can_Presupuestado = Convert.ToDouble(fila1["can"]);

                    }

                    if (Convert.ToInt32(fila1["amb"]) == 5)
                    {

                        Partida.Imp_Coste = Math.Round(Math.Round(Convert.ToDouble(fila1["can"]), 2) * Math.Round(Convert.ToDouble(fila1["pre"]), 2), 2);
                        Partida.Pre_Coste = Convert.ToDouble(fila1["pre"]);
                        Partida.Can_Coste = Convert.ToDouble(fila1["can"]);

                    }

                    if (Convert.ToInt32(fila1["amb"]) == 3)
                    {
                        Partida.Imp_Oferta = Math.Round(Math.Round(Convert.ToDouble(fila1["can"]), 2) * Math.Round(Convert.ToDouble(fila1["pre"]), 2), 2);
                        Partida.Pre_Oferta = Convert.ToDouble(fila1["pre"]);
                        Partida.Can_Oferta = Convert.ToDouble(fila1["can"]);

                    }

                    if (Convert.ToInt32(fila1["amb"]) == 6)
                    {
                        Partida.Imp_Venta = Math.Round(Math.Round(Convert.ToDouble(fila1["can"]), 2) * Math.Round(Convert.ToDouble(fila1["pre"]), 2), 2);
                        Partida.Pre_Venta = Convert.ToDouble(fila1["pre"]);
                        Partida.Can_Venta = Convert.ToDouble(fila1["can"]);
                    }
                }

                // if (fila["res"] == null || fila["res"].ToString() == "") continue;
                Partida.CalculosTotales();
                Cap.Partidas.Add(Partida);

            }
        }

        public void CalculosTotales(int fas)
        {
            Imp_Presupuestado = 0;
            Imp_Oferta = 0;

            Imp_Venta = 0;
            Imp_Coste = 0;
            foreach (Capitulo Cap in Capitulos)
            {
                Cap.CalculosTotales(fas);
                Imp_Presupuestado += Cap.Imp_Presupuestado;
                Imp_Oferta += Cap.Imp_Oferta;

                Imp_Venta += Cap.Imp_Venta;
                Imp_Coste += Cap.Imp_Coste;
            }
            Desv_Propia = Math.Round(Imp_Presupuestado - Imp_Coste, 2);
            Desv_Propia_Por = Math.Round((Desv_Propia) / Imp_Presupuestado, 2);
        }




    }
    public class Capitulo
    {
        public int Ide { get; set; }
        public int Tipo { get; set; }
        public string Cod { get; set; }
        public string Nombre { get; set; }
        public string Texto { get; set; }
        public double Imp_Presupuestado { get; set; }
        public double Imp_Coste { get; set; }
        public double Imp_Oferta { get; set; }

        public double Imp_Venta { get; set; }
        public double Desv_Propia { get; set; }
        public double Desv_Propia_Por { get; set; }
        public double Desv_Venta { get; set; }
        public List<Partida> Partidas { get; set; }
        public List<Capitulo> SubCapitulos { get; set; }
        public Capitulo()
        {
            Partidas = new List<Partida>();
            SubCapitulos = new List<Capitulo>();
        }
        public void i()
        {
            if (SubCapitulos.Count > 0)
            {
                foreach (Capitulo Subcap in SubCapitulos)
                {
                    Subcap.CalculosTotales(0);
                }

            }
        }
        public void CalculosTotales(int fas)
        {
            Desv_Propia = 0;
            Desv_Propia_Por = 0;
            Imp_Presupuestado = 0;
            Imp_Oferta = 0;
            Imp_Venta = 0;
            Imp_Coste = 0;
            i();

            if (SubCapitulos.Count > 0)
            {
                foreach (Capitulo Subcap in SubCapitulos)
                {
                    Imp_Presupuestado += Subcap.Imp_Presupuestado;
                    Imp_Oferta += Subcap.Imp_Oferta;

                    Imp_Venta += Subcap.Imp_Venta;
                    Imp_Coste += Subcap.Imp_Coste;
                }
                foreach (Partida Par in DevuelvePartidas(fas))
                {
                    Imp_Presupuestado += Par.Imp_Presupuestado;
                    Imp_Oferta += Par.Imp_Oferta;

                    Imp_Venta += Par.Imp_Venta;
                    Imp_Coste += Par.Imp_Coste;
                }

            }
            else
            {
                foreach (Partida Par in DevuelvePartidas(fas))
                {
                    Imp_Presupuestado += Par.Imp_Presupuestado;
                    Imp_Oferta += Par.Imp_Oferta;

                    Imp_Venta += Par.Imp_Venta;
                    Imp_Coste += Par.Imp_Coste;
                }
            }

            if (Imp_Presupuestado != 0 && Imp_Coste != 0)
            {
                Desv_Propia = Math.Round(Imp_Presupuestado - Imp_Coste, 2);
                Desv_Propia_Por = Math.Round((Desv_Propia) / Imp_Presupuestado, 2);
            }

            if (Imp_Presupuestado != 0 && Imp_Coste != 0)
            {
                Desv_Propia = Math.Round(Imp_Presupuestado - Imp_Coste, 2);
                Desv_Propia_Por = Math.Round((Desv_Propia) / Imp_Presupuestado, 2);
            }
        }

        public List<Partida> DevuelvePartidas(int fas)
        {
            List<Partida> list = Partidas.FindAll(x => x.Fas == fas);
            return list;
        }
    }
    public class Partida
    {
        public int Ide { get; set; }
        public int Tipo { get; set; }
        public string Cod { get; set; }
        public string Nombre { get; set; }
        public string Texto { get; set; }
        public int Fas { get; set; }
        public double Imp_Presupuestado { get; set; }
        public double Pre_Presupuestado { get; set; }
        public double Can_Presupuestado { get; set; }
        public double Imp_Coste { get; set; }
        public double Pre_Coste { get; set; }
        public double Can_Coste { get; set; }

        public double Imp_Oferta { get; set; }
        public double Pre_Oferta { get; set; }
        public double Can_Oferta { get; set; }

        public double Imp_Gastado { get; set; }
        public double Pre_Gastado { get; set; }
        public double Can_Gastado { get; set; }
        public double Imp_Venta { get; set; }
        public double Pre_Venta { get; set; }
        public double Can_Venta { get; set; }
        public double Des_propia { get; set; }
        public double Desv_Propia { get; set; }
        public double Desv_Propia_Por { get; set; }
        public double Desv_Venta { get; set; }
        public List<Listadetalles> Lista_Det { get; set; }
        public Partida()

        {
            Lista_Det = new List<Listadetalles>();
        }
        public void CalculosTotales()
        {
            Desv_Propia = Math.Round(Imp_Presupuestado - Imp_Gastado, 2);
            Desv_Propia_Por = Math.Round(((Desv_Propia) / Imp_Presupuestado) * 100, 2);
        }

        public class Listadetalles
        {
            public int Amb { get; set; }
            public int Fase { get; set; }
            public double Cantidad { get; set; }
            public double Precio { get; set; }
        }
    }
    public class Fase
    {
        public int Ide { get; set; }
        public string Nombre { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public int fasnum { get; set; }
        public DateTime F_inicio { get; set; }
        public DateTime F_fin { get; set; }




    }

}







