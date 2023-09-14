using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace ChronosApp
{
	public partial class MainPage : ContentPage
	{
		public Timer Temporizador;
		public int LastTime = 0;

		MainViewModel main_view_model = null;

		public MainPage()
		{
			Temporizador = new Timer();
			Temporizador.Interval = 1000;
			Temporizador.AutoReset = true;
			Temporizador.Elapsed += Temporizador_Elapsed;

			main_view_model = new MainViewModel();
			this.BindingContext = main_view_model;

			InitializeComponent();
		}

		private void Temporizador_Elapsed(object sender, ElapsedEventArgs e)
		{
			LastTime += 1;

			int Hours = LastTime / 3600;
			int Minutes = (LastTime % 3600) / 60;
			int Seconds = ((LastTime % 3600) % 60);

			main_view_model.TimeString = Hours.ToString().PadLeft(2, '0') + " : " + Minutes.ToString().PadLeft(2, '0') + " : " + LastTime.ToString().PadLeft(2, '0');
		}
		private void Lap_Clicked(object sender, EventArgs e)
		{
			var collect = main_view_model.ListOfItems;
			collect.Add(main_view_model.TimeString);

			main_view_model.ListOfItems = collect;
		}
		private void Reset_Clicked(object sender, EventArgs e)
		{
			LastTime = 0;
			main_view_model.TimeString = "00 : 00 : 00";
			main_view_model.ListOfItems = new ObservableCollection<string>();
		}

		private void Start_Clicked(object sender, EventArgs e)
		{
			main_view_model.IsNotRunning = false;
			main_view_model.IsRunning = true;
			Temporizador.Start();
		}

		private void Stop_Clicked(object sender, EventArgs e)
		{
			Temporizador.Stop();
			main_view_model.IsNotRunning = true;
			main_view_model.IsRunning = false;
		}
	}
}
