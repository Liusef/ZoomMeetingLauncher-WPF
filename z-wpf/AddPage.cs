using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using wuxc = Windows.UI.Xaml.Controls;
using wux = Windows.UI.Xaml;
using System.Windows;
using System.IO;

namespace z_wpf
{
	class AddPage : wuxc.Page
	{
		public AddPage()
		{
			wuxc.Grid g = new wuxc.Grid();
			g.Margin = new wux.Thickness(32);
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });

			g.ColumnDefinitions.Add(new wuxc.ColumnDefinition { Width = new wux.GridLength(400) });

			wuxc.TextBox tb1 = new wuxc.TextBox { Header = "Enter the Meeting name", PlaceholderText = "Name", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			wuxc.TextBox tb2 = new wuxc.TextBox { Header = "Enter a Meeting Description (Optional)", PlaceholderText = "Desc.", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			wuxc.TextBox tb3 = new wuxc.TextBox { Header = "Enter the Meeting Code", PlaceholderText = "Code", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			wuxc.TextBox tb4 = new wuxc.TextBox { Header = "Enter the Meeting Password (Optional)", PlaceholderText = "Password", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			wuxc.Button b = new wuxc.Button {Content="Add Meeting", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4)};
			b.Click += B_Click;
		}

		private void B_Click(object sender, wux.RoutedEventArgs e)
		{
			testAddMeetings();
		}

		private void testAddMeetings()
		{
			MainWindow.mtg.Add(new Meeting("test", "test", "test", "test"));
		}
	}
}
