using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Factory
{
    public class CarFactory
    {
        public Car CreateCar(string type,string model,string color,double speed)
        {
            Type? type1 = Type.GetType(type);
            bool c = type1.BaseType == typeof(Car);
            bool d = typeof(Car).IsAssignableFrom(type1); // Best Practise
            bool e = type1.IsSubclassOf(typeof(Car));
            if (d)
            {
                Car car1 = (Car)Activator.CreateInstance(type1);
                ConstructorInfo? constructorInfo = type1.GetConstructor(Type.EmptyTypes);
                object? obj = constructorInfo?.Invoke(null);
                Car car = (Car)obj;
                car.Color = color;
                car.Speed = speed;
                car.Model = model;
                return car;
            }
            return null;
        }
    }
}
