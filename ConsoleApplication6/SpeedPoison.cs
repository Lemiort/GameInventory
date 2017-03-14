using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class SpeedPoison : AbstractConsumableItem
    {

        public SpeedPoison()
        {
            Count = 1;
            this.m_isQuestItem = false;
            this.m_stackable = true;
            this.m_price = 100;
        }
    }
}
