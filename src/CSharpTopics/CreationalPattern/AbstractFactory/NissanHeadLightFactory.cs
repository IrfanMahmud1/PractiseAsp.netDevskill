using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public class NissanHeadLightFactory : HeadLIghtFactory
    {
        public override HeadLight CreateHeadLight()
        {
            return new NissanHeadLight();
        }
    }
}
