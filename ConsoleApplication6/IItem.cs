using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public interface IItem
    {
        /// <summary>
        /// цена предмета
        /// </summary>
        uint Price
        {
            get;
        }

        /// <summary>
        /// является ли предмет квестовым
        /// </summary>
        bool IsQuestItem
        {
            get;
        }

       uint Count { get; set; }


        /// <summary>
        /// использовать предмет
        /// </summary>
        /// <param name="user">кто использует предмет</param>
        void Use(Character user);
    }
}
