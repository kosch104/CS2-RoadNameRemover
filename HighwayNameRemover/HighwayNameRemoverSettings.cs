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
    public bool HideStreetNames
    {
        get;
        set;
    } = true;

    [SettingsUISection("Toggles")]
    public bool HideAlleyNames
    {
        get;
        set;
    } = true;

    [SettingsUISection("Toggles")]
    public bool HideBridgeNames
    {
        get;
        set;
    } = true;

    [SettingsUISection("Toggles")]
    public bool HideDamNames
    {
        get;
        set;
    } = true;

    public override void SetDefaults( )
    {
        HideHighwayNames = true;
        HideStreetNames = false;
        HideAlleyNames = false;
        HideBridgeNames = false;
        HideDamNames = false;
    }

    protected override string UIResource => "HighwayNameRemover.Resources.settings.xml";

}