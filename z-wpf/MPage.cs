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
using Windows.Devices.Spi;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;

namespace z_wpf
{
	class MPage : wuxc.Page
	{

		public static Meeting m;

		public MPage()
		{
			wuxc.Grid g = new wuxc.Grid();
			g.Margin = new wux.Thickness(32);
			
			wuxc.StackPanel sp1 = new wuxc.StackPanel();
			sp1.Margin = new wux.Thickness { Left = 0,Top=10,Bottom=0,Right=0 };
			sp1.SetValue(wuxc.Grid.RowProperty, 0);
			sp1.Orientation = wuxc.Orientation.Horizontal;
			sp1.Children.Add(new wuxc.TextBlock { Text = "Meeting Code:", FontSize = 24, FontWeight = Windows.UI.Text.FontWeights.Medium });
			sp1.Children.Add(new wuxc.TextBlock { Text = m.code, FontSize = 24, FontWeight = Windows.UI.Text.FontWeights.Medium, Margin = new wux.Thickness { Left = 20 } });

			wuxc.StackPanel sp2 = new wuxc.StackPanel();
			sp2.Margin = new wux.Thickness { Left = 0, Top = 10, Bottom = 0, Right = 0 };
			sp2.SetValue(wuxc.Grid.RowProperty, 1);
			sp2.Orientation = wuxc.Orientation.Horizontal;
			sp2.Children.Add(new wuxc.TextBlock { Text = "Password:", FontSize = 24, FontWeight = Windows.UI.Text.FontWeights.Medium });
			sp2.Children.Add(new wuxc.TextBlock { Text = m.pwd, FontSize = 24, FontWeight = Windows.UI.Text.FontWeights.Medium, Margin = new wux.Thickness { Left = 20 } });

			var tbd = new wuxc.TextBlock {Text = m.desc, FontSize = 16, Width = 512, HorizontalAlignment = wux.HorizontalAlignment.Left,
											TextWrapping = wux.TextWrapping.WrapWholeWords, TextTrimming = wux.TextTrimming.CharacterEllipsis,
											Margin = new wux.Thickness {Top=20, Bottom=10} };
			tbd.SetValue(wuxc.Grid.RowProperty, 2);

			wuxc.StackPanel sp3 = new wuxc.StackPanel();
			sp3.SetValue(wuxc.Grid.RowProperty, 3);
			sp3.Orientation = wuxc.Orientation.Horizontal;
			var jm = new wuxc.Button { Content = "Join Meeting", CornerRadius = new wux.CornerRadius(4)};
			jm.Click += Jm_Click;
			sp3.Children.Add(jm);
			var cl = (new wuxc.Button { Content = "Copy Link", CornerRadius = new wux.CornerRadius(4), Margin = new wux.Thickness {Left=24}});
			cl.Click += Cl_Click;
			sp3.Children.Add(cl);
			var em = new wuxc.Button { Content = "Edit Entry", CornerRadius = new wux.CornerRadius(4), Margin = new wux.Thickness { Left = 24 } };
			var emf = new Flyout();
			var sp4 = new wuxc.StackPanel();
			sp4.Children.Add(new wuxc.TextBlock {Text = "Not Implemented Yet Sorry :/", HorizontalAlignment = wux.HorizontalAlignment.Center, VerticalAlignment = wux.VerticalAlignment.Center });
			emf.Content = sp4;
			em.Flyout = emf;
			sp3.Children.Add(em);
			var de = (new wuxc.Button { Content = "Delete Entry", CornerRadius = new wux.CornerRadius(4), Margin = new wux.Thickness { Left = 24 } });
			de.Click += De_Click;
			sp3.Children.Add(de);

			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(42) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(40) });
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(0, wux.GridUnitType.Auto)});
			g.RowDefinitions.Add(new wuxc.RowDefinition { Height = new wux.GridLength(72) });

			g.Children.Add(sp1);
			g.Children.Add(sp2);
			g.Children.Add(tbd);
			g.Children.Add(sp3);

			Content = g;
		}

		private void De_Click(object sender, wux.RoutedEventArgs e)
		{
			Meeting[] arr = MainWindow.mtg.ToArray<Meeting>();
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].Equals(m))
				{
					MainWindow.mtg.RemoveAt(i);
					break;
				}
			}
			MainWindow.sketchAsfOml.SelectedItem = MainWindow.sketchAsfOml.MenuItems.First();
			MainWindow.sketchAsfOml.Header = "Launcher";
			wuxc.Frame huh = MainWindow.sketchAsfOml.Content as wuxc.Frame;
		}

		private void Cl_Click(object sender, wux.RoutedEventArgs e)
		{
			DataPackage dp = new DataPackage();
			dp.RequestedOperation = DataPackageOperation.Copy;
			dp.SetText(m.url);
			Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dp);
		}

		private void Jm_Click(object sender, wux.RoutedEventArgs e)
		{
			Utils.OpenBrowser(m.url);
		}

		public static void setParams(string n, string d, string c, string p)
		{
			m = new Meeting(n, d, c, p);
		}


	}
}
