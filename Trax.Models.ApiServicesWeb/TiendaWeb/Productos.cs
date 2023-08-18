namespace Trax.Models.ApiServicesWeb.TiendaWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int IdCategoria { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
