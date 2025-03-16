using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void DrawLine(int x1, int x2, int y1, int y2, int thickness, Brush color)
        {
            var line = new Line();
            line.Stroke = color;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;
            line.StrokeThickness = thickness;

            canvas.Children.Add(line);
        }
        private void DrawStar(int x, int y, int width, int thicknes, int count, int depth = 0)
        { 
            for (int i = 0; i < count; i++)
            {
                double angle = (2 * Math.PI / count) * i;

                int x1 = x + (int)((width) * Math.Cos(angle));
                int x2 = x - (int)((width) * Math.Cos(angle));

                int y1 = y + (int)((width) * Math.Sin(angle));
                int y2 = y - (int)((width) * Math.Sin(angle));

                DrawLine(x1, x2, y1, y2, thicknes, Brushes.Black);

                if (depth > 0)
                {
                    DrawStar(x1, y1, width / 3, thicknes, count, depth - 1);
                    DrawStar(x2, y2, width / 3, thicknes, count, depth - 1);
                }
            }
        }

        int depth = 0;
        int count = 1;
        int width = 100;

        int centerX = 0;
        int centerY = 0;

        public MainWindow()
        {
            InitializeComponent();

            centerX = System.Convert.ToInt32((canvas.ActualWidth) / 2);
            centerY = System.Convert.ToInt32((canvas.ActualHeight) / 2);

            UpdateCanvas();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            centerX = System.Convert.ToInt32((canvas.ActualWidth) / 2);
            centerY = System.Convert.ToInt32((canvas.ActualHeight) / 2);

            UpdateCanvas();
        }

        private void UpdateCanvas()
        {
            canvas.Children.Clear();
            centerX = System.Convert.ToInt32((canvas.ActualWidth) / 2);
            centerY = System.Convert.ToInt32((canvas.ActualHeight) / 2);

            DrawStar(centerX, centerY, width * 10, 1, count, depth);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            depth = (int)e.NewValue;
            UpdateCanvas();
        }

        private void Depth(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            count = (int)e.NewValue;
            UpdateCanvas();
        }

        private void Widthset(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            width = (int)e.NewValue;
            UpdateCanvas();
        }
    }
}