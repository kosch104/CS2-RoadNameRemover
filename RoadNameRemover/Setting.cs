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
    [SettingsUIGroupOrder(kToggleGroup, kToggleGroup)]
    [SettingsUIShowGroupName(kToggleGroup)]
    public class Setting : ModSetting
    {
        private readonly Mod _mod;
        public const string kSection = "Main";

        public const string kToggleGroup = "Toggle";
        public static Setting instance;

        public Setting(IMod mod) : base(mod)
        {
            _mod = (Mod)mod;
            SetDefaults();
            //Mod.log.Info("Setting initialized");
        }

        //Page1 - General Settings
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideStreetNames { get; set; }
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideHighwayNames { get; set; }
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideAlleyNames { get; set; }
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideBridgeNames { get; set; }
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideDamNames { get; set; }
        [SettingsUISection(kSection, kToggleGroup)]
        public bool HideDistrictNames { get; set; }

        public override void SetDefaults()
        {
            HideStreetNames = false;
            HideHighwayNames = true;
            HideAlleyNames = false;
            HideBridgeNames = false;
            HideDamNames = false;
            HideDistrictNames = false;
            //Mod.log.Info("Settings set to default");
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Road Name Remover" },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup),
                    "Change the settings for the Road Name Remover mod. Please change the language after changing any option to reload the changes."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideStreetNames)), "Hide Street Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideStreetNames)), "Hide the names of streets" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideHighwayNames)), "Hide Highway Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideHighwayNames)), "Hide the names of highways" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideAlleyNames)), "Hide Alley Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideAlleyNames)), "Hide the names of alleys" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideBridgeNames)), "Hide Bridge Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideBridgeNames)), "Hide the names of bridges" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideDamNames)), "Hide Dam Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideDamNames)), "Hide the names of dams" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideDistrictNames)), "Hide District Names" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.HideDistrictNames)), "Hide the names of districts" },
            };
        }

        public void Unload()
        {
            
        }
    }
}
