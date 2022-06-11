using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using TarotFunctions;

namespace TarotDesktop
{
    public class ShellViewModel : PropertyChangedBase
    {
        public List<string> SpreadNames => new List<string> { "Rectangular", "Cross", "Three", "Single" };

        public List<SpreadViewModel> SpreadList = new() {
            new RectangleSpreadViewModel(new Deck()),
            new CrossSpreadViewModel(new Deck()),
            new ThreeSpreadViewModel(new Deck()),
            new SingleSpreadViewModel(new Deck())
        };
        private SpreadViewModel activeSpread;

        public ShellViewModel()
        {
            activeSpread = SpreadList.First();
        }

        public SpreadViewModel ActiveSpread { 
            get
            {
                return activeSpread;
            }
            set 
            {
                activeSpread = value;
                NotifyOfPropertyChange(() => ActiveSpread);
            } 
        }
        private string spreadName = string.Empty;
        public string CurrentSpreadName
        {
            get
            {
                return spreadName;
            }
            set
            {
                spreadName = value;
                NotifyOfPropertyChange(() => CurrentSpreadName);
                ActiveSpread = MatchSpread(spreadName);
            }
        }

        private SpreadViewModel MatchSpread(string selectedSpread)
        {
            var spread = SpreadList.FirstOrDefault(x => x.SpreadName == selectedSpread);
            if (spread == null) return SpreadList.First();
            return spread;
        }
    }
}
