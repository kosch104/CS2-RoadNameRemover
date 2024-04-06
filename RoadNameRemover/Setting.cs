using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;


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
            Mod.log.Info("Setting initialized");
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
            Mod.log.Info("Applying Settings");
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
        private readonly Setting _setting;
        public LocaleEN(Setting setting)
        {
            _setting = setting;
        }
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { _setting.GetSettingsLocaleID(), "Road Name Remover" },
                { _setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Buttons" },
                { _setting.GetOptionGroupLocaleID(Setting.kSliderGroup), "Change the settings for the Road Name Remover mod. Please change the language after changing any option to reload the changes." },

                { _setting.GetOptionLabelLocaleID(nameof(Setting.HideStreetNames)), "Hide Street Names" },
                { _setting.GetOptionDescLocaleID(nameof(Setting.HideStreetNames)), "Hide the names of streets" },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.HideHighwayNames)), "Hide Highway Names" },
                { _setting.GetOptionDescLocaleID(nameof(Setting.HideHighwayNames)), "Hide the names of highways" },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.HideAlleyNames)), "Hide Alley Names" },
                { _setting.GetOptionDescLocaleID(nameof(Setting.HideAlleyNames)), "Hide the names of alleys" },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.HideBridgeNames)), "Hide Bridge Names" },
                { _setting.GetOptionDescLocaleID(nameof(Setting.HideBridgeNames)), "Hide the names of bridges" },
                { _setting.GetOptionLabelLocaleID(nameof(Setting.HideDamNames)), "Hide Dam Names" },
                { _setting.GetOptionDescLocaleID(nameof(Setting.HideDamNames)), "Hide the names of dams" },

            };
        }

        public void Unload()
        {
            
        }
    }
}
