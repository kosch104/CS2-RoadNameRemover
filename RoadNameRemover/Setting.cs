using System;
using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;


namespace RoadNameRemover
{
    [FileLocation(nameof(RoadNameRemover))]
    [SettingsUIGroupOrder(kSliderGroup, kDropdownGroup)]
    [SettingsUIShowGroupName(kSliderGroup, kDropdownGroup)]
    public class Setting : ModSetting
    {
        private readonly Mod _mod;
        public const string kSection = "Main";
        public const string kSection2 = "Time";
        public const string kButtonGroup = "Button";
        public const string kDropdownGroup = "Dropdown";
        public const string kSliderGroup = "Slider";
        public static Setting instance;

        public Setting(IMod mod) : base(mod)
        {
            _mod = (Mod)mod;
            //Mod.log.Info("Setting initialized");
        }

        //Page1 - General Settings

        [SettingsUISection(kSection, kSliderGroup)]
        public bool HideStreetNames { get; set; }
        [SettingsUISection(kSection, kSliderGroup)]
        public bool HideHighwayNames { get; set; }
        [SettingsUISection(kSection, kSliderGroup)]
        public bool HideAlleyNames { get; set; }
        [SettingsUISection(kSection, kSliderGroup)]
        public bool HideBridgeNames { get; set; }
        [SettingsUISection(kSection, kSliderGroup)]
        public bool HideDamNames { get; set; }

        public override void Apply()
        {
            //Mod.log.Info("Applying Settings");
        }

        public override void SetDefaults()
        {
            HideStreetNames = false;
            HideHighwayNames = true;
            HideAlleyNames = false;
            HideBridgeNames = false;
            HideDamNames = false;
            Mod.log.Info("Settings set to default");
        }
    }

    public class LocaleEN : IDictionarySource
    {
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            var setting = Setting.instance;

            Dictionary<string, string> dict;
            try
            {
                dict = new Dictionary<string, string>
                {
                    { setting.GetSettingsLocaleID(), "Road Name Remover" },
                    { setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Buttons" },
                    {
                        setting.GetOptionGroupLocaleID(Setting.kSliderGroup),
                        "Change the settings for the Road Name Remover mod. Please change the language after changing any option to reload the changes."
                    },

                    { setting.GetOptionLabelLocaleID(nameof(Setting.HideStreetNames)), "Hide Street Names" },
                    { setting.GetOptionDescLocaleID(nameof(Setting.HideStreetNames)), "Hide the names of streets" },
                    { setting.GetOptionLabelLocaleID(nameof(Setting.HideHighwayNames)), "Hide Highway Names" },
                    { setting.GetOptionDescLocaleID(nameof(Setting.HideHighwayNames)), "Hide the names of highways" },
                    { setting.GetOptionLabelLocaleID(nameof(Setting.HideAlleyNames)), "Hide Alley Names" },
                    { setting.GetOptionDescLocaleID(nameof(Setting.HideAlleyNames)), "Hide the names of alleys" },
                    { setting.GetOptionLabelLocaleID(nameof(Setting.HideBridgeNames)), "Hide Bridge Names" },
                    { setting.GetOptionDescLocaleID(nameof(Setting.HideBridgeNames)), "Hide the names of bridges" },
                    { setting.GetOptionLabelLocaleID(nameof(Setting.HideDamNames)), "Hide Dam Names" },
                    { setting.GetOptionDescLocaleID(nameof(Setting.HideDamNames)), "Hide the names of dams" },
                };
            }
            catch (Exception x)
            {
                Mod.log.Warn("Using Fallback Localization");
                dict = new Dictionary<string, string>();
            }
            return dict;
        }

        public void Unload()
        {
            
        }
    }
}
