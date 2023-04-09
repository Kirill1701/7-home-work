using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace _7_home_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация
            Repository repository = new Repository();
            Worker worker = new Worker();
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();

            int id = 0;
            char key = 'н';

            // Основное окно программы
            do 
            {
                Console.Write("\nДля работы с данными сотрудников выберите действие: " +
                "\n1. Просмотр сотрудников;" +
                "\n2. Поиск сотрудника по ID;" +
                "\n3. Добавление нового сотрудника;" +
                "\n4. Удаление сотрудника по ID;" +
                "\n5. Сортировка по дате добавления сотрудников;" +
                "\n6. Выход из программы" +
                "\n");
                Console.WriteLine(new string('-', 50));

                // Чтение действия
                string input = Console.ReadLine();

                // Выполнение действия
                if (input == "1")
                    repository.GetAllWorkers(); 
                else if (input == "2")
                    repository.GetWorkerById(id); 
                else if (input == "3")
                    repository.AddWorker(worker); 
                else if (input == "4")
                    repository.DeleteWorker(id); 
                else if (input == "5")
                    repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                else if (input == "6")
                {
                    Console.Write("\nВы хотите завершить работу? н/д" +
                    "\n"); key = Console.ReadKey(true).KeyChar;
                }
                else
                    Console.WriteLine("\nНекорректное действие. Повторите ввод");
            }
            while (char.ToLower(key) == 'н');
        }
    }
}
