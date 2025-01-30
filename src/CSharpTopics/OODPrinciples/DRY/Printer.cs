using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.DRY
{
    public class Printer
    {
        public void Print()
        {
            // Duplication of same code 

            Console.WriteLine("hello i am mahmud");
            Console.WriteLine("hello i am ashik");
            Console.WriteLine("hello i am irfan");
            Console.WriteLine("hello i am babu");

            // Reduced Duplicacy by adding a new function Display and encapsulating similar code inside the function 
            Display("irfan");
            Display("mahmud");
            Display("ashik");
            Display("babu");
        }
        private void Display(string text)
        {
            Console.WriteLine($"hello i am {text}");
        }                    
    }                         
}                              
