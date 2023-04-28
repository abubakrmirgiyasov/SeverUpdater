using ServerUpdater.Domain.Common;
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

namespace ServerUpdater.Demo;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void OnWindowLoad(object sender, RoutedEventArgs e)
	{
		SetThemeResources(Constants.LIGHT_THEME_PATH);
	}

	private void OnThemeToggle(object sender, RoutedEventArgs e)
	{
		ThemeToggler.Tag = ThemeToggler.Tag.ToString() == "light" ? "dark" : "light";
		var style = ThemeToggler.Tag.ToString() == "light" ? Constants.DARK_THEME_PATH : Constants.LIGHT_THEME_PATH;

		SetThemeResources(style);
	}

	private void OnWindowClose(object sender, RoutedEventArgs e)
	{

	}

	private void SetThemeResources(string path)
	{
		var uri = new Uri(path, UriKind.Relative);
		var resourceDict = (ResourceDictionary)Application.LoadComponent(uri);

		Application.Current.Resources.Clear();
		Application.Current.Resources.MergedDictionaries.Add(resourceDict);
	}
}
