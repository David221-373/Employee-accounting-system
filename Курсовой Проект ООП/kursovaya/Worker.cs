using System;   
using System.Collections.Generic;    
using System.Collections.Specialized;

namespace Worker  //Задаем пространство имен,чтобы мы могли подключить простравнство имен в другом файле
{
    public class Worker  // Создаем  Базовый (основной)класс-сотрудник 
    {
        
        private string lastname;            // Фамилия          объявляем переменные класса 
        private string firstname;           // Имя
        private string father_name;         // Отчество
        private string registration;        // Место регистрации
        private int pass_serial;            // Серия паспорта 
        private int pass_number;            // Номер паспорта
        private DateTime date_of_birth;     // Дата рождения
        private string id;                  // Серийный номер сотрудника
        private int worker_exp;             // Стаж работы (в годах)
        private int salary;                 // Размер ЗП


        //  Описываем Конструктор по умолчанию (Пустой констурктор)
        public Worker()    
        {
            lastname = string.Empty;   // Инициализируем переменные пустыми значениями
            firstname = string.Empty;
            father_name = string.Empty;
            registration = string.Empty;
            id = string.Empty;

            pass_serial = 0;
            pass_number = 0;
            worker_exp = 0;
            salary = 0;

            date_of_birth = new DateTime();  // При создании объетка создается пустой объект типа date-time и присваеваем его полю класса date_of_birth


        }
        // Конструктор с параметрами
        public Worker(string _id, string _lastname, string _firstname, string _father_name, string _registration, int _pass_serial, int _pass_number, int _worker_exp, int _salary, DateTime _date_of_birth)
        {
            lastname = _lastname;
            firstname = _firstname;
            father_name = _father_name;
            registration = _registration;
            id = _id;

            pass_serial = _pass_serial;
            pass_number = _pass_number;
            worker_exp = _worker_exp;
            salary = _salary;

            date_of_birth = new DateTime(_date_of_birth.Year, _date_of_birth.Month, _date_of_birth.Day);
        }

        // Геттеры (Возвращает в переменную)
        public string get_lastname()                { return lastname; }
        public string get_firstname()               { return firstname; }
        public string get_father_name()             { return father_name; }
        public string get_FIO()                     { return lastname + " " + firstname + " " + father_name; }
        public string get_registration()            { return registration; }
        public string get_id()                      { return id; }
        public int get_pass_serial()                { return pass_serial; }
        public int get_pass_number()                { return pass_number; }
        public int get_worker_exp()                 { return worker_exp; }
        public int get_salary()                     { return salary; }
        public DateTime get_date_of_birth()         { return date_of_birth; }

        // Сеттеры (Записывет)
        public void set_lastname(string _lastname)                 { lastname = _lastname; }
        public void set_firstname(string _firstname)               { firstname = _firstname; }
        public void set_father_name(string _father_name)           { father_name = _father_name; }
        public void set_registration(string _registration)         { registration = _registration; }
        public void set_id(string _id)                             { id = _id; }
        public void set_pass_serial(int _pass_serial)              { pass_serial = _pass_serial; }
        public void set_pass_number(int _pass_number)              { pass_number = _pass_number; }
        public void set_worker_exp(int _worker_exp)                { worker_exp = _worker_exp; }
        public void set_salary(int _salary)                        { salary = _salary; }
        public void set_date_of_birth(DateTime _date_of_birth)     { date_of_birth = new DateTime(_date_of_birth.Year, _date_of_birth.Month, _date_of_birth.Day); }

    }
}
