using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Builder
{
    public class ItemBuilder
    {
        private Item _item;
        public ItemBuilder()
        {
            _item = new Item();
        }

        public void SetValue1(string ItemValue)
        {
            _item.Value1= ItemValue;
        }
        public void SetValue2(string ItemValue)
        {
            _item.Value2 = ItemValue;
        }
        public void SetValue3(string ItemValue)
        {
            _item.Value3 = ItemValue;
        }
        public void SetValue4(string ItemValue)
        {
            _item.Value4 = ItemValue;
        }

        public void SetValue5(string ItemValue)
        {
            _item.Value5 = ItemValue;
        }

        public Item GetItem()
        {
            return _item;
        }
    }
}
