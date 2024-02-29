using Colossal.Serialization.Entities;
using Game;
using Gooee.Plugins;
using HighwayNameRemover.Configuration;

namespace HighwayNameRemover;

public class HighwayNameRemoverController : Controller<HighwayNameRemoverModel>
{
    private HighwayNameRemoverSettings _modSettings;
    public static readonly HighwayNameRemoverConfig _config = ConfigBase.Load<HighwayNameRemoverConfig>( );

    public override HighwayNameRemoverModel Configure()
    {
        var model = new HighwayNameRemoverModel( );
        model.ShowHighwayNames = _config.ShowHighwayNames;
        model.ShowRoadNames = _config.ShowRoadNames;
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

        if ( _modSettings.ShowHighwayNames != Model.ShowHighwayNames )
        {
            Model.ShowHighwayNames = _modSettings.ShowHighwayNames;
            TriggerUpdate( );
        }

        if ( _modSettings.ShowRoadNames != Model.ShowRoadNames )
        {
            Model.ShowRoadNames = _modSettings.ShowRoadNames;
            TriggerUpdate( );
        }

    }
}