using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.DRY
{
    public class Greeting
    {
        // unnecessary to create seperate methods for a general purpose
        public void GreeMorning()
        {
            Console.WriteLine("Good Evening!");
        }
        public void GreeEvening()
        {
            Console.WriteLine("Good Morning!");
        }

        // To avoid creating seperate methods generalized the functinality with a single method
        public void Greet(string message)
        {
            Console.WriteLine(message);
        }
    }
}
