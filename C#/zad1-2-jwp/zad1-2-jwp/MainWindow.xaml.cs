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

namespace zad1_2_jwp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void drawSingleStep(int step, int w, int h)
    {
        Rectangle rect = new();
        SolidColorBrush brush = new();

        brush.Color = Color.FromArgb(255, 255, 0, 0);
        rect.Fill = brush;
        rect.Width = w;
        rect.Height = h;

        canvas.Children.Add(rect);
        Canvas.SetLeft(rect, (canvas.Width - rect.Width) / 2);
        Canvas.SetTop(rect, canvas.Height - 10 - rect.Height * (step + 1));
    }

    private void btnDraw_Click(object sender, RoutedEventArgs e)
    {
        const int levels = 7,
                  level_w = 300,
                  level_final_w = 50,
                  level_h = 50,
                  w_decrease = (level_w - level_final_w) / (levels - 1);

        int level_w_curr;

        for (int i = 0; i < levels; i++)
        {
            level_w_curr = level_w - w_decrease * i;
            drawSingleStep(i, level_w_curr, level_h);
        }
    }
}