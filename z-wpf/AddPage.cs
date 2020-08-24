using System;
using System.Linq;
using wuxc = Windows.UI.Xaml.Controls;
using wux = Windows.UI.Xaml;

namespace z_wpf
{
	class AddPage : wuxc.Page
	{
		wuxc.TextBox tb1;
		wuxc.TextBox tb2;
		wuxc.TextBox tb3;
		wuxc.TextBox tb4;

		public AddPage()
		{
			wuxc.Grid g = new wuxc.Grid();
			g.Margin = new wux.Thickness(32, 0, 0, 0);
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto) });

			g.ColumnDefinitions.Add(new wuxc.ColumnDefinition { Width = new wux.GridLength(400) });

			tb1 = new wuxc.TextBox { Header = "Enter the Meeting name", PlaceholderText = "Name", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			tb1.SetValue(wuxc.Grid.RowProperty, 0);
			tb2 = new wuxc.TextBox { Header = "Enter a Meeting Description (Optional)", PlaceholderText = "Desc.", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			tb2.SetValue(wuxc.Grid.RowProperty, 1);
			tb3 = new wuxc.TextBox { Header = "Enter the Meeting Code", PlaceholderText = "Code", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			tb3.SetValue(wuxc.Grid.RowProperty, 2);
			tb4 = new wuxc.TextBox { Header = "Enter the Meeting Password (Optional)", PlaceholderText = "Password", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4) };
			tb4.SetValue(wuxc.Grid.RowProperty, 3);
			wuxc.Button b = new wuxc.Button {Content="Add Meeting", Margin = new wux.Thickness(20), CornerRadius = new wux.CornerRadius(4)};
			b.SetValue(wuxc.Grid.RowProperty, 4);
			b.Click += B_Click;

			g.Children.Add(tb1);
			g.Children.Add(tb2);
			g.Children.Add(tb3);
			g.Children.Add(tb4);
			g.Children.Add(b);

			Content = g;

		}

		private void B_Click(object sender, wux.RoutedEventArgs e)
		{
			if (!String.IsNullOrWhiteSpace(tb1.Text) && !String.IsNullOrWhiteSpace(tb3.Text))
			{
				MainWindow.mtg.Add(new Meeting(tb1.Text, tb2.Text, tb3.Text, tb4.Text));
				MainWindow.sketchAsfOml.SelectedItem = MainWindow.sketchAsfOml.MenuItems.First();
				MainWindow.sketchAsfOml.Header = "Launcher";
				wuxc.Frame huh = MainWindow.sketchAsfOml.Content as wuxc.Frame;
				huh.Content = new HomePage();
			}
		}

		private void testAddMeetings()
		{
			MainWindow.mtg.Add(new Meeting("test", "test", "test", "test"));
		}
	}
}
