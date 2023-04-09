using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7_home_work
{
    public class Repository
    {
        string file = "workers.csv";
        Worker[] workers;
        char key = 'д';

        /// <summary>
        /// Проверка наличия файла. Создание, если его не существует
        /// </summary>
        public Repository() 
        {
            if (!File.Exists(file))
                File.Create(file).Close();
            LoadData();
        }

        /// <summary>
        /// Чтение списка сотрудников
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers() 
        {
            if (workers.Length == 0) 
                Console.WriteLine("Список сотрудников пуст");
            foreach (var worker in workers)
                Reading(worker);
            return workers;
        }

        /// <summary>
        /// Поиск сотрудника по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            Worker worker = workers[id];
            Search();
            return worker;
        }

        /// <summary>
        /// Удаление сотрудника по ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id) 
        {
            do
            {
                Console.Write("\nВведите ID сотрудника для удаления: ");
                id = Convert.ToInt32(Console.ReadLine());

                var worker = workers.FirstOrDefault(w => w.Id == id);

                if (worker.Id != 0)
                    Reading(worker);
                else
                    Console.WriteLine("\nРаботника не существует");

                // Индекс полученного элемента массива
                int index = workers.ToList().IndexOf(worker);

                // Применение метода для удаления элемента массива
                RemoveAt(ref workers, index);

                // Сохранить изменения в файле
                SaveData();
                Console.WriteLine("\nЗапись о сотруднике удалена.");

                // Продолжить или прекратить работу
                Console.Write("\nПродолжить н/д"); key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д');
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            do
            {
                Console.Write("\nВведите фамилию, имя, отчество сотрудника: ");
                string fio = Console.ReadLine();

                Console.Write("Введите возраст сотрудника: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Введите рост сотрудника: ");
                int height = int.Parse(Console.ReadLine());

                Console.Write("Введите дату рождения сотрудника (dd.MM.yyyy): ");
                DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

                Console.Write("Введите место рождения сотрудника: ");
                string placeOfBirth = Console.ReadLine();

                var newWorker = new Worker
                {
                    Id = workers.Length + 1,
                    CreatedAt = DateTime.Now,
                    FIO = fio,
                    Age = age,
                    Height = height,
                    DateOfBirth = dateOfBirth,
                    PlaceOfBirth = placeOfBirth
                };

                workers = workers.Append(newWorker).ToArray();

                SaveData();

                Console.WriteLine("\nНовый сотрудник: ");
                Reading(newWorker);

                Console.Write("\nПродолжить д/н"); key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д');
        }

        /// <summary>
        /// Сортировка по дате добавления
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Console.Write("Введите дату начала поиска (dd.MM.yyyy): ");
            dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            Console.Write("Введите конечную дату поиска (dd.MM.yyyy): ");
            dateTo = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);


            var sortedWorkers = workers.Where(w => w.CreatedAt >= dateFrom && w.CreatedAt <= dateTo);

            foreach (var worker in sortedWorkers)
                Reading(worker);
            return workers;
        }
        
        // Конструктор 
        void LoadData() 
        {
            workers = File.ReadAllLines(file)
                .Select(line => line.Split('#'))
                .Select(data => new Worker
                {
                    Id = int.Parse(data[0]),
                    CreatedAt = DateTime.ParseExact(data[1], "dd.MM.yyyy HH:mm:ss", null),
                    FIO = data[2],
                    Age = int.Parse(data[3]),
                    Height = int.Parse(data[4]),
                    DateOfBirth = DateTime.ParseExact(data[5], "dd.MM.yyyy", null),
                    PlaceOfBirth = data[6]
                })
                .ToArray();
        }

        // Метод для сохранения изменений в файле
        void SaveData()
        {
            var lines = workers.Select(worker => $"{worker.Id}#{worker.CreatedAt:dd.MM.yyyy HH:mm:ss}#" +
            $"{worker.FIO}#{worker.Age}#{worker.Height}#{worker.DateOfBirth:dd.MM.yyyy}#{worker.PlaceOfBirth}");

            File.WriteAllLines(file, lines, Encoding.Unicode);
        }

        // Метод для чтения файла
        void Reading(Worker worker)
        {
            Console.WriteLine($"{worker.Id} {worker.CreatedAt} {worker.FIO} {worker.Age} {worker.Height} " +
                $"{worker.DateOfBirth.ToShortDateString()} {worker.PlaceOfBirth}");
        }

        // Метод для удаления элемента массива
        void RemoveAt(ref Worker[] workers, int index)
        {
            // Создание нового массива данных для записи результата
            Worker[] newWorkers = new Worker[workers.Length - 1];

            // Извлечение элемента массива, копирование, перезапись массива -1 элемент 
            for (int i = 0; i < index; i++)
                newWorkers[i] = workers[i];

            for (int i = index + 1; i < workers.Length; i++)
                newWorkers[i - 1] = workers[i];

            // Присвоение старому массиву нового массива
            workers = newWorkers;
        }

        // Метод для поиска по ID
        void Search()
        {
            do
            {
                Console.Write("\nВведите ID сотрудника для поиска: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var worker = workers.FirstOrDefault(w => w.Id == id);
                if (worker.Id != 0)
                    Reading(worker);
                else
                    Console.WriteLine("\nРаботника не существует");
                Console.Write("\nПродолжить поиск н/д"); key = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(key) == 'д');
        }
    }
}
