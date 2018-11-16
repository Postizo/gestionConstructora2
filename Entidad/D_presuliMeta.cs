using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{   
        public partial class D_Presuli
    {    
       // public decimal coste { get; set; }
        public decimal Gastos_Generales { get; set; }
        public decimal Beneficio { get; set; }
        public decimal MargenMaterial { get; set; }
        public decimal Tot_Unidad { get; set; }
        public decimal total { get; set; }
        public int Mo_Total { get; set; }
        public decimal Mo_Impor { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public decimal T_programacion { get; set; }
        public decimal T_volcado { get; set; }
        public decimal T_instalacion { get; set; }
        public decimal T_puestamarcha { get; set; }


        public void calculos()
        {
            //coste = this.D_Equipos.Pvp * (1 - this.D_Equipos.D_provee.descuento);
            Mo_Total = (this.D_Equipos.T_instalacion + this.D_Equipos.T_programacion + this.D_Equipos.T_puestamarcha + this.D_Equipos.T_volcado);
            Mo_Impor = (Convert.ToDecimal(Mo_Total)/60) * this.D_Presuca.CosteProgramador;
            Gastos_Generales = (Costo + Mo_Impor) * this.D_Presuca.GG;
            Beneficio = (Costo + Mo_Impor + Gastos_Generales) * this.D_Presuca.Beneficio;
            MargenMaterial = Costo * this.D_Presuca.MargenMat;
            Tot_Unidad = Math.Round(Costo,2) + Math.Round(Mo_Impor, 2) + Math.Round(Gastos_Generales, 2) + Math.Round(Beneficio, 2) + Math.Round(MargenMaterial,2);         
            total = this.unidades * Tot_Unidad;

            T_programacion = (Convert.ToDecimal (this.D_Equipos.T_programacion) / 60)  * this.D_Presuca.CosteProgramador;
            T_volcado = (Convert.ToDecimal(this.D_Equipos.T_volcado) / 60) * this.D_Presuca.CosteProgramador; 
            T_instalacion = (Convert.ToDecimal(this.D_Equipos.T_instalacion) / 60) * this.D_Presuca.CosteProgramador; 
            T_puestamarcha = (Convert.ToDecimal(this.D_Equipos.T_puestamarcha) / 60) * this.D_Presuca.CosteProgramador;
            Nombre = this.D_Equipos.Nombre;
            Alias = this.D_Equipos.N_Alternativo;
        }
    }

}
