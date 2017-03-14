using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public struct ItemContextMenu
    {
        public bool useablee;
        public bool sellable;
        public bool removeable;
        public uint price;

        public override string ToString()
        {
            String output = "";
            if (useablee)
                output += "Use\n";
            if (sellable)
            {
                output += "Sell for "+
                    price.ToString()+"\n";
            }
            if(removeable)
                output += "Remove\n";
            return output;
        }
    }

    public interface IInventory
    {
        bool Add(IItem item);
        uint Size { get;}
        IItem GetItem(uint number);
        bool RemoveItem(uint number);
        bool RemoveItem(Type t, uint count);
        bool RemoveItem(uint number, uint count);
        bool Replace(uint from, uint to);
        void SortByPrice();
        void SortByType();
        void UseItem(uint number, Character character);
        ItemContextMenu GetItemMenu(uint counter);
    }
}
