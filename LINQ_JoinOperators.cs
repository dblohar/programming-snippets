using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LINQDemos
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<Student> studentList = new List<Student>(){
                new Student(){ID = 1, StudentName = "John",Age = 18,StandardID = 1},
                new Student(){ID = 2, StudentName = "Steve",Age = 21,StandardID = 1},
                new Student(){ID = 3, StudentName = "Bill",Age = 20, StandardID =2},
                new Student(){ID = 4, StudentName = "Ram",Age = 18,StandardID =2 },
                new Student(){ID = 5, StudentName = "Abram",Age = 21},
             };


            IList<Standard> standardList = new List<Standard>() { 
                new Standard(){ StandardID = 1, StandardName = "1st Standard"},
                new Standard(){ StandardID = 2, StandardName = "2nd Standard"},
                new Standard(){ StandardID = 3, StandardName = "3rd Standard"}
            };


            #region Join Operator
            /*
                        Console.WriteLine("\nJoin using Method Syntax");

                        var innerJoin =  studentList.Join(standardList,
                            student => student.StandardID,
                            standard => standard.StandardID, 
                            (student, standard) => 
                                new 
                                { 
                                    student.StudentName,
                                    standard.StandardName
                                }
                            );

                        studentList.Add(new Student() { ID = 6, StudentName = "Ali", Age = 21, StandardID = 1 });


                        foreach (var result in innerJoin)
                        {
                            Console.WriteLine($"Student Name : {result.StudentName },\t Standard : {result.StandardName}");


                        }


                        Console.WriteLine("\nJoin using Query Syntax");

                        var innerJoinQuerySyntax = from s in studentList
                                                   join st in standardList on
                                                   s.StandardID equals st.StandardID
                                                   select new
                                                   {
                                                       s.StudentName,
                                                       st.StandardName
                                                   };

                        Console.WriteLine(@"var innerJoinQuerySyntax = from s in studentList
                                                   join st in standardList on
                                                   s.StandardID equals st.StandardID
                                                   select new
                                                   {
                                                       s.StudentName,st.StandardName
                                                   };");

                        foreach (var result in innerJoinQuerySyntax)
                        {
                            Console.WriteLine($"Student Name : {result.StudentName },\t Standard : {result.StandardName}");


                        }



            */

            #endregion



            #region GroupJoin Operator


            Console.WriteLine("Group By Using mehtod Syntax");
                var groupJoin = standardList.GroupJoin(studentList,
                    stud => stud.StandardID,
                    stand => stand.StandardID,
                    (stand,studentGroup)=> new {
                        Students = studentGroup,
                        StandardFullName = stand.StandardName
                    });



                foreach (var key in groupJoin) {
                    Console.WriteLine($"Group Join Key: {key.StandardFullName}");

                    foreach (var s in key.Students) {
                        Console.WriteLine($"\tStudent Name : {s.StudentName}");
                    }
                    Console.WriteLine();
                }


            Console.WriteLine("\nGroup By Using Query Syntax");

            var groupJoinQuerySyntax = from stand in standardList
                                       join stud in studentList
                                       on stand.StandardID equals stud.StandardID
                                       into studentGroup
                                       select new
                                       {
                                           Students = studentGroup,
                                           StandardFullName = stand.StandardName
                                       };

            foreach (var key in groupJoinQuerySyntax)
            {
                Console.WriteLine($"Group Join Key: {key.StandardFullName}");

                foreach (var s in key.Students)
                {
                    Console.WriteLine($"\tStudent Name : {s.StudentName}");
                }
                Console.WriteLine();
            }
            #endregion
            Console.ReadLine();
        }
    }

    internal class Student
    {
        public Student()
        {
        }

        public int ID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public int StandardID { get; set; }
    }

    internal class Standard
    {
        public Standard() { 
        }
        public int StandardID { get; set; }

        public string StandardName { get; set; }
    }
}
