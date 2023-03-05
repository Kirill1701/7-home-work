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
        // Метод входа в программу
        static void Point()
        {
            Console.Write("Для работы с данными сотрудников выберите действие: " +
                "\n1. Просмотр записей сотрудников;" +
                "\n2. Поиск сотрудника по ID;" +
                "\n3. Добавление нового сотрудника;" +
                "\n4. Удаление сотрудника по ID;" +
                "\n5. Сортировка по дате добавления сотрудников." +
                "\n6. Выйти из программы." +
                "\n");
        }

        static void Cycle()
        {
            int input = Convert.ToInt32(Console.ReadLine()); // Выбор пользователя

            Repository repository = new Repository(); 

            Worker worker = new Worker();

            int id = 0;

            var dateFrom = new DateTime();
            var dateTo = new DateTime();

            if (input == 1)
            {
                repository.GetAllWorkers(); // Постоянно открывается список, надо вернуться в главное менюю для выполнения дальнейших действий
            }
            else if (input == 2)
            {
                repository.GetWorkerById(id); // Поиск не прекращается при нажатии 'н' поиск продолжается. Надо вернуться для выполнения дальнейших действий
            }
            else if (input == 3)
            {
                repository.AddWorker(worker); // Добавление происходит. При нажатии 'н' программа вылетает. Надо вернуться для дальнейших действий
            }
            else if (input == 4)
            {
                repository.DeleteWorker(id); // Удаление происходит. При нажатии 'н' программа вылетает. Надо вернуться для дальнейших действий
            }
            else if (input == 5)
            {
                repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
            }
            else if (input == 6)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nНекорректное действие. Повторите ввод"); // Вроде решил проблему, else работает. При бесконечном неправильном вводе, программа повторяется
                Point();
                Cycle();
            }
        }

        static void Main(string[] args)
        {
            // Точка входа в программу
            Point();
            Cycle();
            Console.ReadKey();
        }
    }
}
