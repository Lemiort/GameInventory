using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class SimpleInventory : AbstractInventory
    {
        public SimpleInventory()
        {
            Size = 16u;
            items = new IItem[Size];
        }

        public void PrintInventory()
        {
            for(int i=0; i < Size; i++)
            {
                if (items[i] != null)
                {
                    string s = "";
                    if (items[i] is ITrashItem)
                        s = "Trash";
                    else if (items[i] is IConsumableItem)
                        s = "Consumable";
                    else if (items[i] is IEquipment)
                        s = "Equipment";

                    Console.WriteLine("[{6}] {0}, Count = {1}, Quest = {2}, Stackable = {3},Price = {4}, {5}",
                        items[i].GetType().ToString(),
                        items[i].Count,
                        items[i].IsQuestItem,
                        items[i] is IStackable,
                        items[i].Price,
                        s, i);
                }
                else
                {
                    Console.WriteLine("[{0}]", i);
                }
            }
        }

    }
}
