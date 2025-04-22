
namespace Geometria
{
    public class Stozek
    {
        private double wysokosc;
        private double promien;

        public double Wysokosc {
            get => wysokosc;
            set
            {
                if (value < 0 && onBlad != null)
                {
                    onBlad("H < 0");
                }
                else
                {
                    wysokosc = value;
                }
            }
        }
        public double Promien {
            get => promien;
            set
            {
                if (value < 0 && onBlad != null)
                {
                    onBlad("r < 0");
                }
                else
                {
                    promien = value;
                }
            }
        }

        public event ObslugaBledu onBlad;
    }

    public delegate void ObslugaBledu(string opis);

}
