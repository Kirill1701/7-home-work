using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _7_home_work
{
    internal class Program
    {
        // Главное меню программы
        public static void Point()
        {
            Console.Write("\nДля работы с данными сотрудников выберите действие: " +
                "\n1. Просмотр записей сотрудников;" +
                "\n2. Поиск сотрудника по ID;" +
                "\n3. Добавление нового сотрудника;" +
                "\n4. Удаление сотрудника по ID;" +
                "\n5. Сортировка по дате добавления сотрудников;" +
                "\n6. Выйти из программы." +
                "\n");
            Console.WriteLine(new string('-', 50));
        }

        // Метод выполнения действий пользователя
        static void Cycle()
        {
            var input = Console.ReadLine(); // Выбор пользователя

            Repository repository = new Repository(); 

            Worker worker = new Worker();

            int id = 0;

            DateTime dateFrom = DateTime.MinValue;
            DateTime dateTo = DateTime.MaxValue;

            if (input == "1")
            {
                repository.GetAllWorkers(); // Просмотр записей сотрудников
            }
            else if (input == "2")
            {
                repository.GetWorkerById(id); // Поиск сотрудника по ID
            }
            else if (input == "3")
            {
                repository.AddWorker(worker); // Добавление нового сотрудника
            }
            else if (input == "4")
            {
                repository.DeleteWorker(id); // Удаление сотрудника по ID
            }
            else if (input == "5")
            {
                repository.GetWorkersBetweenTwoDates(dateFrom, dateTo); // Сортировка по дате добавления сотрудников
            }
            else if (input == "6")
            {
                Environment.Exit(0); // Выход из программы
            }
            else
            {
                Console.WriteLine("\nНекорректное действие. Повторите ввод");
                Point();
                Cycle();
            }
        }

        static void Main(string[] args)
        {
            // Точка входа в программу
            Again:
            Point();
            Cycle();
            goto Again;
        }
    }
}
