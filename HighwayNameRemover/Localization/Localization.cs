using System;
using System.Collections.Generic;
using Colossal.IO.AssetDatabase;
using UnityEngine;

namespace HighwayNameRemover.Localization
{
	public class Localization
	{
		internal static void AddCustomLocal(LocaleAsset localeAsset)
		{
			Debug.Log("Adding custom localization");
            List<string> typesToRemove = new List<string>();
			var cfg = HighwayNameRemoverController._config;
			if (cfg.HideStreetNames)
				typesToRemove.Add("Assets.STREET_NAME:");
			if (cfg.HideHighwayNames)
				typesToRemove.Add("Assets.HIGHWAY_NAME:");
			if (cfg.HideAlleyNames)
				typesToRemove.Add("Assets.ALLEY_NAME:");
			if (cfg.HideBridgeNames)
				typesToRemove.Add("Assets.BRIDGE_NAME:");
			if (cfg.HideDamNames)
				typesToRemove.Add("Assets.DAM_NAME:");


            List<string> keys = new List<string>();
            foreach(string key in localeAsset.data.entries.Keys)
			{
				if (Array.Exists(typesToRemove.ToArray(), element => key.Contains(element)))
				{
					keys.Add(key);
				}
			}

			foreach (string key in keys)
			{
				Debug.Log("Key replaced");
				localeAsset.data.entries[key] = "         ";
			}
		}
	}
}