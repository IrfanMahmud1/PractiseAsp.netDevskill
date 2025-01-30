using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.EncapsulateWhatChanges
{
    public class Application
    {
        // This class is holding different responsibilities. We must encapsulate them in seperate module or classes
        public void Run()
        {
            var data = "Data fetched from database";
            Console.WriteLine(data);
        }
    }
}
