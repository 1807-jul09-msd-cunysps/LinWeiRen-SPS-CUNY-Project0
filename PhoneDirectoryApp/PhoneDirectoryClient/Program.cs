using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace PhoneDirectoryClient
{
    class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            UserInterface.Menu();
            NLog.LogManager.Shutdown();
        }
    }
}
