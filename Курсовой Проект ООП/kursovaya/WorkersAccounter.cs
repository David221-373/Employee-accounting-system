using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Worker;
using Accountant;
using Developer;
using Electrician;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WorkersAccounter
{
	public class WorkersAccounter  // Определнеие класса, реализующего основные функции приложения (Список сотрудников и добавить и удалить ит д)
	{
        private string workers_list_file_path;      //Директория списка сотрудников  // Объявляем переменные класса 
		private string developers_file_path;        //Директория группы разработчиков
        private string accountants_file_path;       //Директория группы бухгалтеров
        private string electricians_file_path;      //Директория группы электриков
        private string active_file_path;            //Текущая активная директория для создания карточек сотрудников
        private string output_str;                  //Строка для вывода списка сотрудников
		private StreamWriter stream_writer;         //Класс потокового файлового ввода 
		 

        //Конструктор по умолчанию (не пустые значения) При создании инициализируется (создается) Путь к папкам 
        public WorkersAccounter()
		{
            workers_list_file_path = "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\WorkersList.txt";
            developers_file_path = "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Developers";
            accountants_file_path = "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Accountants";
            electricians_file_path = "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Electricians";
            active_file_path = "";
            output_str = "";

        }

        // Метод получения пути к файлу списка сотрудников
        public string get_workers_list_file_path() { return workers_list_file_path; }

        //Метод вывода списка сотрудников на экран
        public string show_workers_list()   // Описание метода 
		{
			if (!File.Exists(workers_list_file_path))
			{
				return "Error: there is no existing file";
			}

			output_str = "";
			output_str = File.ReadAllText(workers_list_file_path);
			            
			return output_str;
		}

        //Полиморфный метод добавления сотрудника (добавление разработчика)
		public string add_worker(Developer.Developer new_developer) // В данном случае в  круглых скобках мы объявляем,что туда будет передавтаься объект с именем new_developer типа класса Developer,котррый находится в пространстве имен Developer 
		{
            if (!File.Exists(workers_list_file_path)) // Если не существует файл находящийся в дериктории workers_list_file_path
            {
                return "Error: there is no existing file: workers_list\n";
            }
			
            active_file_path = "";
            // Класс File посредством метода ReadAllText считывает с файла workers_list_file_path текст и методом Contains проверяется наличие id или ФИО(Метод Contain это метод класса String)
            if (File.ReadAllText(workers_list_file_path).Contains(new_developer.get_id()) || File.ReadAllText(workers_list_file_path).Contains(new_developer.get_FIO()))
			{
				return "Error: trying to add an existing worker";
			}

			active_file_path = developers_file_path + "\\" + new_developer.get_id() + ".txt";   //Сборка директории для будущего файла

			stream_writer = new StreamWriter(workers_list_file_path, true);     //Второй аргумент указывает на отсутствие перезаписи файла
            
            //Добавление работника в список
			stream_writer.WriteLine("ID: " + new_developer.get_id() + String.Concat(Enumerable.Repeat(" ", (7 - new_developer.get_id().Length))) + "\t\t" + "FullName: " + new_developer.get_FIO() + String.Concat(Enumerable.Repeat(" ",(38 - new_developer.get_FIO().Length))) + "\t\t" + "Vocation: Developer");
			stream_writer.Close();

            string skills = "";
            int column_counter = 0;
            
            //Скиллы записываются не в строчку, а матрицей с 4-мя столбцами 
            foreach (string line in new_developer.get_skills())
            {
                column_counter++;
                skills = skills + line + ", ";
                if (column_counter == 4)
                {
                    column_counter = 0;
                    skills += "\n";
                }
            }
            
            //Запись объекта в файл
			stream_writer = new StreamWriter(active_file_path);
			stream_writer.WriteLine("ID:" + "\t\t" + new_developer.get_id());
            stream_writer.WriteLine("Full name:" + "\t\t" + new_developer.get_FIO());
			stream_writer.WriteLine("Date of birth:" + "\t\t" + new_developer.get_date_of_birth().Date + "\n");
            stream_writer.WriteLine("Registration:" + "\t\t" + new_developer.get_registration());
            stream_writer.WriteLine("Passport serial:" + "\t\t" + new_developer.get_pass_serial());
            stream_writer.WriteLine("Passport number:" + "\t\t" + new_developer.get_pass_number() + "\n");
            stream_writer.WriteLine("Access level:" + "\t\t" + new_developer.get_access_level());
            stream_writer.WriteLine("Worker experience:" + "\t\t" + new_developer.get_worker_exp());
            stream_writer.WriteLine("Worker salary:" + "\t\t" + new_developer.get_salary());
			stream_writer.WriteLine("Coding level:" + "\t\t" + new_developer.get_coding_level());
			stream_writer.WriteLine("Working type:" + "\t\t" + new_developer.get_working_type());
			stream_writer.WriteLine("Skills:" + "\t\t" + skills);
			stream_writer.Close();

            return "worker added.";
		}

        //Полиморфный метод добавления сотрудника (добавление электрика)
        public string add_worker(Electrician.Electrician new_electrician)
        {
            if (!File.Exists(workers_list_file_path))
            {
                return "Error: there is no existing file: workers_list\n";
            }

            active_file_path = "";

            if (File.ReadAllText(workers_list_file_path).Contains(new_electrician.get_id()) || File.ReadAllText(workers_list_file_path).Contains(new_electrician.get_FIO()))
            {
                return "Error: trying to add an existing worker";
            }

            active_file_path = electricians_file_path + "\\" + new_electrician.get_id() + ".txt";   //Сборка директории для будущего файла

            stream_writer = new StreamWriter(workers_list_file_path, true);     //Второй аргумент указывает на отсутствие перезаписи файла

            //Добавление работника в список 
            stream_writer.WriteLine("ID: " + new_electrician.get_id() + String.Concat(Enumerable.Repeat(" ", (7 - new_electrician.get_id().Length))) + "\t\t" + "FullName: " + new_electrician.get_FIO() + String.Concat(Enumerable.Repeat(" ", (38 - new_electrician.get_FIO().Length))) + "\t\t" + "Vocation: Electrician");
            stream_writer.Close();

            string tool_kit = "";
            int column_counter = 0;

            //Инструменты записываются не в строчку, а матрицей с 4-мя столбцами
            foreach (string line in new_electrician.get_tool_kit())
            {
                column_counter++;
                tool_kit = tool_kit + line + ", ";
                if (column_counter == 4)
                {
                    column_counter = 0;
                    tool_kit += "\n";
                }
            }

            //Запись объекта в файл
            stream_writer = new StreamWriter(active_file_path);
            stream_writer.WriteLine("ID:" + "\t\t" + new_electrician.get_id());
            stream_writer.WriteLine("Full name:" + "\t\t" + new_electrician.get_FIO());
            stream_writer.WriteLine("Date of birth:" + "\t\t" + new_electrician.get_date_of_birth().Date + "\n");
            stream_writer.WriteLine("Registration:" + "\t\t" + new_electrician.get_registration());
            stream_writer.WriteLine("Passport serial:" + "\t\t" + new_electrician.get_pass_serial());
            stream_writer.WriteLine("Passport number:" + "\t\t" + new_electrician.get_pass_number() + "\n");
            stream_writer.WriteLine("Access level:" + "\t\t" + new_electrician.get_access_level());
            stream_writer.WriteLine("Worker experience:" + "\t\t" + new_electrician.get_worker_exp());
            stream_writer.WriteLine("Worker salary:" + "\t\t" + new_electrician.get_salary());
            stream_writer.WriteLine("Charge:" + "\t\t" + new_electrician.get_charge());
            stream_writer.WriteLine("Specialization:" + "\t\t" + new_electrician.get_specialization());
            stream_writer.WriteLine("Tool_kit:" + "\t\t" + tool_kit);
            stream_writer.Close();

            return "worker added.";
        }

        //Полиморфный метод добавления сотрудника (добавление бухгалтера)
        public string add_worker(Accountant.Accountant new_accountant)
        {
            if (!File.Exists(workers_list_file_path))
            {
                return "Error: there is no existing file: workers_list\n";
            }

            active_file_path = "";

            if (File.ReadAllText(workers_list_file_path).Contains(new_accountant.get_id()) || File.ReadAllText(workers_list_file_path).Contains(new_accountant.get_FIO()))
            {
                return "Error: trying to add an existing worker";
            }

            active_file_path = accountants_file_path + "\\" + new_accountant.get_id() + ".txt";     //Сборка директории для будущего файла

            stream_writer = new StreamWriter(workers_list_file_path, true);     //Второй аргумент указывает на отсутствие перезаписи файла
            stream_writer.WriteLine("ID: " + new_accountant.get_id() + String.Concat(Enumerable.Repeat(" ", (7 - new_accountant.get_id().Length))) + "\t\t" + "FullName: " + new_accountant.get_FIO() + String.Concat(Enumerable.Repeat(" ", (38 - new_accountant.get_FIO().Length))) + "\t\t" + "Vocation: Accountant");
            stream_writer.Close();

            //Запись объекта в файл
            stream_writer = new StreamWriter(active_file_path);
            stream_writer.WriteLine("ID:" + "\t\t" + new_accountant.get_id());
            stream_writer.WriteLine("Full name:" + "\t\t" + new_accountant.get_FIO());
            stream_writer.WriteLine("Date of birth:" + "\t\t" + new_accountant.get_date_of_birth().Date + "\n");
            stream_writer.WriteLine("Registration:" + "\t\t" + new_accountant.get_registration());
            stream_writer.WriteLine("Passport serial:" + "\t\t" + new_accountant.get_pass_serial());
            stream_writer.WriteLine("Passport number:" + "\t\t" + new_accountant.get_pass_number() + "\n");
            stream_writer.WriteLine("Worker experience:" + "\t\t" + new_accountant.get_worker_exp());
            stream_writer.WriteLine("Worker salary:" + "\t\t" + new_accountant.get_salary());
            stream_writer.WriteLine("Charge:" + "\t\t" + new_accountant.get_charge());
            stream_writer.WriteLine("Accounting date:" + "\t\t" + new_accountant.get_accounting_date().Date);
            stream_writer.WriteLine("Area of activity:" + "\t\t" + new_accountant.get_area_of_activity());

            stream_writer.Close();

            return "worker added.";
        }

        //Метод поиска пути к карточке сотрудника по ID
        public string find_worker_path(string worker_id)
        {
            // Путь к каталогам профессий + ID сотрудника + расширение
            if (Directory.GetFiles("D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Accountants", worker_id + ".txt").Length != 0)
            {
                return "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Accountants\\" + worker_id + ".txt";
            }
            else if (Directory.GetFiles("D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Developers", worker_id + ".txt").Length != 0)
            {
                return "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Developers\\" + worker_id + ".txt";
            }
            else if (Directory.GetFiles("D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Electricians", worker_id + ".txt").Length != 0)
            {
                return "D:\\Курсовой Проект ООП\\kursovaya\\WorkersData\\Electricians\\" + worker_id + ".txt";
            }
            return "";
        }

        //Метод поиска карточки сотрудника по ID
        public string find_worker(string worker_id)
        {
            if (find_worker_path(worker_id) == "")
                return "Error: no such worker";
            
            StreamReader strm = new StreamReader(find_worker_path(worker_id));
            output_str = "";
            output_str = strm.ReadToEnd();
            strm.Close();
            return output_str;
        }

        //Метод удаления сотрудника по ID
        public string delete_worker(string worker_id)
        {
            string path_to_deleting_file = find_worker_path(worker_id);
            if (!File.Exists(path_to_deleting_file))
                return "Error: no such worker";

            //Перезапись списка сотрудников с целью удаления сотрудника из списка
            List<string> buffer = new List<string>();
            foreach (string line in File.ReadAllLines(workers_list_file_path))
            {
                if (!line.Contains(worker_id))
                    buffer.Add(line);
            }
            
            stream_writer = new StreamWriter(workers_list_file_path, false);
            foreach (string line in buffer)
               stream_writer.WriteLine(line);
            stream_writer.Close();

            //Удаление карточки
            if (File.Exists(path_to_deleting_file))
                File.Delete(path_to_deleting_file);
            else
                return "Error: there is no worker with specified id";

            return "worker deleted.";
        }



    }
}