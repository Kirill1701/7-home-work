using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7_home_work
{
    public struct Worker
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// рост сотрудника
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
