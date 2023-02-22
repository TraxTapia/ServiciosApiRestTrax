namespace Trax.Models.ApiServicesWeb.TiendaContextBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Direcciones
    {
        [Key]
        public int id_direccion { get; set; }

        public int? id_cliente { get; set; }

        [StringLength(50)]
        public string calle { get; set; }

        [StringLength(10)]
        public string num_exterior { get; set; }

        [StringLength(10)]
        public string num_interior { get; set; }

        [StringLength(50)]
        public string colonia { get; set; }

        [StringLength(10)]
        public string codigo_postal { get; set; }

        [StringLength(50)]
        public string ciudad { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        [StringLength(50)]
        public string pais { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
