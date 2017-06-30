using System.Collections.Generic;

namespace FlightInfoModule
{
    public static class PanelAnimations
    {
        private static readonly List<string> _panelAnimations;

        static PanelAnimations()
        {
            _panelAnimations = new List<string>();
            _panelAnimations.Add("EnterTopExitTop-Quad");
            _panelAnimations.Add("EnterTopExitBottom-Quad");
            _panelAnimations.Add("EnterTopExitTop-BackEaseInOut");
            _panelAnimations.Add("EnterTopExitBottom-BackEaseInOut");
            _panelAnimations.Add("None");
        }

        public static List<string> GetPanelAnimations
        {
            get { return _panelAnimations; }
        }
    }
}