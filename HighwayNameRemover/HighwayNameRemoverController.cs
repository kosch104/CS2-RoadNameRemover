using Colossal.Serialization.Entities;
using Game;
using Gooee.Plugins;

namespace HighwayNameRemover;

public class HighwayNameRemoverController : Controller<HighwayNameRemoverModel>
{
    public static HighwayNameRemoverSettings _modSettings;

    public override HighwayNameRemoverModel Configure()
    {
        var model = new HighwayNameRemoverModel( );
        return new HighwayNameRemoverModel();
    }

    protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
    {
        base.OnGameLoadingComplete(purpose, mode);

        if (mode == GameMode.Game)
        {
            var plugin = Plugin as HighwayNameRemoverPlugin;

            if (plugin.Settings is HighwayNameRemoverSettings settings)
                _modSettings = settings;

            UpdateFromSettings();
        }
    }

    private void UpdateFromSettings( )
    {
        if ( Settings == null )
            return;

        if ( _modSettings.HideHighwayNames != Model.HideHighwayNames )
        {
            Model.HideHighwayNames = _modSettings.HideHighwayNames;
            TriggerUpdate( );
        }

        if ( _modSettings.HideRoadNames != Model.HideRoadNames )
        {
            Model.HideRoadNames = _modSettings.HideRoadNames;
            TriggerUpdate( );
        }

    }
}