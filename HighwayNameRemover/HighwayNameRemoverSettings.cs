using Game.Settings;
using Gooee;

namespace HighwayNameRemover;

public class HighwayNameRemoverSettings : GooeeSettings
{
    [SettingsUISection("Toggles")]
    public bool ShowHighwayNames
    {
        get;
        set;
    } = true;

    [SettingsUISection("Toggles")]
    public bool ShowRoadNames
    {
        get;
        set;
    } = true;

    public override void SetDefaults( )
    {
        ShowHighwayNames = true;
        ShowRoadNames = true;
    }

    protected override string UIResource => "HighwayNameRemover.Resources.settings.xml";

}