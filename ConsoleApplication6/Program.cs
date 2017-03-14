using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1 - 21:14-21:37
//2 - 22:00-23:26
//3 - 15:01-18:38
//4 Hostfix 20:00-20:43

//предметы деляется на ... и квестовые - любой предмет может быть квестовым
//квестовый или можно использовать и тогда он либо расходник, либо эквип, 
//или этот предмет нельзя использоватьи  по сути это трешак

//как удалять предметы по типу?

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SimpleInventory simpleInventory = new SimpleInventory();
            //добавляем предмет
            HealthPoison poison1 = new HealthPoison();
            simpleInventory.Add(poison1);
            simpleInventory.PrintInventory();

            //добаляем тот же самый предмет
            Console.WriteLine("\n Дубль предмета");
            simpleInventory.Add(poison1);
            simpleInventory.PrintInventory();


            //используем предмет
            Console.WriteLine("\n использование предмета");
            poison1.Use(null);
            simpleInventory.PrintInventory();

            //добавляем другой предмет
            Console.WriteLine("\n Добавление второго предмета");
            HealthPoison poison2 = new HealthPoison();
            simpleInventory.Add(poison2);
            simpleInventory.PrintInventory();

            //добавляем другой предмет
            Console.WriteLine(" \n Добавдение ещё 2х предметов");
            HealthPoison poison3 = new HealthPoison();
            simpleInventory.Add(poison3);
            //и ещё один сразу же
            HealthPoison poison4 = new GreatHealthPoison();
            simpleInventory.Add(poison4);
            simpleInventory.PrintInventory();

            //добавляем другой предмет
            Console.WriteLine("\n Добавление кучи предметов");
            HealthPoison poison5 = new ExpensiveHealthPoison();
            simpleInventory.Add(poison5);

            SpeedPoison poison6 = new SpeedPoison();
            simpleInventory.Add(poison6);

            Sword sword1 = new Sword();
            simpleInventory.Add(sword1);

            HornsAndHooves trash1 = new HornsAndHooves();
            simpleInventory.Add(trash1);

            Key key1 = new Key();
            simpleInventory.Add(key1);

            Lamp lamp1 = new Lamp();
            simpleInventory.Add(lamp1);

            simpleInventory.PrintInventory();

            //переставляем предметы
            Console.WriteLine("\n Перестановка 1 и 3");
            simpleInventory.Replace(1, 3);
            simpleInventory.PrintInventory();

            //удалём несколько предметов
            Console.WriteLine("\nУдаляем 3 предмета из 2го слота");
            if( !simpleInventory.RemoveItem(2, 3))
                Console.WriteLine("Не вышло");
            simpleInventory.PrintInventory();

            //сортировка
            Console.WriteLine("\nСортировка");
            simpleInventory.SortByPrice();
            simpleInventory.PrintInventory();

            //сортировка по типа
            Console.WriteLine("\nСортировка по типу");
            simpleInventory.SortByType();
            simpleInventory.PrintInventory();

            //просматриваем контестное меню
            Console.WriteLine("\n Просмотр меню предметов");
            for (int i = 0; i < 16; i++)
            {
                string s = simpleInventory.GetItemMenu((uint)i).ToString();
                if(simpleInventory.GetItem((uint)i)  !=null)
                {
                    Console.WriteLine("[{0}]{1}:\n{2}\n",i, simpleInventory.GetItem((uint)i).GetType().ToString(), s);
                }
            }
            simpleInventory.PrintInventory();

            //используем все возможные предметы
            Console.WriteLine("\n Использование предметов");
            for (int i = 0; i < 16; i++)
            {
                string s = simpleInventory.GetItemMenu((uint)i).ToString();
                if (simpleInventory.GetItem((uint)i) != null)
                {
                    if (simpleInventory.GetItemMenu((uint)i).useablee)
                    {
                        Console.WriteLine("========");
                        simpleInventory.UseItem((uint)i, null);
                    }
                }
            }
            simpleInventory.PrintInventory();

            //удалём несколько предметов
            Console.WriteLine("\n Удаление 9 зелий лечения");
            simpleInventory.RemoveItem(poison2.GetType(), 9);
            simpleInventory.PrintInventory();

            //удалём несколько предметов
            Console.WriteLine("\n Удаление 5 зелий лечения");
            simpleInventory.RemoveItem(poison2.GetType(), 5);
            simpleInventory.PrintInventory();


            //удалём несколько предметов
            Console.WriteLine("\n Удаление 3 зелий лечения");
            simpleInventory.RemoveItem(poison2.GetType(), 3);
            simpleInventory.PrintInventory();



            //удаляем всё из ячейки
            Console.WriteLine("\n Удаление из ячейки 7");
            simpleInventory.RemoveItem(7);
            simpleInventory.PrintInventory();




            Console.ReadKey();
        }
    }
}
