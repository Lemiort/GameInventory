﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class HornsAndHooves:AbstractTrash
    {
        public HornsAndHooves()
        {
            this.m_price = 1;
            this.m_isQuestItem = false;
            this.m_stackable = false;
            this.m_count = 1;
        }
    }
}
