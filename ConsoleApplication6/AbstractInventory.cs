using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public abstract class AbstractInventory : IInventory
    {
        protected IItem[] items;
        Random rand = new Random();

        public uint Size { get; protected set; }



        public bool Add(IItem item)
        {
            //запрет добавления одинаковых
            if (items.Contains(item))
                return false;

            //попытка стаковать предметы
            if (item is IStackable)
            {
                int i = GetFirstNotFull(item as IStackable);
                //нашли первую не заполненную и не пустую ячейку
                if( i>=0)
                {
                    //можно заполнить эту ячейку доверху или частично
                    if(items[i].Count + item.Count <= (item as IStackable).StackSize)
                    {
                        items[i].Count += item.Count;
                        return true;
                    }
                    //"перелив" за край
                    else
                    {
                        uint countToAdd = (item as IStackable).StackSize - items[i].Count;
                        items[i].Count = (item as IStackable).StackSize;
                        item.Count -= countToAdd;

                        return AddToEmptyCell(item);
                    }
                }
                //все ячейки полные или пустые 
                else
                {
                    return AddToEmptyCell(item);
                }
            }
            //предмет не стакается
            else
            {

                //квестовые нельзя стаковать
                if (item.IsQuestItem)
                {
                    //нашли такой же предмет
                    int i = ContainsThisType(item);
                    if (i >= 0)
                        return false;
                    //дубликатов нет
                    else
                    {
                        //просто добавляем в пустую ячейку
                        return AddToEmptyCell(item);
                    }
                }
                //просто дабавляем в пустую ячейку неквестовый предмет
                else
                {
                    return AddToEmptyCell(item);
                }
            }
        }

        /// <summary>
        /// пытается добавить в пустую ячейку инвентаря
        /// </summary>
        /// <param name="item">предмет</param>
        /// <returns>true, если удалось добавить, false если нет места</returns>
        private bool AddToEmptyCell(IItem item)
        {
            for(int i=0; i< items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// проверяет, содержатся ли предметы такого же типа в инвентаре
        /// </summary>
        /// <param name="item">предмет для поиска внутри инвентаря</param>
        /// <returns>индекс внутри инвентаря или -1, если ничего не найдено</returns>
        private int ContainsThisType(IItem item)
        {
            int ret = -1;
            for(int i=0; i< items.Length; i++)
            {
                if( items[i] != null)
                if (items[i].GetType() == item.GetType())
                    return i;
            }
            return ret;
        }

        /// <summary>
        /// получить первую незполненную ячейку
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected int GetFirstNotFull(IStackable item)
        {
            int ret = -1;
            for (int i = 0; i < items.Length; i++)
            {
                if(items[i] != null)
                //предмет найден
                if (items[i].GetType() == item.GetType())
                    //предмета не максимальное количество
                    if((items[i] as IStackable).StackSize > items[i].Count)
                        return i;
            }
            return ret;
        }

        public bool RemoveItem(uint number)
        {
            if (items[number]!=null)
            {
                items[number] = null;
                return true;
            }
            return false;
        }

        /// <summary>
        /// удаление всех элементов нужного типа
        /// </summary>
        /// <param name="t"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool RemoveItem(Type t, uint count)
        {
            uint typeCount = 0;

            //подсчёт элементов такого типа
            foreach(var item in items)
            {
                if(item != null)
                if( item.GetType() == t)
                {
                    typeCount += item.Count;
                }
            }
            //если элементов больше или достаточно, то удаление
            if(count <= typeCount)
            {
                foreach (var item in items)
                {
                    if(item != null)
                    if (item.GetType() == t)
                    {
                        if(item.Count >= count)
                        {
                            item.Count -= count;
                            break;
                        }
                        else
                        {
                            count -= item.Count;
                            item.Count = 0;
                        }
                    }
                }
                ClearEmptyItems();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItem(uint number, uint count)
        {
            //такой предмет существует
            if (items[number] != null)
            {
                //удаляется меньше чем есть в ячейке
                if (items[number].Count > count)
                {
                    items[number].Count -= count;
                    return true;
                }
                //ровно столько, солько есть
                else if (items[(int)number].Count == count)
                {
                    items[number] = null;
                    return true;
                }
                //запрос удаляения слишком большого числа
                else
                    return false;
            }
            return false;
        }

        public bool Replace(uint from, uint to)
        {
            IItem itemFrom = items[from];
            items[from] = items[to];
            items[to] = itemFrom;
            return true;
        }

        public void SortByPrice()
        {
            //throw new NotImplementedException();
            QuickSort(0, items.Length-1);
        }

        private void QuickSort(int l, int r)
        {
            IItem temp;
            int x;
            if (items[l + (r - l) / 2] == null)
                x = -1;
            else
                x = (int)items[l + (r - l) / 2].Price;
            //запись эквивалентна (l+r)/2,
            //но не вызввает переполнения на больших данных
            int i = l;
            int j = r;
            //код в while обычно выносят в процедуру particle
            while (i <= j)
            {
                //while ((int)items[i].Price > x) i++;
                while (true)
                {
                    int p = -1;
                    if (items[i] != null)
                        p = (int)items[i].Price;
                    if (p <= x)
                        break;
                    i++;
                }

                //while ((int)items[j].Price < x) j--;
                while (true)
                {
                    int p = -1;
                    if (items[j] != null)
                        p = (int)items[j].Price;
                    if (p >= x)
                        break;
                    j--;
                }

                if (i <= j)
                {
                    temp = items[i];
                    items[i]= items[j];
                    items[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(i, r);

            if (l < j)
                QuickSort(l, j);
        }

        public void SortByType()
        {
            List<IItem> items2 = new List<IItem>();


            
            foreach( var item in items)
            {
                if (item != null)
                    if (!item.IsQuestItem && item is IEquipment)
                    items2.Add(item);
            }
            foreach (var item in items)
            {
                if (item != null)
                    if (!item.IsQuestItem && item is IConsumableItem)
                    items2.Add(item);
            }

            foreach (var item in items)
            {
                if (item != null)
                    if (item.IsQuestItem)
                    items2.Add(item);
            }

            foreach (var item in items)
            {
                if (item != null)
                    if (!item.IsQuestItem && item is ITrashItem)
                    items2.Add(item);
            }
            for(int i=0; i< items.Length; i++)
            {
                items[i] = null;
                if (i < items2.Count)
                    items[i] = items2[i];
            }
        }

        public ItemContextMenu GetItemMenu(uint counter)
        {
            ItemContextMenu ret = new ItemContextMenu();
            ret.removeable = true;
            ret.sellable = true;
            ret.useablee = true;

            if (items[counter] != null)
            {
                if((items[(int)counter] is ITrashItem))
                {
                    ret.useablee = false;
                }
                if (!(items[(int)counter].IsQuestItem))
                {
                    ret.price = items[(int)counter].Price;
                }
                else
                {
                    ret.sellable = false;
                    ret.removeable = false;
                }
                return ret;
            }
            else
            {
                ret.removeable = false;
                ret.sellable = false;
                ret.useablee = false;
                return ret;
            }
        }

        /// <summary>
        /// очистка от элементов с числом равным 0
        /// </summary>
        private void ClearEmptyItems()
        {
            while(true)
            {
                int nonEmptyCount = 0;
                for(int i=0; i< items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        if (items[i].Count > 0)
                            nonEmptyCount++;
                        else
                        {
                            items[i] = null;
                            break;
                        }
                    }
                    else
                        nonEmptyCount++;
                }
                if (nonEmptyCount == items.Length)
                    return;
            }
        }

        public IItem GetItem(uint number)
        {
            if (items[number] != null)
            {
                IItem removedItem = items[(int)number];
                //items.Remove(removedItem);
                return removedItem;
            }
            else
                return null;
        }

        public void UseItem(uint number, Character character)
        {
            if (items[number] != null)
            {
                if ((items[(int)number] is ITrashItem))
                {
                    Console.WriteLine("Cant use this");
                }
                else
                {
                    items[(int)number].Use(character);
                    if (items[(int)number].Count == 0)
                        items[(int)number] = null;
                }
            }
            else
            {
                Console.WriteLine("Wrong num");
            }
        }
    }
}
