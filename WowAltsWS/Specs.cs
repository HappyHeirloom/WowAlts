namespace WowAltsWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specs
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string Class { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Spec { get; set; }
    }
}
