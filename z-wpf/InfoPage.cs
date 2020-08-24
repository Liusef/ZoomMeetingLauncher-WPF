using wuxc = Windows.UI.Xaml.Controls;
using wux = Windows.UI.Xaml;

namespace z_wpf
{
	class InfoPage : wuxc.Page
	{

		public InfoPage()
		{
			var a = new wuxc.StackPanel();
			a.Children.Add(new wuxc.TextBlock {Text = "Hi I basically don't exist oops", Padding = new wux.Thickness(32) });
			Content = a;
		}

	}
}
