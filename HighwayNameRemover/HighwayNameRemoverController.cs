using Colossal.Serialization.Entities;
using Game;
using Gooee.Plugins;
using HighwayNameRemover.Configuration;

namespace HighwayNameRemover;

public class HighwayNameRemoverController : Controller<HighwayNameRemoverModel>
{
    private HighwayNameRemoverSettings _modSettings;
    public static readonly HighwayNameRemoverConfig _config = ConfigBase.Load<HighwayNameRemoverConfig>( );
    public static HighwayNameRemoverModel _model;

    public override HighwayNameRemoverModel Configure()
    {
        _model = new HighwayNameRemoverModel( );
        _model.HideHighwayNames = _config.HideHighwayNames;
        _model.HideRoadNames = _config.HideRoadNames;
        return _model;
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
        if ( _modSettings == null )
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

    protected override void OnModelUpdated()
    {
        if (Model.HideHighwayNames != _config.HideHighwayNames)
        {
            _config.HideHighwayNames = Model.HideHighwayNames;
            _config.Save( );
        }

        if (Model.HideRoadNames != _config.HideRoadNames)
        {
            _config.HideRoadNames = Model.HideRoadNames;
            _config.Save( );
        }
    }

    protected override void OnSettingsUpdated( )
    {
        UpdateFromSettings( );
    }
}