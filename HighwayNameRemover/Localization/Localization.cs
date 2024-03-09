using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using UnityEngine;

namespace HighwayNameRemover
{
	public class Localization
	{
		internal static Dictionary<string, Dictionary<string, string>> localization;

		internal static void AddCustomLocal(LocaleAsset localeAsset)
		{
			if(localization is null) LoadLocalization();

			string loc = localeAsset.localeId;

			if(!localization.ContainsKey(loc)) // Fallback language
				loc = "en-US";

            foreach(string key in localization[loc].Keys)
            {
                if(localeAsset.data.entries.ContainsKey(key))
	                localeAsset.data.entries[key] = localization[loc][key];
                else
	                localeAsset.data.entries.Add(key, localization[loc][key]);

                if(!key.Contains(":")) continue;

                string[] parts = key.Split(":");
                if (int.TryParse(parts[1], out int n))
                {
	                n++;
	                if (localeAsset.data.indexCounts.ContainsKey(parts[0]))
	                {
		                if (localeAsset.data.indexCounts[parts[0]] != n) // Was <
		                {
			                localeAsset.data.indexCounts[parts[0]] = n;
		                }
	                }
	                else localeAsset.data.indexCounts.Add(parts[0], n);
                }
            }

            Debug.Log("Hide Highway Names is " + HighwayNameRemoverController._config.HideHighwayNames);
            Debug.Log("Hide Road Names is " + HighwayNameRemoverController._config.HideRoadNames);
            List<string> keys = new List<string>();
            foreach(string key in localeAsset.data.entries.Keys)
			{
				if (HighwayNameRemoverController._config.HideHighwayNames)
				{
					if (key.Contains("Assets.HIGHWAY_NAME:"))
					{
						//localeAsset.data.entries[key] = "         ";
						keys.Add(key);
					}
				}

				if (HighwayNameRemoverController._config.HideRoadNames)
				{
					string[] names = new string[] { "Assets.STREET_NAME:", "Assets.ALLEY_NAME:", "Assets.BRIDGE_NAME:", "Assets.DAM_NAME" };
					if (Array.Exists(names, element => key.Contains(element)))
					{
						//localeAsset.data.entries[key] = "         ";
						keys.Add(key);
					}
				}
			}

			foreach (string key in keys)
			{
				localeAsset.data.entries[key] = "         ";
			}
		}

		private static void LoadLocalization()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceNames = assembly.GetManifestResourceNames();

			Dictionary<string, Dictionary<string, string>> dictionary = new();
			foreach (var resourceName in resourceNames)
			{
				if (resourceName.EndsWith(".json") && resourceName.Contains(".embedded.Localization."))
				{
					using (Stream stream = assembly.GetManifestResourceStream(resourceName))
					{
						using (StreamReader reader = new StreamReader(stream))
						{
							string result = reader.ReadToEnd();
							LocalizationLocaleJS loc = Decoder.Decode(result).Make<LocalizationLocaleJS>();
							// Get the locale from the filename
							var locale = resourceName.Split(".embedded.Localization.")[1].Split(".json")[0];
							dictionary.Add(locale, loc.Localization);
						}
					}
				}
			}
			localization = dictionary;
		}
	}

	[Serializable]
	public class LocalizationLocaleJS
	{	
		public Dictionary<string, string> Localization;

	}

	public class LocalizationJS
	{
		public Dictionary<string, Dictionary<string, string>> Localization = [];
	}
}