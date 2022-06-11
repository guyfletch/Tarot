using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;

namespace TarotDesktop
{
    public class TarotBootstrapper : BootstrapperBase
    {
        public TarotBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var settings = new Dictionary<string, object>
            {
                { "SizeToContent", SizeToContent.Manual },
                { "Height" , 600  },
                { "Width"  , 1024 },
            };
            DisplayRootViewFor<ShellViewModel>(settings);
        }
    }
}
