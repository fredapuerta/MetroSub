namespace MetroSub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estaciones
    {
        [Key]
        public int IdEstacion { get; set; }

        public int NumeroEstacion { get; set; }
    }
}
