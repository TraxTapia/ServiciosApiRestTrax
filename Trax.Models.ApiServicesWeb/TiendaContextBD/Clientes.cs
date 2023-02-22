namespace Trax.Models.ApiServicesWeb.TiendaContextBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Direcciones = new HashSet<Direcciones>();
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int id_cliente { get; set; }

        [StringLength(50)]
        public string nombre_cliente { get; set; }

        [StringLength(50)]
        public string email_cliente { get; set; }

        [StringLength(20)]
        public string telefono_cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_registro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direcciones> Direcciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
