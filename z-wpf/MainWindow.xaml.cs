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
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using wuxc = Windows.UI.Xaml.Controls;
using wux = Windows.UI.Xaml;
using System.IO;
using System.Windows.Markup;
using System.Collections.ObjectModel;

namespace z_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public static ObservableCollection<Meeting> mtg;
		public wuxc.Frame navFrame;
		public static wuxc.NavigationView sketchAsfOml;

		public MainWindow()
		{
			mtg = Utils.readMtgs();
			navFrame = new wuxc.Frame();
			InitializeComponent();
		}

		private void MyNavView_ChildChanged(object sender, EventArgs e)
		{
			if (MyNavView.Child is wuxc.NavigationView navView)
			{
				navView.MenuItems.Add(nvItem("Home", "Launcher", "\xE80F"));
				navView.MenuItems.Add(nvItem("Add", "Add Meetings", "\xE948"));
				navView.MenuItems.Add(nvItem("About", "About", "\xE946"));
				navView.IsBackButtonVisible = wuxc.NavigationViewBackButtonVisible.Collapsed;
				navView.IsSettingsVisible = false;
				navView.CompactModeThresholdWidth = 300;
				navView.ExpandedModeThresholdWidth = 5120;
				navView.IsPaneOpen = false;
				navView.SelectedItem = navView.MenuItems.First();
				navView.Content = navFrame;
				navView.SelectionChanged += navView_SelectedItem;
				navView.HeaderTemplate = thisIsAFuckingDisasterOhMyGod();
				navView.Header = "Welcome Back";
				navFrame.Content = new HomePage();
				sketchAsfOml = navView;
			}
		}

		private static wuxc.NavigationViewItem nvItem(string name, string content, string iconCode)
		{
			wuxc.NavigationViewItem nvi = new wuxc.NavigationViewItem();
			nvi.Name = name;
			nvi.Content = content;
			wuxc.FontIcon fi = new wuxc.FontIcon();
			fi.FontFamily = new wux.Media.FontFamily("Segoe MDL2 Assets");
			fi.Glyph = iconCode;
			nvi.Icon = fi;
			return nvi;
		}

		private void navView_SelectedItem(wuxc.NavigationView sender, wuxc.NavigationViewSelectionChangedEventArgs e)
		{
			if (e.SelectedItem is wuxc.NavigationViewItem item)
			{
				switch ((string) item.Content)
				{
					case "Launcher":
						(sketchAsfOml.Content as wuxc.Frame).Content  = new HomePage();
						break;
					case "Add Meetings":
						(sketchAsfOml.Content as wuxc.Frame).Content = new AddPage();
						break;
					case "About":
						(sketchAsfOml.Content as wuxc.Frame).Content = new InfoPage();
						break;
					default:
						break;
				}

				setHeader((string) item.Content);
			}
		}

		public void setHeader(string s)
		{
			if (MyNavView.Child is wuxc.NavigationView navView)
			{
				navView.Header = s;
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Utils.writeMtgs(mtg);
		}

		private wux.DataTemplate thisIsAFuckingDisasterOhMyGod()
		{
			string xaml = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
	<Grid Margin=""24,10,0,0"">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width=""Auto""/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBlock  FontSize=""28""
                                FontWeight=""Bold""
                                VerticalAlignment=""Center""
                                Text=""{Binding}""/>

                </Grid>
</DataTemplate>";

			object root = wux.Markup.XamlReader.Load(xaml) as wux.DataTemplate;
			Windows.UI.Xaml.DataTemplate temp = root as Windows.UI.Xaml.DataTemplate;

			return temp;
		}

	}
}
