using System;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using AppXamarinForms.Models;

namespace AppXamarinForms.Data
{
    public class FicDBContext : DbContext
    {
        private readonly string FicDataBasePath;

        public FicDBContext (string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearDB();
        }
        public FicDBContext(DbContextOptions<FicDBContext> options) : base(options)
        {

        }
        private async void FicMetCrearDB()
        {
            try
            {
                //FIC: Se crea la base de datos en base el esquema
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//ESTE METODO CREA LA BASE DE DATOS
        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={FicDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//CONFIGURACION DE LA CONEXION

        public DbSet<eva_alumnos_carreras> eva_alumnos_carreras { get; set; }
        public DbSet<eva_cat_carreras> eva_cat_carreras { get; set; }
        public DbSet<eva_cat_especialidades> eva_cat_especialidades { get; set; }
        public DbSet<eva_cat_reticulas> eva_cat_reticulas { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<rh_cat_alumnos> rh_cat_alumnos { get; set; }
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //LLaves primarias
                modelBuilder.Entity<eva_alumnos_carreras>().HasKey(tg => new {tg.IdAlumno,tg.IdCarrera});
                modelBuilder.Entity<cat_generales>().HasKey(ge => new { ge.IdGeneral, ge.IdTipoGeneral });
                modelBuilder.Entity<eva_cat_carreras>().HasKey(ca => new {ca.IdCarrera });                
                modelBuilder.Entity<cat_periodos>().HasKey(pe => new { pe.IdPeriodo });
                modelBuilder.Entity<cat_tipos_generales>().HasKey(tg => new { tg.IdTipoGeneral });                
                modelBuilder.Entity<eva_cat_especialidades>().HasKey(es => new { es.IdEspecialidad });
                modelBuilder.Entity<eva_cat_reticulas>().HasKey(re => new { re.IdReticula });
                modelBuilder.Entity<rh_cat_alumnos>().HasKey(re => new { re.IdAlumno});
                modelBuilder.Entity<rh_cat_personas>().HasKey(cp => new { cp.IdPersona });
                
     
                //LLaves foraneas
                modelBuilder.Entity<rh_cat_personas>().HasOne(s => s.rh_cat_alumnos).WithMany().HasForeignKey(s => s.IdPersona);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(fk => fk.rh_cat_personas).WithMany().HasForeignKey(fk => fk.IdAlumno);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.carreras).WithMany().HasForeignKey(s => s.IdCarrera);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.eva_cat_reticulas).WithMany().HasForeignKey(s => s.IdReticula);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.eva_cat_especialidades).WithMany().HasForeignKey(s => s.IdEspecialidad);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.cat_periodosI).WithMany().HasForeignKey(s => s.IdPeriodoIngreso);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.cat_periodosU).WithMany().HasForeignKey(s => s.IdPeriodoUltimo);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.cat_periodosT).WithMany().HasForeignKey(s => s.IdPeriodoTitulacion);

                //modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.tipo_generalI).WithMany().HasForeignKey(s => s.IdTipoGenIngreso);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.generalI).WithMany().HasForeignKey(s => new { s.IdGenIngreso, s.IdTipoGenIngreso});
                //modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.tipo_generalNE).WithMany().HasForeignKey(s =>);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.generalNE).WithMany().HasForeignKey(s => new { s.IdGenNivelEscolar, s.IdTipoGenNivelEscolar });
                //modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.tipo_generalT).WithMany().HasForeignKey(s => s.IdTipoGenOpcionTitulacion);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.generalT).WithMany().HasForeignKey(s => new { s.IdGenOpcionTitulacion, s.IdTipoGenOpcionTitulacion });
                //modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.tipo_generalPE).WithMany().HasForeignKey(s => s.IdTipoGenPlanEstudio);
                modelBuilder.Entity<eva_alumnos_carreras>().HasOne(s => s.generalPE).WithMany().HasForeignKey(s => new { s.IdGenPlanEstudio, s.IdTipoGenPlanEstudio });                


            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//AL CREAR EL MODELO
    }
}
