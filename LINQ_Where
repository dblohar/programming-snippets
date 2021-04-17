using System;
using System.Collections.Generic;
using System.Linq;
namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>(){
                  new Student(){Name="Omkar",Age=16},
                  new Student(){Name="Amar",Age=14},
                  new Student(){Name="Vasu",Age=10},
                  new Student(){Name="Pournima",Age=13}
       };

	        //Fluent Syntax/Expression Method Syntax
			IEnumerable<Student> result = studentList.Where(s => s.Age > 15).ToList();
            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
            }


            //Query Syntax
            var result2 = from s in studentList where s.Age > 15 select s.Name;
            foreach (var student in result2)
            {
                Console.WriteLine(student);
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
