using System.Collections.ObjectModel;

namespace ChronosApp
{
	public class MainViewModel : PropertyToBind
	{
		string _time_string = "00 : 00 : 00";
		public string TimeString
		{
			get { return _time_string; }
			set
			{
				_time_string = value;
				OnPropertyChanged("TimeString");
			}
		}

		bool _is_running = false;
		public bool IsRunning
		{
			get { return _is_running; }
			set
			{
				_is_running = value;
				OnPropertyChanged("IsRunning");
			}
		}

		bool _is_not_running = true;
		public bool IsNotRunning
		{
			get { return _is_not_running; }
			set
			{
				_is_not_running = value;
				OnPropertyChanged("IsNotRunning");
			}
		}

		private ObservableCollection<string> _list_of_items;
		public ObservableCollection<string> ListOfItems
		{
			get { return _list_of_items ?? new ObservableCollection<string>(); }
			set
			{
				if (_list_of_items != value)
				{
					_list_of_items = value;
					OnPropertyChanged("ListOfItems");
				}
			}
		}
	}
}