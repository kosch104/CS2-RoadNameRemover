using HarmonyLib;
using System.Reflection;
using Colossal.IO.AssetDatabase;
using Colossal.Localization;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;


namespace RoadNameRemover
{
    public class Mod : IMod
    {
        internal static readonly ILog log = LogManager.GetLogger($"{nameof(RoadNameRemover)}").SetShowsErrorsInUI(false);

        private Harmony harmony;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            harmony = new($"{nameof(RoadNameRemover)}.{nameof(Mod)}");


            var mSetting = new Setting(this);
            mSetting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN());
            AssetDatabase.global.LoadSettings(nameof(RoadNameRemover), mSetting, new Setting(this));
            mSetting.Apply();
            Setting.instance = mSetting;


            var originalMethod = typeof(LocalizationDictionary).GetMethod("TryGetValue", BindingFlags.Public | BindingFlags.Instance);
            var prefix = typeof(Localization).GetMethod("Prefix", BindingFlags.Public | BindingFlags.Static);
            harmony.Patch(originalMethod, new HarmonyMethod(prefix));
            log.Info("RoadNameRemover patched LocalizationDictionary.TryGetValue");

            GameManager.instance.localizationManager.ReloadActiveLocale();
        }

        public void OnDispose()
        {

        }
    }
}