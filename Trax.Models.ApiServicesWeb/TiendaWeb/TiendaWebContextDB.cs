using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Trax.Models.ApiServicesWeb.TiendaWeb
{
    public partial class TiendaWebContextDB : DbContext
    {
        public TiendaWebContextDB()
            : base("name=TiendaBdContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.Categoria1)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.IdCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }
    }
}
