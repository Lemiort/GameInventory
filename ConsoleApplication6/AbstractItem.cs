using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public abstract class AbstractItem : IItem
    {
        protected uint m_count;
        protected uint m_price;
        protected bool m_isQuestItem;
        protected bool m_stackable;

        public uint Count
        {
            get
            {
                return m_count;
            }
            set
            {
                m_count = value;
            }
        }
        public bool IsQuestItem
        {
            get
            {
                return m_isQuestItem;
            }
        }
        public uint Price
        {
            get
            {
                return m_price;
            }
        }
        public bool Stackable
        {
            get
            {
                return m_stackable;
            }
        }

        public virtual void Use(Character user)
        {
            Console.WriteLine("\n"+ToString() + " used");
        }
    }
}
