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
	class HomePage : wuxc.Page
	{
		public HomePage()
		{
			//wuxc.Grid g = new wuxc.Grid();
			//g.Margin = new wux.Thickness {Left=32,Top=16,Right=0,Bottom=16};
			wuxc.GridView gv = new wuxc.GridView();
			gv.ItemsSource = MainWindow.mtg;
			gv.IsItemClickEnabled = true;
			gv.CanDragItems = true;
			gv.AllowDrop = true;
			gv.CanReorderItems = true;
			gv.HorizontalAlignment = wux.HorizontalAlignment.Center;
			var gvMarginStyle = new wux.Style { TargetType=typeof(wux.FrameworkElement)};
			gvMarginStyle.Setters.Add(new wux.Setter { Property=MarginProperty, Value = new wux.Thickness { Left = 12, Top = 0, Right = 20, Bottom = 20 } });
			gv.ItemContainerStyle = gvMarginStyle;
			gv.ItemTemplate = wellShitHereWeGoAgainWithThisFlamingPileOfGarbageBecauseXAMLIslandsWontActuallyLetMeJustFuckingUseXAMLLikeWHATTHEFUCK();
			gv.SelectionMode = wuxc.ListViewSelectionMode.None;
			gv.ItemClick += Gv_ItemClick;
			Content = gv;

		}

		private void Gv_ItemClick(object sender, wuxc.ItemClickEventArgs e)
		{
			MainWindow.sketchAsfOml.SelectedItem = null;
			Meeting temp = e.ClickedItem as Meeting;
			MPage.setParams(temp.name, temp.desc, temp.code, temp.pwd);
			(MainWindow.sketchAsfOml.Content as wuxc.Frame).Content = new MPage();
		}

		private wux.DataTemplate wellShitHereWeGoAgainWithThisFlamingPileOfGarbageBecauseXAMLIslandsWontActuallyLetMeJustFuckingUseXAMLLikeWHATTHEFUCK()
		{
			string xaml = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" >
	<Grid Height=""150"">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width =""275""/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height=""Auto""/>
            <RowDefinition Height=""Auto""/>
        </Grid.RowDefinitions>
		<TextBlock Margin=""8"" Text=""{Binding name}""
					TextWrapping=""WrapWholeWords""
                    TextTrimming=""CharacterEllipsis""
					FontWeight=""Bold"" FontSize=""24""/>
		<TextBlock Margin=""8"" Text=""{Binding desc}"" 
					Grid.Row=""1"" 
					TextWrapping=""WrapWholeWords""
                    TextTrimming=""CharacterEllipsis""/>  
    </Grid>
</DataTemplate>";

			object root = wux.Markup.XamlReader.Load(xaml) as wux.DataTemplate;
			Windows.UI.Xaml.DataTemplate temp = root as Windows.UI.Xaml.DataTemplate;
			
			return temp;
		}
	}
}
