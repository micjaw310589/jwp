
namespace lab6_classes
{
    public static class Szukaj
    {
        public static (double?, double?, double?) ZnajdzMinimumFunkcji2D(double minX, double maxX, double minY, double maxY, long liczba_iteracji, Func<double, double, double> fun)
        {
            if (liczba_iteracji <= 0)
                throw new ArgumentException("liczba iteracji musi byæ wiêksza od 0");

            double? bestX = null;
            double? bestY = null;
            double? bestWartosc = null;
            double x = 0.0;
            double y = 0.0;

            Random rng = new Random();

            for (long i = 0; i < liczba_iteracji; i++)
            {
                x = rng.NextDouble() * (maxX - minX) + minX;
                y = rng.NextDouble() * (maxY - minY) + minY;

                if (fun(x, y) < bestWartosc || bestWartosc == null)
                {
                    bestX = x;
                    bestY = y;
                    bestWartosc = fun(x, y);
                }
            }

            return (bestX, bestY, bestWartosc);
        }
    }

    public class Towar : IComparable<Towar>
    {
        public enum Kategoria
        {
            Uszkodzony,
            Uzywany,
            Nowy
        }

        public string Nazwa { get; set; } = "";
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public Kategoria Stan { get; set; }


        public override string ToString()
        {
            return $"{Nazwa} - {Stan}, cena: {Cena}, iloœæ: {Ilosc}";
        }

        public int CompareTo(Towar other)
        {
            if (other == null) return 1;

            return this.Ilosc.CompareTo(other.Ilosc);
        }
    }
}
