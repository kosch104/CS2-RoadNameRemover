namespace HighwayNameRemover.Configuration
{
    public class HighwayNameRemoverConfig : ConfigBase
    {
        protected override string ConfigFileName => "config.json";


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
}
