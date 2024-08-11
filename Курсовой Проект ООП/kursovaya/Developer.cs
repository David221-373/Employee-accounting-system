using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Worker;

namespace Developer
{
	public class Developer : Worker.Worker   // Класс девелопер наследуется от класса worker, который находиться в пространстве имен worker/ белый цвет обозначает пространство имен  а зеленный сам класс 
	{

			private string coding_level;        // Уровень разработчика (junior, middle, senior)   // Объявление переменных класса 
			private string working_type;        // Удаленка или очная работа
			private List<string> skills;		// Набор технологий, которыми обладает разработчик
			private int access_level;			// уровень доступа на предприятии


			// Конструктор по умолчанию (Пустой)
			public Developer()
			{
				coding_level = string.Empty;
				working_type = string.Empty;
				skills = new List<string>();
				access_level = 0;
			}
			
			// Конструктор с параметрами,  // Полиформизм
			public Developer(string _codingLevel, string _working_type, List<string> _skills, int _access_level)
			{
				coding_level = _codingLevel;
				working_type = _working_type;
				skills = new List<string>(_skills);
				access_level = _access_level;
			}
			
			//Геттеры  
			public string get_coding_level()	{ return coding_level; }
			public string get_working_type()	{  return working_type; }
			public int get_access_level()		{ return access_level; }
			public List<string> get_skills()	{  return skills; }

			//Сеттеры
			public void set_coding_level(string _coding_level)	{ coding_level = _coding_level; }
			public void set_working_type(string _working_type)	{ working_type = _working_type; }
			public void set_access_level(int _access_level)		{ access_level = _access_level; }
			public void set_skills(List<string> _skills)		{ skills.AddRange(_skills); }
			public void set_single_skill(string skill)			{ skills.Add(skill);  }
	
	}
}