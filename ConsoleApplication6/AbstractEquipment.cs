using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public abstract class AbstractEquipment : AbstractItem, IEquipment
    {

        public override void Use(Character user)
        {
            base.Use(user);
            Console.WriteLine(this.ToString() + " equipped");
        }
    }
}
