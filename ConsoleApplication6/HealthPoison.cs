using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class HealthPoison : AbstractConsumableItem, IStackable
    {
        

        public HealthPoison()
        {
            Count = 5;
            this.m_isQuestItem = false;
            this.m_stackable = true;
            this.m_price = 50;
        }

        public uint StackSize
        {
            get
            {
                return 5;
            }
        }

    }
}
