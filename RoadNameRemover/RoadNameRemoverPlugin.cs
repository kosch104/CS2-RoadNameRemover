using Gooee;
using Gooee.Plugins;
using Gooee.Plugins.Attributes;

namespace RoadNameRemover;

[ControllerTypes( typeof( RoadNameRemoverController ) )]
[GooeeSettingsMenu(typeof(RoadNameRemoverSettings))]
public class RoadNameRemoverPlugin : IGooeePluginWithControllers, IGooeeSettings, IGooeeLanguages
{
    public string Name => "RoadNameRemover";
    public string ScriptResource => "RoadNameRemover.Resources.ui.js";
    public string LanguageResourceFolder => "RoadNameRemover.Resources.lang";

    public GooeeSettings Settings
    {
        get;
        set;
    }

    public IController[] Controllers { get; set; }
}