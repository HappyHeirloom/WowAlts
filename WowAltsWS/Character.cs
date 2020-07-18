namespace WowAltsWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Character")]
    public partial class Character
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string Name { get; set; }

        public int Realm_FK { get; set; }

        public int Faction_FK { get; set; }

        public int Class_FK { get; set; }

        public int Class_Spec_FK { get; set; }

        public int Level { get; set; }

        public int Ilvl { get; set; }

        public int HoA { get; set; }

        public int Cloak { get; set; }

        public virtual Class Class { get; set; }

        public virtual Faction Faction { get; set; }

        public virtual Realm Realm { get; set; }

        public virtual Spec Spec { get; set; }
    }
}
