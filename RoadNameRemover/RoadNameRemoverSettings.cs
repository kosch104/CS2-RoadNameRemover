using Game.Settings;
using Gooee;

namespace RoadNameRemover;

public class RoadNameRemoverSettings : GooeeSettings
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

    protected override string UIResource => "RoadNameRemover.Resources.settings.xml";

}