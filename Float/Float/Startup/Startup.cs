using Float.Component.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.Startup
{
    class Startup
    {
        [STAThread]
         static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();

           
        }
    }
}
