using Game.Settings;
using Gooee;

namespace HighwayNameRemover;

public class HighwayNameRemoverSettings : GooeeSettings
{
    [SettingsUISection("Toggles")]
    public bool HideHighwayNames
    {
        get;
        set;
    } = true;

    [SettingsUISection("Toggles")]
    public bool HideRoadNames
    {
        get;
        set;
    } = true;

    public override void SetDefaults( )
    {
        HideHighwayNames = true;
        HideRoadNames = false;
    }

    protected override string UIResource => "HighwayNameRemover.Resources.settings.xml";

}