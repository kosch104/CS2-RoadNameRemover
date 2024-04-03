namespace RoadNameRemover.Configuration
{
    public class RoadNameRemoverConfig : ConfigBase
    {
        protected override string ConfigFileName => "config.json";


        public bool HideHighwayNames
        {
            get;
            set;
        } = false;

        public bool HideStreetNames
        {
            get;
            set;
        } = false;


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
}