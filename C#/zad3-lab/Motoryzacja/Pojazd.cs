using System.Runtime.CompilerServices;

namespace Motoryzacja
{
    struct RejestrNazw
    {
        public DateTime DataModyfikacji;
        public string Nazwa;

        public override string ToString()
        {
            return $"{this.DataModyfikacji}\t {this.Nazwa}";
        }

        public RejestrNazw(DateTime data, string nazwa)
        {
            this.DataModyfikacji = data;
            this.Nazwa = nazwa;
        }
    }

    public class Pojazd
    {
        private string nazwa = "";
        private byte liczbakol;
        private double predkosc;
        private static int liczbaPojazdow;

        public int Lp { get; private set; }

        private List<RejestrNazw> HistoriaNazw { get; set; } = new List<RejestrNazw>();

        public string Nazwa
        {
            get => this.nazwa;
            set
            {
                HistoriaNazw.Add(new RejestrNazw(DateTime.Now, value));
                this.nazwa = value;
            }
        }

        public byte LiczbaKol
        {
            get { return this.liczbakol; }
            set
            {
                this.liczbakol = value;
            }
        }

        public double Predkosc
        {
            get { return this.predkosc; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Nieprawidłowa prędkość");
                else
                    this.predkosc = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Lp}/{liczbaPojazdow}\t {this.Nazwa}\t V-Max: {this.Predkosc}\t Koła: {this.LiczbaKol}";
        }

        static Pojazd()
        {
            liczbaPojazdow = 0;
        }

        public Pojazd()
        {
            Lp = ++liczbaPojazdow;
        }

        public Pojazd(string nazwa, byte liczbakol, double predkosc) : this()
        {
            try
            {
                this.Nazwa = nazwa;
                this.LiczbaKol = liczbakol;
                this.Predkosc = predkosc;
            }
            catch (ArgumentException)
            {
                this.Predkosc = 0.0;
            }
        }

        public Pojazd(string nazwa, double predkosc) : this(nazwa, 4, predkosc)
        { }

    }

    public class PojazdMechaniczny : Pojazd
    {
        private short moc_silnika;

        public short MocSilnika
        {
            get
            {
                return moc_silnika;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException("Nieprawidłowa wartość mocy");
                else
                    this.moc_silnika = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\t Moc: {this.MocSilnika}";
        }

        public PojazdMechaniczny(string nazwa, byte liczbakol, double predkosc, short moc_silnika) : base(nazwa, liczbakol, predkosc)
        {
            try
            {
                this.MocSilnika = moc_silnika;
            }
            catch (ArgumentException)
            {
                this.MocSilnika = 0;
            }
        }

        public PojazdMechaniczny(string nazwa, double predkosc, short moc_silnika) : base(nazwa, predkosc)
        {
            try
            {
                this.MocSilnika = moc_silnika;
            }
            catch (ArgumentException)
            {
                this.MocSilnika = 0;
            }
        }

    }

    public class Samochod : PojazdMechaniczny
    {
        public string Marka { get; set; } = "";
        public byte LiczbaPasazerow { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\t Marka: {this.Marka}\t L.Pas: {this.LiczbaPasazerow}";
        }

        public Samochod(string nazwa, byte liczbakol, double predkosc, short moc_silnika, string marka, byte liczba_pasazerow) : base(nazwa, liczbakol, predkosc, moc_silnika)
        {
            this.Marka = marka;
            this.LiczbaPasazerow = liczba_pasazerow;
        }

        public Samochod(string nazwa, double predkosc, short moc_silnika, string marka, byte liczba_pasazerow) : base(nazwa, predkosc, moc_silnika)
        {
            this.Marka = marka;
            this.LiczbaPasazerow = liczba_pasazerow;
        }

    }
}
