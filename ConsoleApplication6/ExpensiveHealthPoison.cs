using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class ExpensiveHealthPoison:HealthPoison
    {
        public ExpensiveHealthPoison():base()
        {
            Count = 1;
            this.m_isQuestItem = false;
            this.m_stackable = false;
            this.m_price = 500;
        }


    }
}
