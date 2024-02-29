using Gooee;
using Gooee.Plugins;
using Gooee.Plugins.Attributes;

namespace HighwayNameRemover;

[ControllerTypes( typeof( HighwayNameRemoverController ) )]
[GooeeSettingsMenu(typeof(HighwayNameRemoverSettings))]
public class HighwayNameRemoverPlugin : IGooeePluginWithControllers, IGooeeSettings, IGooeeLanguages
{
    public string Name => "HighwayNameRemover";
    public string ScriptResource => "HighwayNameRemover.Resources.ui.js";
    public string LanguageResourceFolder => "HighwayNameRemover.Resources.lang";

    public GooeeSettings Settings
    {
        get;
        set;
    }

    public IController[] Controllers { get; set; }
}