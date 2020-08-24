namespace z_wpf
{
	public class Program
	{
		[System.STAThreadAttribute()]
		public static void Main()
		{
			using (new z_xaml.App())
			{
				z_wpf.App app = new z_wpf.App();
				app.InitializeComponent();
				app.Run();
			}
		}
	}
}
