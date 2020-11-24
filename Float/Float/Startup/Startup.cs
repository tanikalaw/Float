using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.Startup
{
   public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Float.App app = new Float.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
