using Colossal.Localization;

namespace RoadNameRemover
{
	public class Localization
	{
		public static bool Prefix(string entryID, ref string value, ref bool __result, LocalizationDictionary __instance)
		{
			var cfg = Setting.instance;
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
			if (entryID.StartsWith("Assets.DISTRICT_NAME:") && cfg.HideDistrictNames)
			{
				value = "          ";
				__result = true;
				return false;
			}
			return true;
		}

		internal static void ReloadLocaleBySwitching()
		{
			// Currently unused
		}
	}
}