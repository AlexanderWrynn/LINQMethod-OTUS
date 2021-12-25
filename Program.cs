using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQMethod_OTUS
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var intList = inputList.Top(33);
            foreach (var elem in intList)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine();

            var inputPersonList = new List<Person>();
            inputPersonList.Add(new Person { Name = "Торин", Age = 112 });
            inputPersonList.Add(new Person { Name = "Балин", Age = 162 });
            inputPersonList.Add(new Person { Name = "Глоин", Age = 101 });
            inputPersonList.Add(new Person { Name = "Двалин", Age = 110 });
            inputPersonList.Add(new Person { Name = "Бофур", Age = 57 });
            inputPersonList.Add(new Person { Name = "Кили", Age = 47 });
            inputPersonList.Add(new Person { Name = "Фили", Age = 45 });
            inputPersonList.Add(new Person { Name = "Бильбо", Age = 32 });

            var personList = inputPersonList.Top(30, person => person.Age);

            foreach (var elem in personList)
            {
                Console.WriteLine(elem);
            }
            Console.ReadLine();
        }
    }

    public static class LINQExtension
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int requiredProcent)
        {
            if (requiredProcent > 0 && requiredProcent <= 100)
            {
                decimal count = Math.Ceiling((decimal)requiredProcent / 100 * collection.Count());
                var temp = collection.OrderByDescending(item => item).Take((int)count);
                return temp;
            }

            else
            {
                throw new ArgumentException();
            }

        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int requiredProcent, Func<T, int> function)
        {
            if (requiredProcent > 0 && requiredProcent <= 100)
            {
                decimal count = Math.Ceiling((decimal)requiredProcent / 100 * collection.Count());
                var temp = collection.OrderByDescending(function).Take((int)count);
                return temp;
            }

            else
            {
                throw new ArgumentException();
            }

        }
    }
}
