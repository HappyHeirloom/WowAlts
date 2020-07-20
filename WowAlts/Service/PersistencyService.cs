using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WowAlts.Models;

namespace WowAlts.Service
{
    class PersistencyService
    {
        const string serverUrl = "http://localhost:51887/";
        public static ObservableCollection<JoinCharacter> characterList { get; set; }
        public static ObservableCollection<Realm> realmList { get; set; }
        public static ObservableCollection<Faction> factionList { get; set; }
        public static ObservableCollection<Class> classList { get; set; }
        public static ObservableCollection<Specs> specList { get; set; }

        public static async void CreateAlt(Character character)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/Characters", character).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static async Task<ObservableCollection<JoinCharacter>> LoadCharacters()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                characterList = new ObservableCollection<JoinCharacter>();

                try
                {
                    var response = client.GetAsync("api/JoinCharacters").Result;
                    var characters = response.Content.ReadAsAsync<IEnumerable<JoinCharacter>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var item in characters)
                        {
                            characterList.Add(item);
                        }
                        return characterList;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public static async Task<ObservableCollection<Realm>> LoadRealms()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                realmList = new ObservableCollection<Realm>();

                try
                {
                    var response = client.GetAsync("api/Realms").Result;
                    var realms = response.Content.ReadAsAsync<IEnumerable<Realm>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var item in realms)
                        {
                            realmList.Add(item);
                        }
                        return realmList;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public static async Task<ObservableCollection<Faction>> LoadFactions()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                factionList = new ObservableCollection<Faction>();

                try
                {
                    var response = client.GetAsync("api/Factions").Result;
                    var factions = response.Content.ReadAsAsync<IEnumerable<Faction>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var faction in factions)
                        {
                            factionList.Add(faction);
                        }
                        return factionList;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public static async Task<ObservableCollection<Class>> LoadClasses()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                classList = new ObservableCollection<Class>();

                try
                {
                    var response = client.GetAsync("api/Classes").Result;
                    var classes = response.Content.ReadAsAsync<IEnumerable<Class>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var classItem in classes)
                        {
                            classList.Add(classItem);
                        }
                        return classList;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public static async Task<ObservableCollection<Specs>> LoadSpecs()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                specList = new ObservableCollection<Specs>();

                try
                {
                    var response = client.GetAsync("api/SpecsView").Result;
                    var specs = response.Content.ReadAsAsync<IEnumerable<Specs>>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        foreach (var specItem in specs)
                        {
                            specList.Add(specItem);
                        }
                        return specList;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }
    }
}
