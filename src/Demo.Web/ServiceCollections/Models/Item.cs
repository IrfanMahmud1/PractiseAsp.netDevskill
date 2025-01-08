using System;

namespace ServiceCollections.Models
{
    public class Item : IItem , ISpecialItem
    {
        public double GetAmount()
        {
            return 19;
        }

        public int GetPrice()
        {
            return 400;
        }
    }
}
