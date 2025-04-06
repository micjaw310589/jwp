using System.Windows;
using System.Windows.Controls;

namespace Geometria
{
    public interface IWyswietl
    {
        public string PobierzIdentyfikator();
    }

    public static class ListBoxExtension
    {
        public static void Dodaj(this ListBox l, IWyswietl obj)
        {
            l.Items.Add(new ListBoxItem().Content = $"{obj.PobierzIdentyfikator()}");
        }
    }

    public abstract class Bryla : IWyswietl
    {
        public abstract string Nazwa { get; }
        public double Gestosc { get; set; }
        public decimal CenaZaKg { get; set; }

        //public abstract double ObliczObjetosc();
        public abstract double Objetosc { get; }

        //public double ObliczMase()
        //{
        //    return ObliczObjetosc() * Gestosc;
        //}
        public double Masa
        {
            get => Objetosc * Gestosc;
        }

        //public decimal ObliczCene()
        //{
        //    return Convert.ToDecimal(ObliczMase()) * CenaZaKg;
        //}

        public decimal Cena
        {
            get => Convert.ToDecimal(Masa) * CenaZaKg;
        }

        public virtual string PobierzIdentyfikator()
        {
            return $"{this.Nazwa}";
        }

        public Bryla(double g, decimal cena)
        {
            Gestosc = g;
            CenaZaKg = cena;
        }

        public override string ToString()
        {
            return $"{this.Nazwa}\nGêstoœæ: {this.Gestosc:F2}\nCena/kg: {this.CenaZaKg:F2}\nObjêtoœæ: {this.Objetosc:F2}\nMasa: {this.Masa:F2}\nCena: {this.Cena:F2}";
        }
    }

    public class Kula : Bryla
    {
        public override string Nazwa { get; } = "";
        public double Promien { get; set; }

        //public override double ObliczObjetosc()
        //{
        //    return 4.0 / 3.0 * Math.PI * Math.Pow(this.Promien, 3);
        //}

        public override double Objetosc => 4.0 / 3.0 * Math.PI * Math.Pow(this.Promien, 3);

        public override string PobierzIdentyfikator()
        {
            return base.PobierzIdentyfikator() + $" r = {this.Promien:F2}";
        }

        public Kula(string nazwa, double promien, double gestosc, decimal cena) : base(gestosc, cena)
        {
            Nazwa = nazwa;
            Promien = promien;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPromieñ: {this.Promien:F2}";
        }
    }

    public class Stozek : Bryla
    {
        public override string Nazwa { get; } = "";
        public double Promien { get; set; }
        public double Wysokosc { get; set; }

        //public override double ObliczObjetosc()
        //{
        //    return Math.Pow(this.Promien, 2) * Math.PI / 3;
        //}
        public override double Objetosc => Math.Pow(this.Promien, 2) * Math.PI / 3;

        public override string PobierzIdentyfikator()
        {
            return base.PobierzIdentyfikator() + $" r = {this.Promien:F2} h = {this.Wysokosc:F2}";
        }

        public Stozek(string nazwa, double promien, double wysokosc, double gestosc, decimal cena) : base(gestosc, cena)
        {
            Nazwa = nazwa;
            Promien = promien;
            Wysokosc = wysokosc;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPromieñ: {this.Promien:F2}\nWysokoœæ: {this.Wysokosc:F2}";
        }

    }

    public class Student : IWyswietl
    {
        public string Imie { get; set; } = "";
        public string Nazwisko { get; set; } = "";

        public string PobierzIdentyfikator()
        {
            return $"{this.Imie} {this.Nazwisko}";
        }
    }
}
