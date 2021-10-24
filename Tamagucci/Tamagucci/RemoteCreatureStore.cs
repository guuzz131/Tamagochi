using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tamagucci
{
    /*
    class RemoteCreatureStore : Interface1<CreatureStats>
    {
        private HttpClient client = new HttpClient();

        public async Task<bool> CreateItem(CreatureStats item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);

            try
            {
                var response = await client.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureAsText, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string postedCreatureAsText = await response.Content.ReadAsStringAsync();

                    CreatureStats postedCreature = JsonConvert.DeserializeObject<CreatureStats>(postedCreatureAsText);

                    Preferences.Set("MyCreatureID", JsonConvert.ToString(postedCreature));

                    return true;
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
            
        }

        public async Task<bool> DeleteItem(CreatureStats item)
        {
            string httpAddress = "https://tamagotchi.hku.nl/api/creatures/" + Preferences.Get("MyCreatureID", 999);
            await client.DeleteAsync(httpAddress);
            return true;
        }

        public async Task<CreatureStats> ReadItem()
        {
            var httpClient = new HttpClient();

            string httpAddress = "https://tamagotchi.hku.nl/api/creatures/" + Preferences.Get("MyCreatureID", 999);

            var response = await httpClient.GetAsync(httpAddress);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                var creature = JsonConvert.DeserializeObject<CreatureStats>(responseString);

                return creature;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateItem(CreatureStats item)
        {
            string creatureText = JsonConvert.SerializeObject(item);

            var httpClient = new HttpClient();

            string httpAddress = "https://tamagotchi.hku.nl/api/creatures/" + Preferences.Get("MyCreatureID", 999);

            await httpClient.PutAsync(httpAddress, new StringContent(creatureText, Encoding.UTF8, "application/json"));
            
            return true;
        }
    }*/
}
