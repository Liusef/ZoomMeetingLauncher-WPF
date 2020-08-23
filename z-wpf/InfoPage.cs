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
	class InfoPage : wuxc.Page
	{

		public InfoPage()
		{
			var a = new wuxc.StackPanel();
			a.Children.Add(new TextBlock {Text = "Hi I basically don't exist oops", Padding = new wux.Thickness(32) });
			Content = a;
		}

	}
}
