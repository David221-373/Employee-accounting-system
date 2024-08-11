using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Worker;

namespace Accountant
{
	public class Accountant : Worker.Worker
    {
		private int charge;						//Иерархический разряд бухгалтера
		private DateTime accounting_date;		//Дата предоставления итогов расчетного периода
		private string area_of_activity;		//Специализация

		//Конструктор по умолчанию
		public Accountant()
		{
			charge = 0;
			accounting_date = new DateTime();
			area_of_activity = string.Empty;
		}

        //Конструктор с параметрами
        public Accountant(int _charge, DateTime _accounting_date, string _area_of_activity)
		{
			charge = _charge;
			accounting_date = _accounting_date;
			area_of_activity = _area_of_activity;
		}
		
		//Геттеры
		public int get_charge()							{ return charge; }
		public DateTime get_accounting_date()			{ return accounting_date; }
		public string get_area_of_activity()			{ return area_of_activity; }

		//Сеттеры
		public void set_charge(int _charge)							{ charge = _charge; }
		public void set_accounting_date(DateTime _accounting_date)	{ accounting_date = _accounting_date; }
		public void set_area_of_activity(string _area_of_activity)	{ area_of_activity = _area_of_activity; }

	}
}
