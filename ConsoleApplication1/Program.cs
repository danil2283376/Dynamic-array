using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // int лист
            Generic<int> generic = new Generic<int>()
            generic.Add(228);
            generic.Add(337);
            generic.Add(1337);
            generic.Add(100);
            generic.Remove(228);
            generic.Output();

            Console.WriteLine();
            // string лист
            Generic<string> str = new Generic<string>();
            str.Add("Max");
            str.Add("Goxa");
            str.Add("List");
            str.Add("array");
            str.Remove("Max");
            str.Output();
            // размер списка
            Console.WriteLine("Размер списка " +  str.Count());
            Console.ReadLine();
        }
    }
    // класс для неопределенных значений
    public class Generic<T>
    {
        // Массив с не определенным типом
        T[] array;

        // Конструктор
        public Generic()
        {
            array = new T[0];
        }

        // Добавить элемент в массив
        public void Add(T item)
        {
            T[] oldArray = array; // старый массив
            T[] newArray = new T[array.Length + 1]; // новый массив

            for (int i = 0; i < newArray.Length; i++) // перезапись старого массива
            {
                if (oldArray.Length == i)
                {
                    newArray[i] = item;
                }
                else
                {
                    newArray[i] = oldArray[i];
                }
            }

            array = newArray;
        }

        // Удалить элемент из Листа
        public void Remove(T item)
        {
            // Перезаписываю старый массив в новый
            T[] newArray = new T[array.Length - 1];
            int index = -1;
            for (int i = 0; i < array.Length; i++) //прохожусь по массиву
            {
                if (array[i].Equals(item)) 
                {
                    index = i;
                    break;
                }
            }

            if (index > -1) 
            {
                for (int i = 0, j = 0; i < array.Length; i++)
                {
                    if (i == index) continue; 
                    newArray[j] = array[i];
                    j++;
                }
                array = newArray; // присваиваю новый массив старому
            }
            // присваиваю новый массив старому
        }

        // Размер списка
        public int Count() 
        {
            return array.Length;
        }

        // Вывести лист
        public void Output()
        {
            foreach (T elem in array)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
