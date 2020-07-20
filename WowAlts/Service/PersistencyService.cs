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

    }
}
