using System.Collections.Generic;
using HarmonyLib;
using Colossal.Localization;
using Colossal.IO.AssetDatabase;
using HighwayNameRemover.Localization;
using UnityEngine;

namespace HighwayNameRemover.Patches
{
    [HarmonyPatch(typeof(LocalizationManager), "AddLocale", typeof(LocaleAsset))]
    internal class LocalizationManager_AddLocale
    {
        static void Prefix(LocaleAsset asset)
        {
            Debug.Log("Prefixing AddLocale");
            Localization.Localization.AddCustomLocal(asset);
        }
    }
}
