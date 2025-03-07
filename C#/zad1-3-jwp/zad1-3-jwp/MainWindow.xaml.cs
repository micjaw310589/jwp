using System.Runtime.CompilerServices;
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

namespace zad1_3_jwp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void addCol(ColumnDefinition c)
    {
        twojaStara.ColumnDefinitions.Add(c);
    }

    void addRow(RowDefinition r)
    {
        r = new();
        twojaStara.RowDefinitions.Add(r);
    }

    void drawCheckboard(int r_num, int c_num)
    {
        twojaStara.Children.Clear();
        for (int r = 0; r < r_num; r++)
        {
            for (int c = 0; c < c_num; c++)
            {
                Rectangle rect = new();
                twojaStara.Children.Add(rect);
                rect.SetValue(Grid.ColumnProperty, c);
                rect.SetValue(Grid.RowProperty, r);

                if ((r + c) % 2 == 0)
                    rect.Fill = Brushes.DarkGray;
                else
                    rect.Fill = Brushes.White;
            }
        }
    }

    void setUpGrid(int r_num, int c_num)
    {
        twojaStara.ColumnDefinitions.Clear();
        twojaStara.RowDefinitions.Clear();

        for (int i = 0; i < c_num; i++)
        {
            addCol(new());
        }

        for (int i = 0; i < r_num; i++)
        {
            addRow(new());
        }
    }

    private void btnDraw_Click(object sender, RoutedEventArgs e)
    {

        try
        {
            if (Convert.ToInt32(txtRows.Text) > 0 && Convert.ToInt32(txtCols.Text) > 0)
            {
                int NUM_ROWS = Convert.ToInt32(txtRows.Text),
                    NUM_COLS = Convert.ToInt32(txtCols.Text);

                setUpGrid(NUM_ROWS, NUM_COLS);
                drawCheckboard(NUM_ROWS, NUM_COLS);
            }
            else
                MessageBox.Show("Liczba kolumn/wierszy musi być większa niż 0!");

        }
        catch(FormatException)
        {
            MessageBox.Show("Zły format wprowadzonych danych");
        }
    }
}