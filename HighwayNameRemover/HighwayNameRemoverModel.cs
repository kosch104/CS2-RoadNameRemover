using Gooee.Plugins;

namespace HighwayNameRemover;

public class HighwayNameRemoverModel : Model
{
    public bool HideHighwayNames
    {
        get;
        set;
    } = true;

    public bool HideStreetNames
    {
        get;
        set;
    } = true;

    public bool HideAlleyNames
    {
        get;
        set;
    } = true;

    public bool HideBridgeNames
    {
        get;
        set;
    } = true;

    public bool HideDamNames
    {
        get;
        set;
    } = true;
}