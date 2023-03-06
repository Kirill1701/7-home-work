using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_home_work
{
    public struct Worker
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Фамилия, имя, отчество сотрудника
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string PlaceOfBirth { get; set; }

        //public Worker(int ID, DateTime DateTime, string FIO, int Age, int Height, DateTime DateOfBirth, string PlaceOfBirth)
        //{
        //    this.ID = ID;
        //    this.DateTime = DateTime;
        //    this.FIO = FIO;
        //    this.Age = Age;
        //    this.Height = Height;
        //    this.DateOfBirth = DateOfBirth;
        //    this.PlaceOfBirth = PlaceOfBirth;
        //}
    }
}
