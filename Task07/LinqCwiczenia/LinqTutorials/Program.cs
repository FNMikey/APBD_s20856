using LinqTutorials.Models;
using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = LinqTasks.Task1();
            var task2 = LinqTasks.Task2();
            var task3 = LinqTasks.Task3();
            var task4 = LinqTasks.Task4();
            var task5 = LinqTasks.Task5();
            var task6 = LinqTasks.Task6();
            var task7 = LinqTasks.Task7();
            var task8 = LinqTasks.Task8();
            var task9 = LinqTasks.Task9();


            foreach (Emp emp in task1) { Console.WriteLine("Task 1: " + emp); };
            Console.WriteLine("-----------------------");
            foreach (Emp emp in task2) { Console.WriteLine("Task 2: " + emp); };
            Console.WriteLine("-----------------------");
            Console.WriteLine("Task 3: " + task3);
            Console.WriteLine("-----------------------");
            foreach (Emp emp in task4) { Console.WriteLine("Task 4: " + emp); };
            Console.WriteLine("-----------------------");
            foreach (Object emp in task5) { Console.WriteLine("Task 5: " + emp); };
            Console.WriteLine("-----------------------");
            foreach (Object emp in task6) { Console.WriteLine("Task 6: " + emp); };
            Console.WriteLine("-----------------------");
            foreach (Object emp in task7) { Console.WriteLine("Task 7: " + emp); };
            Console.WriteLine("-----------------------");
            Console.WriteLine("Task 8: " + task8);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Task 9: " + task9);
            Console.WriteLine("-----------------------");

        }
    }
}
