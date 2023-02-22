namespace Trax.Models.ApiServicesWeb.TiendaContextBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [Key]
        public int id_producto { get; set; }

        [StringLength(50)]
        public string nombre_producto { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public decimal? precio { get; set; }
    }
}
