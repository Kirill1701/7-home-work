using System;
using System.Collections.Generic;
using System.Text;

namespace _7_HomeWork
{
    struct Worker
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

    }
}
