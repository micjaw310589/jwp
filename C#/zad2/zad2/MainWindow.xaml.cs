using System.Diagnostics.Eventing.Reader;
using System.Runtime.Intrinsics.Arm;
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

namespace zad2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void RysujLinie(int x1, int y1, int x2, int y2, SolidColorBrush kolor)
    {
        Line l = new();
        l.X1 = x1;
        l.Y1 = y1;
        l.X2 = x2;
        l.Y2 = y2;
        l.Stroke = kolor;

        cv.Children.Add(l);
    }

    void Gwiazda(int r, int sr_x, int sr_y, int min_r, SolidColorBrush kolor)
    {
        double alfa;
        int x2,
            y2;

        for (int i = 0; i < 6; i++)
        {
            alfa = 2 * Math.PI / 6 * i;
            x2 = sr_x - Convert.ToInt32(r * Math.Cos(alfa));
            y2 = sr_y + Convert.ToInt32(r * Math.Sin(alfa));

            RysujLinie(sr_x, sr_y, x2, y2, kolor);

            if (r >= min_r)
            {
                Gwiazda(r / 3, x2, y2, min_r, kolor);
            }
        }
    }

    void Zamien(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void WypelnijTablice2D(double lower, double higher, ref double[,] arr2D)
    {
        Random rng = new Random();

        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                arr2D[i, j] = rng.NextDouble() * (higher - lower) + lower;
            }
        }
    }

    void WyswietlListBox(ref ListBox listB, in double[,] arr2D)
    {
        ListBoxItem row;

        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            row = new();
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                row.Content += $"{arr2D[i, j]:###.#}\t";
            }
            row.Content += $"[{SumaWiersza(arr2D, i):###.#}]\t";
            listB.Items.Add(row);
        }

        row = new();
        for (int j = 0; j < arr2D.GetLength(1); j++)
        {
            row.Content += $"[{SumaKolumny(arr2D, j):###.#}]\t";
        }
        listB.Items.Add(row);
    }

    void WyswietlListBox(ref ListBox listB, in int[][] arr2D)
    {
        ListBoxItem row;

        for (int i = 0; i < arr2D.Length; i++)
        {
            row = new();
            for (int j = 0; j < arr2D[i].GetLength(0); j++)
            {
                row.Content += $"{arr2D[i][j]:###.#}\t";
            }
            row.Content += $"[{SumaWiersza(arr2D, i):###.#}]\t";
            listB.Items.Add(row);
        }
    }

    private double SumaWiersza(in double[,] arr2D, in int row)
    {
        if (row <= arr2D.GetLength(0))
        {
            double suma = 0.0;

            for (int i = 0; i < arr2D.GetLength(1); i++)
            {
                suma += arr2D[row, i];
            }

            return suma;
        }
        else
            throw new IndexOutOfRangeException();
    }

    private double SumaWiersza(in int[][] arr2D, in int row)
    {
        if (row <= arr2D.GetLength(0))
        {
            double suma = 0.0;

            for (int i = 0; i < arr2D[row].GetLength(0); i++)
            {
                suma += arr2D[row][i];
            }

            return suma;
        }
        else
            throw new IndexOutOfRangeException();
    }

    private double SumaKolumny(in double[,] arr2D, in int col)
    {
        if (col <= arr2D.GetLength(1))
        {
            double suma = 0.0;

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                suma += arr2D[i, col];
            }

            return suma;
        }
        else
            throw new IndexOutOfRangeException();
    }

    private void btnRysuj_Click(object sender, RoutedEventArgs e)
    {
        cv.Children.Clear();

        try
        {
            int r = Convert.ToInt32(txtR.Text),
                min_r = Convert.ToInt32(txtMin.Text),
                x = Convert.ToInt32(txtX.Text),
                y = Convert.ToInt32(txtY.Text);

            if (r < 0 || min_r <= 0 || x < 0 || y < 0)
            {
                MessageBox.Show("Złe dane wejściowe");
            }
            else
            {
                Gwiazda(
                    Convert.ToInt32(txtR.Text),
                    Convert.ToInt32(txtX.Text),
                    Convert.ToInt32(txtY.Text),
                    Convert.ToInt32(txtMin.Text),
                    Brushes.Blue
                    );
            }
        }
        catch (FormatException)
        {
            MessageBox.Show("Wprowadź liczby!");
        }
    }

    private void btnTest2_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            int A = Convert.ToInt32(txtA.Text),
                B = Convert.ToInt32(txtB.Text);

            Zamien(ref A, ref B);

            MessageBox.Show($"A = {A}\nB = {B}");
        }
        catch (FormatException)
        {
            MessageBox.Show($"Wprowadź liczby!");
        }
    }

    private void btnWyswietl2DArr_Click(object sender, RoutedEventArgs e)
    {
        int SIZE_COL = 3,
            SIZE_ROW = 5;

        double[,] arr2D = new double[SIZE_ROW, SIZE_COL];
        WypelnijTablice2D(0.0, 100.0, ref arr2D);
        WyswietlListBox(ref listTab, arr2D);
    }

    private void btnWyswietlJagged_Click(object sender, RoutedEventArgs e)
    {
        int SIZE_ROW = 3,
            SIZE_COL = 8;

        int[][] arrJagged = new int[SIZE_ROW][];

        for (int i = 0; i < SIZE_ROW; i++)
        {
            int[] row = new int[SIZE_COL - 1];
            for (int j = 2; j < SIZE_COL + 1; j++)
            {
                row[j - 2] = j;
            }
            arrJagged[i] = row;
            SIZE_COL -= 2;
        }

        WyswietlListBox(ref listTab, arrJagged);
    }
}