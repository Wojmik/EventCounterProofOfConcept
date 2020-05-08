using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventCounterProofOfConcept
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Słuchaczek Słuchaczek { get; } = new Słuchaczek();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var zadanko = new Zadanko();
			Task tZadanko;

			tZadanko=zadanko.Działaj();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;

			if(checkBox.IsChecked.HasValue)
				if(checkBox.IsChecked.Value)
					Słuchaczek.WłączNasłuszek();
				else
					Słuchaczek.WyłączNasłuszek();
		}
	}
}