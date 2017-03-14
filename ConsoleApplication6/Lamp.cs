using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class Lamp:AbstractEquipment
    {
        public Lamp()
        {
            m_count = 1;
            m_isQuestItem = true;
            m_price = 0;
        }

        public override void Use(Character user)
        {
            base.Use(user);
            Console.WriteLine("The light shines character way");
        }
    }
}
