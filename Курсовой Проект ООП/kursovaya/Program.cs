using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Worker;
using Accountant;
using Developer;
using Electrician;
using WorkersAccounter;
using System.Diagnostics;

class Programm
{
    static void Main()
    {
       WorkersAccounter.WorkersAccounter wac = new WorkersAccounter.WorkersAccounter();

       while (true)
       {
            //Консольное меню
            char command_symbol = '\0';
            Console.WriteLine("\n\tПрограмма учета сотрудников предприятия. Все права защищены.");
            Console.WriteLine("\n Выберите действие из списка: \n\n" +
                                "  1.Просмотреть список сотрудников предприятия.\n" +
                                "  2. Добавить сотрудника. \n" +
                                "  3. Удалить сотрудника \n" +
                                "  4. Найти сотрудника по ID. \n" +
                                "  5. Выйти.");
            
            
            ConsoleKeyInfo command_key = Console.ReadKey();
            switch (command_key.Key)
            {
                case ConsoleKey.D1:     //Вывод списка сотрудников
                    Console.Clear();
                    Console.WriteLine("\n\t");
                    Console.WriteLine(wac.show_workers_list());
                    break;

                case ConsoleKey.D2:     //Добавление сотрудника
                    Console.Clear();
                    Console.WriteLine("\n\t");
                    Console.WriteLine("Выберите должность сотрудника: \n\t 1.Developer (Разработчик). \n\t 2.Electrician (Электрик). \n\t 3.Accountant (Бухгалтер).");
                    ConsoleKeyInfo workerSpec = Console.ReadKey();
                    Console.Clear();
                    switch (workerSpec.Key)
                    {
                        case ConsoleKey.D1:     //Разработчик
                            Developer.Developer new_developer = new Developer.Developer();

                            //Ввод параметров сотрудника
                            Console.WriteLine("Введите ФИО работника через пробел:");
                            string[] dev_full_name = Console.ReadLine().Split(' ');
                            new_developer.set_lastname(dev_full_name[0]);
                            new_developer.set_firstname(dev_full_name[1]);
                            new_developer.set_father_name(dev_full_name[2]);

                            Console.WriteLine("Введите дату рождения через пробел в формате: День, Месяц, Год");
                            string[] dev_date_of_bitrth = Console.ReadLine().Split(' ');
                            new_developer.set_date_of_birth(new DateTime(Convert.ToInt32(dev_date_of_bitrth[2]), Convert.ToInt32(dev_date_of_bitrth[1]), Convert.ToInt32(dev_date_of_bitrth[0])));

                            Console.WriteLine("Введите место прописки:");
                            new_developer.set_registration(Console.ReadLine());

                            Console.WriteLine("Введите ID работника:");
                            new_developer.set_id(Console.ReadLine());

                            Console.WriteLine("Введите серию паспорта:");
                            new_developer.set_pass_serial(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите номер паспорта:");
                            new_developer.set_pass_number(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите опыт работы (число лет в профессии):");
                            new_developer.set_worker_exp(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите размер заработной платы (в рублях):");
                            new_developer.set_salary(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Выберите уровень доступа разработчика: \n 1. Наивысший. \n 2. Средний. \n 3. Минимальный.");
                            ConsoleKeyInfo dev_access_level = Console.ReadKey();
                            switch (dev_access_level.Key)
                            {
                                case ConsoleKey.D1:
                                    new_developer.set_access_level(1);
                                    break;
                                case ConsoleKey.D2:
                                    new_developer.set_access_level(2);
                                    break;
                                case ConsoleKey.D3:
                                    new_developer.set_access_level(3);
                                    break;
                                default:
                                    Console.WriteLine("Error: Несуществующий вариант выбора.");
                                    Console.Clear();
                                    continue;
                            }

                            Console.Clear();

                            Console.WriteLine("Выберите уровень стажа разработчика: \n 1. Junior. \n 2. Middle. \n 3. Senior.");
                            ConsoleKeyInfo prog_level = Console.ReadKey();
                            switch (prog_level.Key)
                            {
                                case ConsoleKey.D1:
                                    new_developer.set_coding_level("Junior");
                                    break;
                                case ConsoleKey.D2:
                                    new_developer.set_coding_level("Middle");
                                    break;
                                case ConsoleKey.D3:
                                    new_developer.set_coding_level("Senior");
                                    break;
                                default:
                                    Console.WriteLine("Error: Несуществующий вариант выбора.");
                                    continue;
                            }

                            Console.Clear();

                            Console.WriteLine("Удаленно ли будет работать разработчик?: \n 1. Да. \n 2. Нет.");
                            ConsoleKeyInfo working_type = Console.ReadKey();
                            switch (working_type.Key)
                            {
                                case ConsoleKey.D1:
                                    new_developer.set_working_type("Online");
                                    break;
                                case ConsoleKey.D2:
                                    new_developer.set_working_type("Offline");
                                    break;
                                default:
                                    Console.WriteLine("Error: Несуществующий вариант выбора.");
                                    Console.Clear();
                                    continue;
                            }

                            Console.Clear();

                            Console.WriteLine("Введите технологии, которые знает разработчик (через запятую и пробел)");
                            List<string> skills = new List<string>(Console.ReadLine().Split(", "));
                            new_developer.set_skills(skills);

                            wac.add_worker(new_developer);
                            Console.WriteLine("developer added.");
                            break;


                        case ConsoleKey.D2:     //Электрик
                            Electrician.Electrician new_electrician = new Electrician.Electrician();

                            //Ввод параметров сотрудника
                            Console.WriteLine("Введите ФИО работника через пробел:");
                            string[] elec_full_name = Console.ReadLine().Split(' ');
                            new_electrician.set_lastname(elec_full_name[0]);
                            new_electrician.set_firstname(elec_full_name[1]);
                            new_electrician.set_father_name(elec_full_name[2]);

                            Console.WriteLine("Введите дату рождения через пробел в формате: День, Месяц, Год");
                            string[] elec_date_of_bitrth = Console.ReadLine().Split(' ');
                            new_electrician.set_date_of_birth(new DateTime(Convert.ToInt32(elec_date_of_bitrth[2]), Convert.ToInt32(elec_date_of_bitrth[1]), Convert.ToInt32(elec_date_of_bitrth[0])));

                            Console.WriteLine("Введите место прописки:");
                            new_electrician.set_registration(Console.ReadLine());

                            Console.WriteLine("Введите ID работника:");
                            new_electrician.set_id(Console.ReadLine());

                            Console.WriteLine("Введите серию паспорта:");
                            new_electrician.set_pass_serial(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите номер паспорта:");
                            new_electrician.set_pass_number(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите опыт работы (число лет в профессии):");
                            new_electrician.set_worker_exp(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите размер заработной платы (в рублях):");
                            new_electrician.set_salary(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Выберите уровень доступа электрика: \n 1. Наивысший. \n 2. Средний. \n 3. Минимальный. ");
                            ConsoleKeyInfo elec_access_level = Console.ReadKey();
                            switch (elec_access_level.Key)
                            {
                                case ConsoleKey.D1:
                                    new_electrician.set_access_level(1);
                                    break;
                                case ConsoleKey.D2:
                                    new_electrician.set_access_level(2);
                                    break;
                                case ConsoleKey.D3:
                                    new_electrician.set_access_level(3);
                                    break;
                                default:
                                    Console.WriteLine("Error: Несуществующий вариант выбора.");
                                    Console.Clear();
                                    continue;
                            }

                            Console.Clear();

                            Console.WriteLine("Введите разряд электрика:");
                            new_electrician.set_charge(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите специализацию электрика:");
                            new_electrician.set_specialization(Console.ReadLine());

                            Console.WriteLine("Введите список инструментов, которыми обладает электрик (через запятую и пробел)");
                            List<string> tool_kit = new List<string>(Console.ReadLine().Split(", "));
                            new_electrician.set_tool_kit(tool_kit);

                            wac.add_worker(new_electrician);
                            Console.WriteLine("electrician added.");
                            break;


                        case ConsoleKey.D3:     //Бухгалтер
                            Accountant.Accountant new_accountant = new Accountant.Accountant();

                            //Ввод параметров сотрудника
                            Console.WriteLine("Введите ФИО работника через пробел:");
                            string[] acco_full_name = Console.ReadLine().Split(' ');
                            new_accountant.set_lastname(acco_full_name[0]);
                            new_accountant.set_firstname(acco_full_name[1]);
                            new_accountant.set_father_name(acco_full_name[2]);

                            Console.WriteLine("Введите дату рождения через пробел в формате: День, Месяц, Год");
                            string[] acco_date_of_bitrth = Console.ReadLine().Split(' ');
                            new_accountant.set_date_of_birth(new DateTime(Convert.ToInt32(acco_date_of_bitrth[2]), Convert.ToInt32(acco_date_of_bitrth[1]), Convert.ToInt32(acco_date_of_bitrth[0])));

                            Console.WriteLine("Введите место прописки:");
                            new_accountant.set_registration(Console.ReadLine());

                            Console.WriteLine("Введите ID работника:");
                            new_accountant.set_id(Console.ReadLine());

                            Console.WriteLine("Введите серию паспорта:");
                            new_accountant.set_pass_serial(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите номер паспорта:");
                            new_accountant.set_pass_number(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите опыт работы (число лет в профессии):");
                            new_accountant.set_worker_exp(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите размер заработной платы (в рублях):");
                            new_accountant.set_salary(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите разряд бухгалтера:");
                            new_accountant.set_charge(Convert.ToInt32(Console.ReadLine()));

                            Console.WriteLine("Введите дату представления отчетности через пробел в формате: День, Месяц, Год");
                            string[] date_of_reporting = Console.ReadLine().Split(" ");
                            new_accountant.set_accounting_date(new DateTime(Convert.ToInt32(date_of_reporting[2]), Convert.ToInt32(date_of_reporting[1]), Convert.ToInt32(date_of_reporting[0])));

                            Console.WriteLine("Введите область деятельности:");
                            new_accountant.set_area_of_activity(Console.ReadLine());

                            wac.add_worker(new_accountant);
                            Console.WriteLine("accountant added.");
                            break;

                        default:
                            Console.WriteLine("Error: Несуществующий вариант выбора.");
                            Console.Clear();
                            continue;
                    }
                    break;

               case ConsoleKey.D3:      //Удаление сотрудника
                    Console.Clear();
                    Console.WriteLine("Введите ID сотрудника для удаления:");
                    Console.WriteLine(wac.delete_worker(Console.ReadLine()));
                    break;

                case ConsoleKey.D4:     //Поиск сотрудника
                    Console.Clear();
                    Console.WriteLine("Введите ID сотрудника для поиска:");
                    Console.WriteLine(wac.find_worker(Console.ReadLine()));
                    break;
                    
                case ConsoleKey.D5:     //Выход
                    Console.Clear();
                    return;

                default:
                    Console.WriteLine("Error: Несуществующий вариант выбора.");
                    Console.Clear();
                    continue;
            }

            Console.WriteLine("\n\t Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
       }
    }

}
