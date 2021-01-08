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

using System.Windows.Threading; // нужно для таймера

namespace Animate
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		Ellipse O; // объект - мяч, объявляем вне метода cmRun
		double x, y; // координаты меча
		double R = 25; // радиус меча

		private void cmRun(object sender, RoutedEventArgs e)
		{
			O = new Ellipse(); // создаем объект
			O.Width = 2 * R; // задаем размеры
			O.Height = 2 * R;
			O.Fill = Brushes.Yellow; // цвет
			O.Stroke = Brushes.Red;
			O.StrokeThickness = 5;
			x = 0; // начальная координата - слева
			y = g.Height / 2.0 - R; // начальная координата - по центру
			O.Margin = new Thickness(x, y, 0, 0); 
			g.Children.Add(O);

			Timer = new DispatcherTimer(); // создаем объект таймер
			Timer.Tick += new EventHandler(onTick); // связываем функйцию, котора будет выполняться по таймеру
			Timer.Interval = new TimeSpan(0, 0, 0, 0, 10); // устанавливаем интервал таймера
			Timer.Start(); // запускаем таймер
		}

		DispatcherTimer Timer; // объект таймер

		double dx = 2; // смещение мяча

		void onTick(object sender, EventArgs e) // этот метод будет запускаться по таймеру
		{
			if ((x > g.Width - 2 * R) || (x < 0)) // проверяем не вышли ли за границы
			{
				dx = -dx; // если вышли за границы, то меняем направление движения
			}

			x += dx; // меняем положение мяча
			O.Margin = new Thickness(x, y, 0, 0); // меняем координаты объекта
		}

	}
}
