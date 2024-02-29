using Gooee.Plugins;

namespace HighwayNameRemover;

public class HighwayNameRemoverModel : Model
{
    public bool ShowHighwayNames
    {
        get;
        set;
    } = true;

    public bool ShowRoadNames
    {
        get;
        set;
    } = true;
}