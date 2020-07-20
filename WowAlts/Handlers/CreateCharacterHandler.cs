using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WowAlts.Models;
using WowAlts.Service;

namespace WowAlts.Handlers
{
    class CreateCharacterHandler
    {
        public ObservableCollection<Realm> RealmList { get; set; }
        public ObservableCollection<Faction> FactionList { get; set; }
        public ObservableCollection<Class> ClassList { get; set; }
        public ObservableCollection<Specs> SpecList { get; set; }

        public CreateCharacterHandler()
        {
            RealmList = DBHandlerSingleton.Instance.Realms;
            FactionList = DBHandlerSingleton.Instance.Factions;
            ClassList = DBHandlerSingleton.Instance.Classes;
            SpecList = DBHandlerSingleton.Instance.Specs;
        }

        public int FindRealm(string realm)
        {
            return (from realmItem in RealmList 
                where String.Equals(realm, realmItem.Realm1, StringComparison.CurrentCultureIgnoreCase) 
                select realmItem.Id).FirstOrDefault();
        }

        public int FindFaction(string faction)
        {
            return (from factionItem in FactionList
                where String.Equals(faction, factionItem.Faction1, StringComparison.CurrentCultureIgnoreCase)
                select factionItem.Id).FirstOrDefault();
        }
        
        public int FindClass(string wowClass)
        {
            return (from classItem in ClassList
                where string.Equals(wowClass, classItem.Class1, StringComparison.CurrentCultureIgnoreCase)
                select classItem.Id).FirstOrDefault();
        }

        public int FindSpec(string spec)
        {
            return (from specItem in SpecList
                where string.Equals(spec, specItem.Spec, StringComparison.CurrentCultureIgnoreCase)
                select specItem.Id).FirstOrDefault();
        }


        public void CreateCharacter(string name, string realm, string faction, string classid, string spec, int level, int hoa, int cloak)
        {
            var realmId = FindRealm(realm);
            var factionId = FindFaction(faction);
            var classId = FindClass(classid);
            var specId = FindSpec(spec);

            Character newCharacter = new Character() {Name = name, Realm_FK = realmId, Faction_FK = factionId, Class_FK = classId, Class_Spec_FK = specId, Level = level, HoA = hoa, Cloak = cloak};

            PersistencyService.CreateAlt(newCharacter);
        }

    }
}
