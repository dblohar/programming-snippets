using System;
using System.Threading.Tasks;

namespace _3_Creating_And_Starting_Task
{
    class Program
    {

        public static void PrintChar(char c) {

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(c);
            }
            
        }       

        static void Main(string[] args)
        {
            //Method 1
            Task.Factory.StartNew(()=>PrintChar('*'));

            //Method 2
            var t2 = new Task(()=> PrintChar('-'));
            t2.Start();

            //Method 3
            Task.Run(()=>PrintChar('R'));

           
            Console.ReadKey();
        }
    }
}
