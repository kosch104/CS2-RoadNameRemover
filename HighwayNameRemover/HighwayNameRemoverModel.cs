using Gooee.Plugins;

namespace HighwayNameRemover;

public class HighwayNameRemoverModel : Model
{
    public bool HideHighwayNames
    {
        get;
        set;
    } = true;

    public bool HideRoadNames
    {
        get;
        set;
    } = true;
}