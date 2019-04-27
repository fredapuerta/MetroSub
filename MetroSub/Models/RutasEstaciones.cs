namespace MetroSub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RutasEstaciones
    {
        [Key]
        public int IdRutasEstaciones { get; set; }

        public int IdRuta { get; set; }

        public int IdEstacion { get; set; }

        public virtual Estaciones Estaciones { get; set; }

        public virtual Rutas Rutas { get; set; }
    }
}
