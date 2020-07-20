namespace WowAltsWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JoinCharacter")]
    public partial class JoinCharacter
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Realm { get; set; }

        [StringLength(8)]
        public string Faction { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(12)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string Class { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Spec { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Level { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ilvl { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HoA { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cloak { get; set; }
    }
}
