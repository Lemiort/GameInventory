using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class GreatHealthPoison:HealthPoison
    {
        public GreatHealthPoison():base()
        {
            Count = 1;
            this.m_isQuestItem = true;
            this.m_stackable = false;
            this.m_price = 1000;
        }

    }
}
