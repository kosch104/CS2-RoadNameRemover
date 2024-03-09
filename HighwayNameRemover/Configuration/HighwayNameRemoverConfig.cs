namespace HighwayNameRemover.Configuration
{
    public class HighwayNameRemoverConfig : ConfigBase
    {
        protected override string ConfigFileName => "config.json";


        public bool HideHighwayNames
        {
            get;
            set;
        } = false;

        public bool HideRoadNames
        {
            get;
            set;
        } = false;
    }
}