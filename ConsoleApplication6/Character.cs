using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Character
    {
        List<IEquipment> equipment = new List<IEquipment>();

        public void AddEquipment(IEquipment equip)
        {
            equipment.Add(equip);
            Console.WriteLine("{0} equiped", equip.GetType());
        }
    }
}
