using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Worker;

namespace Electrician
{
	public class Electrician : Worker.Worker
	{
		private int charge;					//Разряд электрика
		private int access_level;			//Уровень доступа
		private string specialization;		//Специализация электрика
		List<string> tool_kit;

		//Конструктор по умолчанию
		public Electrician()
		{
			charge = 0;
			access_level = 0;
			specialization = string.Empty;
			tool_kit = new List<string>();
		}

		//Конструктор с параметрами
		public Electrician(int _charge, int _access_level, string _specialization, List<string> _tool_kit)
		{
			charge = _charge;
			access_level = _access_level;
			specialization = _specialization;
			tool_kit = new List<string>(_tool_kit);
		}

		//Геттеры
		public int get_charge()					{ return charge; }
		public int get_access_level()			{ return charge; }
		public string get_specialization()		{ return specialization; }
		public List<string> get_tool_kit()		{ return tool_kit; }

		//Сеттеры
		public void set_charge(int _charge)						{ charge = _charge; }
		public void set_access_level(int _access_level)			{ access_level = _access_level; }
		public void set_specialization(string _specialization)	{ specialization = _specialization; }
		public void set_tool_kit(List<string> _tool_kit)		{ tool_kit.AddRange(_tool_kit); }
	
	
	}
}