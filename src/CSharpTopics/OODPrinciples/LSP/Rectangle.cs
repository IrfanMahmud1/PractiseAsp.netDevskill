using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODPrinciples.LSP
{
    public class Rectangle
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double CalculateArea(double height,double width)
        {
            return Height * Width;
        }
    }
}
