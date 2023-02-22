using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Trax.Models.ApiServicesWeb.TiendaContextBD
{
    public partial class TiendaBdContext : DbContext
    {
        public TiendaBdContext()
            : base("name=TiendaBdContext")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.nombre_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.email_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.telefono_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.calle)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.num_exterior)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.num_interior)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.colonia)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.codigo_postal)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Direcciones>()
                .Property(e => e.pais)
                .IsUnicode(false);

            modelBuilder.Entity<Pedidos>()
                .Property(e => e.total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre_producto)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.precio)
                .HasPrecision(10, 2);
        }
    }
}
