using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tamagucci
{
    public class LocalCreatureStore : Interface1<CreatureStats>
    {
        public Task<bool> CreateItem(CreatureStats item)
        {
            string creatureAsText = JsonConvert.SerializeObject(item);
            
            Preferences.Set("MyCreature", creatureAsText);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteItem(CreatureStats item)
        {
            Preferences.Remove("MyCreature");

            return Task.FromResult(true);
        }

        public Task<CreatureStats> ReadItem()
        {
            string creatureAsText = Preferences.Get("MyCreature", "");

            CreatureStats creatureFromText = JsonConvert.DeserializeObject<CreatureStats>(creatureAsText);

            return Task.FromResult(creatureFromText);
        }

        public Task<bool> UpdateItem(CreatureStats item)
        {
            if (Preferences.ContainsKey("MyCreature"))
            {
                string creatureAsText = JsonConvert.SerializeObject(item);

                Preferences.Set("MyCreature", creatureAsText);

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
