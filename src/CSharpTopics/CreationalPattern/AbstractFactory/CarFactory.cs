using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.AbstractFactory
{
    public abstract class CarFactory
    {
        public EngineFactory EngineFactory { get; protected set; }
        public HeadLIghtFactory HeadLIghtFactory { get; protected set; }
    }
}
