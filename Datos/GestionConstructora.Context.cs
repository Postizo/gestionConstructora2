﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Entidad;
    public partial class GestionConstructoraEntities : DbContext
    {
        public GestionConstructoraEntities()
            : base("name=GestionConstructoraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Albaran_li> Albaran_li { get; set; }
        public virtual DbSet<Albaranes_ca> Albaranes_ca { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Balance_Fijos> Balance_Fijos { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<D_Equipos> D_Equipos { get; set; }
        public virtual DbSet<D_Familias> D_Familias { get; set; }
        public virtual DbSet<D_Presuca> D_Presuca { get; set; }
        public virtual DbSet<D_Presuli> D_Presuli { get; set; }
        public virtual DbSet<D_provee> D_provee { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Est_Financiero> Est_Financiero { get; set; }
        public virtual DbSet<Est_Tesoreria> Est_Tesoreria { get; set; }
        public virtual DbSet<Est_TesoreriaMes> Est_TesoreriaMes { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Facturas_ca> Facturas_ca { get; set; }
        public virtual DbSet<Facturas_li> Facturas_li { get; set; }
        public virtual DbSet<Gastos_Fijos> Gastos_Fijos { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Grupos_Rel> Grupos_Rel { get; set; }
        public virtual DbSet<Log_Errores> Log_Errores { get; set; }
        public virtual DbSet<Obras> Obras { get; set; }
        public virtual DbSet<Obras_Lineas> Obras_Lineas { get; set; }
        public virtual DbSet<ParteTrabajo> ParteTrabajo { get; set; }
        public virtual DbSet<Presu_Calidad> Presu_Calidad { get; set; }
        public virtual DbSet<Presu_Conta> Presu_Conta { get; set; }
        public virtual DbSet<Presu_Elem_Estan> Presu_Elem_Estan { get; set; }
        public virtual DbSet<Presu_Elementos> Presu_Elementos { get; set; }
        public virtual DbSet<Presu_Estancias> Presu_Estancias { get; set; }
        public virtual DbSet<Presu_Presu_Ca> Presu_Presu_Ca { get; set; }
        public virtual DbSet<Presu_Presu_li> Presu_Presu_li { get; set; }
        public virtual DbSet<Subgrupos> Subgrupos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Aux_PrefCuentas> Aux_PrefCuentas { get; set; }
        public virtual DbSet<Certificaciones> Certificaciones { get; set; }
        public virtual DbSet<F_MaestraSubPartidas> F_MaestraSubPartidas { get; set; }
        public virtual DbSet<F_PlanigPartidas> F_PlanigPartidas { get; set; }
        public virtual DbSet<F_Renta_MarKara> F_Renta_MarKara { get; set; }
        public virtual DbSet<Produ_Alcosan> Produ_Alcosan { get; set; }
        public virtual DbSet<Puertas> Puertas { get; set; }
        public virtual DbSet<TarifasProvee> TarifasProvee { get; set; }
    }
}
