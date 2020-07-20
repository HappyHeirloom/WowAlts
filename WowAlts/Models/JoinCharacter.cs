using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowAlts.Models
{
    public partial class JoinCharacter
    {
        public int Id { get; set; }

        public string Realm { get; set; }

        public string Faction { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Spec { get; set; }

        public int Level { get; set; }

        public int Ilvl { get; set; }

        public int HoA { get; set; }

        public int Cloak { get; set; }
    }
}
