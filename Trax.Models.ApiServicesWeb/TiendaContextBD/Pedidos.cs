namespace Trax.Models.ApiServicesWeb.TiendaContextBD
{
   
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Pedidos
    {
        [Key]
        public int id_pedido { get; set; }

        public int? id_cliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_pedido { get; set; }

        public decimal? total { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
