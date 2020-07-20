using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowAlts.Models
{
    public partial class Character
    {
        public int Id { get; set; }

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

        public virtual Spec Specs { get; set; }

        public override string ToString()
        {
            return
                $"Your Character: {Name}, {Specs} {Class} on realm {Realm} is a {Faction} character, which is level {Level} with an ILvl of {Ilvl}. Its cloak is rank {Cloak} and HoA is {HoA}";
        }
    }
}
