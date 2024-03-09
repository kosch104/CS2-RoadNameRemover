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
        _model.HideStreetNames = _config.HideStreetNames;
        _model.HideAlleyNames = _config.HideAlleyNames;
        _model.HideBridgeNames = _config.HideBridgeNames;
        _model.HideDamNames = _config.HideDamNames;
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

        if ( _modSettings.HideStreetNames != Model.HideStreetNames )
        {
            Model.HideStreetNames = _modSettings.HideStreetNames;
            TriggerUpdate( );
        }

        if ( _modSettings.HideAlleyNames != Model.HideAlleyNames )
        {
            Model.HideAlleyNames = _modSettings.HideAlleyNames;
            TriggerUpdate( );
        }

        if ( _modSettings.HideBridgeNames != Model.HideBridgeNames )
        {
            Model.HideBridgeNames = _modSettings.HideBridgeNames;
            TriggerUpdate( );
        }

        if ( _modSettings.HideDamNames != Model.HideDamNames )
        {
            Model.HideDamNames = _modSettings.HideDamNames;
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

        if (Model.HideStreetNames != _config.HideStreetNames)
        {
            _config.HideStreetNames = Model.HideStreetNames;
            _config.Save( );
        }

        if (Model.HideAlleyNames != _config.HideAlleyNames)
        {
            _config.HideAlleyNames = Model.HideAlleyNames;
            _config.Save( );
        }

        if (Model.HideBridgeNames != _config.HideBridgeNames)
        {
            _config.HideBridgeNames = Model.HideBridgeNames;
            _config.Save( );
        }

        if (Model.HideDamNames != _config.HideDamNames)
        {
            _config.HideDamNames = Model.HideDamNames;
            _config.Save( );
        }
    }

    protected override void OnSettingsUpdated( )
    {
        UpdateFromSettings( );
    }
}