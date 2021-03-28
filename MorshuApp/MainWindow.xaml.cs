using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MorshuApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Counter counter = new Counter();
		public MainWindow()
		{
			DataContext = counter;
			InitializeComponent();
		}
		private void TextBox_GotKeyboardFocus(Object sender, KeyboardFocusChangedEventArgs e)
		{
			TextBox tb = (TextBox)sender;
			tb.Dispatcher.BeginInvoke(new Action(() => tb.SelectAll()));
		}
	}
}
