
namespace Generyka
{
    public class Student
    {
        public string Nazwisko { get; set; } = "";
        public byte Ocena { get; set; }

        public override string ToString()
        {
            return $"{this.Nazwisko} - {this.Ocena}";
        }
    }

    public static class Generyczna
    {
        public static T ZnajdzWiekszy<T>(T p1, T p2) where T:IComparable<T>
        {
            if (p1.CompareTo(p2) < 0)
                return p2;

            return p1;
        }
    }

    public class Regal<T>
    {
        public T Polka1 { get; set; } = default;
        public T Polka2 { get; set; } = default;
        public T Polka3 { get; set; } = default;

        public T WolnaPolka
        {
            set
            {
                WstawNaWolnaPolke(value);
            }
        }

        public void WstawNaWolnaPolke(T obj)
        {
            if (EqualityComparer<T>.Default.Equals(Polka1, default))
                Polka1 = obj;
            else if (EqualityComparer<T>.Default.Equals(Polka2, default))
                Polka2 = obj;
            else if (EqualityComparer<T>.Default.Equals(Polka3, default))
                Polka3 = obj;
        }

        public override string ToString()
        {
            return $"Pó³ka 1: {this.Polka1}\nPó³ka 2: {this.Polka2}\nPó³ka 3: {this.Polka3}";
        }
    }
}
