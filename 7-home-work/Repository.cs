using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7_home_work
{
    public class Repository
    {
        // Просмотр записей сотрудников
        public Worker[] GetAllWorkers() 
        {
            Worker[] workers = new Worker[7];
            Reading();
            Console.WriteLine("\nEnter - возврат в главное меню.");
            Console.ReadKey();
            return workers;
        }

        // Поиск сотрудника по ID
        public Worker GetWorkerById(int id)
        {
            Worker worker = new Worker();
            Search();
            Console.WriteLine("\nEnter - возврат в главное меню.");
            Console.ReadKey();
            return worker;
        }

        // Удаление сотрудника по ID
        public void DeleteWorker(int id)
        {
            Delete();
            Console.WriteLine("\nEnter - возврат в главное меню.");
            Console.ReadKey();
        }

        // Добавление нового сотрудника
        public void AddWorker(Worker worker)
        {
            Note();
            Console.WriteLine("\nEnter - возврат в главное меню.");
            Console.ReadKey();
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = new Worker[7];

            //List<Worker> result = new List<Worker>();

            Worker worker = new Worker();

            Console.Write($"Введите дату начала поиска: ");
            dateFrom = Convert.ToDateTime(Console.ReadLine());

            Console.Write($"Введите конечную дату для поиска: ");
            dateTo = Convert.ToDateTime(Console.ReadLine());

            string[] sortedWorkers = File.ReadAllLines("staff.csv", Encoding.Unicode);

            Console.ReadKey();
            return workers;
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
                    // Инициализация
                    Worker worker = new Worker();

                    // Объявление переменной с пустой строкой
                    string guide = string.Empty;

                    // Наполнение строк данными
                    Console.Write($"\nВведите ID сотрудника (6 цифр): ");
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
                    
                    Console.Write("Введите дату рождения сотрудника (дд.мм.гггг): ");
                    worker.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    guide += $"{worker.DateOfBirth.ToShortDateString()}\t";

                    Console.Write("Введите место рождения сотрудника: ");
                    worker.PlaceOfBirth = Console.ReadLine();
                    guide += $"{worker.PlaceOfBirth}\t";

                    file.WriteLine(guide);

                    // Продолжить или прекратить работу
                    Console.Write("\nПродолжить н/д"); key = Console.ReadKey(true).KeyChar;
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

                    while ((line = openFile.ReadLine()) != null) 
                    {
                        string[] workers = line.Split('\t');
                        Console.WriteLine($"{workers[0],8} {workers[1],15}  {workers[2],35}" +
                            $" {workers[3],4} {workers[4],5} {workers[5],15} {workers[6],25}");
                    }
                }
            }
            catch // Создание нового файла, при его отсутствии. Выполнение метода Note
            {
                Note();
            }
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

                string[] workers = File.ReadAllLines("staff.csv", Encoding.Unicode);

                // Показать найденного сотрудника
                foreach (string line in workers)
                    if (line.Contains(id.ToString()))
                        Console.WriteLine($"\n{line}");

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

                string[] workers = File.ReadAllLines("staff.csv", Encoding.Unicode);

                int value = 0;

                // Показать найденного сотрудника
                foreach (string line in workers)
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
                RemoveAt(ref workers, index);

                // Сохранить изменения в файле
                File.WriteAllLines("staff.csv", workers, Encoding.Unicode);
                Console.WriteLine("\nЗапись о сотруднике удалена.");

                // Продолжить или прекратить работу
                Console.Write("\nПродолжить н/д"); key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д'); // Считывание ключа, если 'д', то повторение цикла
        }

        //static void SortDate(ref DateTime[] dates, DateTime dateFrom, DateTime dateTo)
        //{
        //    List<DateTime> result = new List<DateTime>();

        //    foreach (var data in dates)
        //    {
        //        if (data >= dateFrom && data <= dateTo)
        //            result.Add(data);
        //    }

        //    dates = result.ToArray();
        //}
    }
}
