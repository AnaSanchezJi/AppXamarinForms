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

        public DbSet<eva_cat_espacios> eva_cat_espacios { get; set; }
        public DbSet<eva_cat_edificios> eva_cat_edificios { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<cat_tipos_estatus> cat_tipos_estatus { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //Laves primarias
                modelBuilder.Entity<eva_cat_edificios>()
                    .HasKey(c => new { c.IdEdificio});
                modelBuilder.Entity<eva_cat_espacios>()
                        .HasKey(c => new {c.IdEspacio});

                modelBuilder.Entity<cat_tipos_estatus>()
                  .HasKey(es => new { es.IdTipoEstatus });

                modelBuilder.Entity<cat_estatus>()
                   .HasKey(es => new { es.IdEstatus });

                //Laves foraneas

                modelBuilder.Entity<eva_cat_espacios>()
                .HasOne(s => s.cat_tipos_status).
                WithMany().HasForeignKey(s => new { s.IdEstatus });

                modelBuilder.Entity<eva_cat_espacios>()
                .HasOne(s => s.cat_tipos_status).
                WithMany().HasForeignKey(s => new { s.IdTipoEstatus });


                modelBuilder.Entity<eva_cat_espacios>()
                .HasOne(s => s.eva_cat_edificios).
                WithMany().HasForeignKey(s => new { s.IdEdificio });


                modelBuilder.Entity<cat_estatus>()
                .HasOne(s => s.cat_tipo_estatus).
                WithMany().HasForeignKey(s => new { s.IdTipoEstatus });

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//AL CREAR EL MODELO
    }
}
