using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public abstract class AbstractTrash : AbstractItem, ITrashItem
    {

        public override void Use(Character user)
        {
            base.Use(user);
            //do nothing
        }
    }
}
