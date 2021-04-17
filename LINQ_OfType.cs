using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            IList mixedList = new ArrayList();

            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { Name = "John", Age = 23 });

            var intResult = mixedList.OfType<int>(); // 0,3

            var stringResult = mixedList.OfType<string>();  // "One", "Two"

            stringResult = from s in mixedList.OfType<string>() select s;
            intResult = from s in mixedList.OfType<int>() select s;
            foreach (var element in stringResult)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
        }
    }

    internal class Student
    {
        public Student()
        {
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
