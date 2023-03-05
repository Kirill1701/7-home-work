using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Net.NetworkInformation;

namespace _7_home_work
{
    public class Repository
    {
        public Worker[] GetAllWorkers() 
        {
            Reading();
            return GetAllWorkers();
        }

        public Worker GetWorkerById(int id)
        {
            Search();
            return GetWorkerById(id);
        }

        public void DeleteWorker(int id)
        {
            Delete();
        }

        public void AddWorker(Worker worker)
        {
            Note();
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker worker = new Worker();

            string[] workers = File.ReadAllLines("staff.csv", Encoding.Unicode);

            Console.Write($"Введите дату начала поиска: ");
            DateTime input1 = Convert.ToDateTime(Console.ReadLine());
            dateFrom = input1;

            Console.Write($"Введите конечную дату для поиска: ");
            DateTime input2 = Convert.ToDateTime(Console.ReadLine());
            dateTo = input2;

            foreach (string line in workers)
            {
                if (worker.DateTime >= dateFrom && worker.DateTime <= dateTo)
                    Console.WriteLine(line);
            }

            //using (StreamReader openFile = new StreamReader("staff.csv", Encoding.Unicode))
            //{
            //    string line;

            


            //    if (worker.DateTime >= dateFrom && worker.DateTime <= dateTo)
            //    {
            //        while ((line = openFile.ReadLine()) != null)
            //        {
            //            string[] staff = line.Split('\t');
            //            Console.WriteLine($"{staff[0],8} {staff[1],15}  {staff[2],35}" +
            //                $" {staff[3],4} {staff[4],5} {staff[5],15} {staff[6],25}");
            //        }
            //    }
            //}
            //string[] workersArray = File.ReadAllLines("staff.csv", Encoding.Unicode);

            

            //workersArray.OrderByDescending(x => x).Take(workersArray.Length);
            //workersArray.ToList();
            //Console.WriteLine(workersArray.ToString());

            //foreach (string line in workersArray)
            //{
            //    if (line.Contains(dateFrom.ToString()))
            //        Console.WriteLine(line);
                
            //}

            //if (worker.DateTime >= dateFrom && worker.DateTime <= dateTo)
            //    Console.WriteLine(line);
            //(worker.DateTime >= dateFrom && worker.DateTime <= dateTo)
            Console.ReadKey();
            return GetWorkersBetweenTwoDates(dateFrom, dateTo);
        }

        // Метод для заполнения данных
        static void Note()
        {
            // Создание файла
            using (StreamWriter file = new StreamWriter("staff.csv", true, Encoding.Unicode))
            {
                // Ключ для продолжения, либо прекращения работы
                char key = 'д';

                do
                {
                    Worker worker = new Worker();
                    // Объявление переменной с пустой строкой
                    string guide = string.Empty;

                    // Наполнение строк данными
                    Console.Write($"\nВведите ID сотрудника: ");
                    worker.ID = Convert.ToInt32(Console.ReadLine());
                    guide += $"{worker.ID}\t";

                    worker.DateTime = DateTime.Now; 
                    Console.WriteLine($"Дата и время добавления записи: {worker.DateTime}");
                    guide += $"{worker.DateTime}\t";

                    Console.Write("Введите Ф.И.О. сотрудника: ");
                    worker.FIO = Console.ReadLine();
                    guide += $"{worker.FIO}\t";

                    Console.Write("Введите возраст сотрудника: ");
                    worker.Age = Convert.ToInt32(Console.ReadLine());
                    guide += $"{worker.Age}\t";

                    Console.Write("Введите рост сотрудника: ");
                    worker.Height = Convert.ToInt32(Console.ReadLine());
                    guide += $"{worker.Height}\t";
                    
                    Console.Write("Введите дату рождения сотрудника: ");
                    worker.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    guide += $"{worker.DateOfBirth.ToShortDateString()}\t";

                    Console.Write("Введите место рождения сотрудника: ");
                    worker.PlaceOfBirth = Console.ReadLine();
                    guide += $"{worker.PlaceOfBirth}\t";

                    file.WriteLine(guide);

                    // Продолжить или прекратить работу
                    Console.Write("Продолжить н/д"); key = Console.ReadKey(true).KeyChar;
                }
                while (char.ToLower(key) == 'д'); // Считывание ключа, если 'д', то повторение цикла
            }
        }

        // Метод для чтения файла
        static void Reading()
        {
            try 
            {
                // Чтение файла
                using (StreamReader openFile = new StreamReader("staff.csv", Encoding.Unicode))
                {
                    string line;

                    while ((line = openFile.ReadLine()) != null) // Возможно попробовать if, чтобы цикл не повторялся. Массив вынести за цикл
                    {
                        string[] staff = line.Split('\t');
                        Console.WriteLine($"{staff[0],8} {staff[1],15}  {staff[2],35}" +
                            $" {staff[3],4} {staff[4],5} {staff[5],15} {staff[6],25}");
                    }
                }
            }
            catch // Создание нового файла, при его отсутствии. Выполнение метода Note
            {
                Note();
            }
            Console.ReadKey();
        }

        // Метод для поиска сотрудника
        static void Search()
        {
            // Ключ для продолжения поиска
            char key1 = 'д';

            // Поиск по введенным данным
            do
            {
                Console.Write("\nВведите ID сотрудника для поиска: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Объявление массива строк, чтение файла
                string[] lines = File.ReadAllLines("staff.csv", Encoding.Unicode);

                // Показать найденного сотрудника
                foreach (string line in lines)
                    if (line.Contains(id.ToString()))
                        Console.WriteLine(line);

                // Продолжить или прекратить работу
                Console.Write("Продолжить н/д"); key1 = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key1) == 'д'); // Считывание ключа, если 'д', то повторение цикла
        }

        // Метод удаления элемента массива по найденному индексу
        static void RemoveAt(ref string[] lines, int index)
        {
            // Создание нового массива данных для записи результата
            string[] newLines = new string[lines.Length - 1];

            // Извлечение элемента массива, копирование, перезапись массива -1 элемент 
            for (int i = 0; i < index; i++)
                newLines[i] = lines[i];

            for (int i = index + 1; i < lines.Length; i++)
                newLines[i - 1] = lines[i];

            // Присвоение старому массиву нового массива
            lines = newLines;
        }

        // Метод для удаления сотрудника по ID
        static void Delete()
        {
            char key = 'д';

            do
            {
                Console.Write("\nВведите ID сотрудника для удаления: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Объявление массива строк, чтение файла
                string[] lines = File.ReadAllLines("staff.csv", Encoding.Unicode);

                // Переменная для подсчета количества итераций цикла
                int value = 0;

                // Показать найденного сотрудника
                foreach (string line in lines)
                {
                    value++;
                    if (line.Contains(id.ToString()))
                    {
                        Console.WriteLine($"\n{line}");
                        break;
                    }
                }

                // Индекс полученного элемента массива
                int index = value - 1;

                // Применение метода для удаления элемента массива
                RemoveAt(ref lines, index);

                // Сохранить изменения в файле
                File.WriteAllLines("staff.csv", lines, Encoding.Unicode);
                Console.WriteLine("\nЗапись о сотруднике удалена.");

                // Продолжить или прекратить работу
                Console.Write("\nПродолжить н/д"); key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д'); // Считывание ключа, если 'д', то повторение цикла
        }
    }
}
