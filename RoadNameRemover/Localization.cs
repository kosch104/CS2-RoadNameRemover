using Colossal.Localization;
using Game.SceneFlow;

namespace RoadNameRemover
{
	public class Localization
	{
		public static bool Prefix(string entryID, ref string value, ref bool __result, LocalizationDictionary __instance)
		{
			var cfg = RoadNameRemoverController._config;
			if (entryID.StartsWith("Assets.STREET_NAME:") && cfg.HideStreetNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			if (entryID.StartsWith("Assets.HIGHWAY_NAME:") && cfg.HideHighwayNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			if (entryID.StartsWith("Assets.ALLEY_NAME:") && cfg.HideAlleyNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			if (entryID.StartsWith("Assets.BRIDGE_NAME:") && cfg.HideBridgeNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			if (entryID.StartsWith("Assets.DAM_NAME:") && cfg.HideDamNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			return true;
		}

		internal static void ReloadLocaleBySwitching()
		{
			var localeId = GameManager.instance.localizationManager.activeLocaleId;
			// Switch to another locale and back to reload the active locale
			var altLocaleId = localeId == "en-US" ? "de-DE" : "en-US";
			GameManager.instance.localizationManager.SetActiveLocale(altLocaleId);
			Mod.log.Info("Loaded locale: " + altLocaleId);
			GameManager.instance.localizationManager.ReloadActiveLocale();
			//GameManager.instance.localizationManager.SetActiveLocale(localeId);
			//GameManager.instance.localizationManager.ReloadActiveLocale();
			Mod.log.Info("Reloaded active locale: " + localeId);
		}
	}
}