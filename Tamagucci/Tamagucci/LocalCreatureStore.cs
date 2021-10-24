using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Tamagucci
{
    public class LocalCreatureStore : Interface1<CreatureStats>
    {
		public bool CreateItem(CreatureStats item)
		{
			string creatureAsText = JsonConvert.SerializeObject(item);

			Preferences.Set("MyCreature", creatureAsText);

			return true;
		}

		public bool DeleteItem(CreatureStats item)
		{
			Preferences.Remove("MyCreature");

			return true;
		}

		public CreatureStats ReadItem()
		{
			string creatureAsText = Preferences.Get("MyCreature", "");

			CreatureStats creatureFromText = JsonConvert.DeserializeObject<CreatureStats>(creatureAsText);

			return creatureFromText;
		}

		public bool UpdateItem(CreatureStats item)
		{
			if (Preferences.ContainsKey("MyCreature"))
			{
				string creatureAsText = JsonConvert.SerializeObject(item);

				Preferences.Set("MyCreature", creatureAsText);

				return true;
			}

			return false;
		}
	}
}
