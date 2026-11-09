//PROBLEMA 1
using static Program;

class Program
{
    static void Main(string[] args)
    {
        Figuras[] figuras = new Figuras[]
        {
            new Rectangulo(5, 3),
            new Cuadrado(4),
            new Triangulo(6, 4)
            };

        foreach (Figuras fig in figuras)
        {
            Console.WriteLine($"Clase: {fig.Nombre()}");
            Console.WriteLine($"Área: {fig.CalcularArea()}");
            Console.WriteLine($"Perímetro: {fig.CalcularPerimetro()}");
        }
    }

    public abstract class Figuras
    {
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        public abstract string Nombre();

    }

    //RECTAGULO
    public class Rectangulo : Figuras
    {
        //DATOS
        private double Bas { set; get; }
        private double Alt { set; get; }
        public Rectangulo(double bR, double aR)
        {
            Bas = bR;
            Alt = aR;
        }

        //AREA
        public override double CalcularArea()
        {
            double ca = Bas * Alt;
            return ca;
        }

        //PERIMETRO
        public override double CalcularPerimetro()
        {
            double cper = 2 * (Bas + Alt);
            return cper;
        }

        public override string Nombre()
        {
            return "Es Rectangulo:";
        }
    }

    //CUADRADO
    public class Cuadrado : Figuras
    {
        //DATOS
        private double Lad { set; get; }
        public Cuadrado(double lado)
        {
            Lad = lado;
        }

        //AREA
        public override double CalcularArea()
        {
            double ca = Lad * Lad;
            return ca;
        }

        //PERIMETRO
        public override double CalcularPerimetro()
        {
            double cper = 4 * Lad;
            return cper;
        }

        public override string Nombre()
        {
            return "Es Cuadrado:";
        }
    }

    //TRIANGULP
    public class Triangulo : Figuras
    {
        //DATOS
        private double Bas { set; get; }
        private double Alt { set; get; }
        public Triangulo(double bT, double aT)
        {
            Bas = bT;
            Alt = aT;
        }

        //AREA
        public override double CalcularArea()
        {
            double ca = 0.5 * Bas * Alt;
            return ca;
        }

        //PERIMETRO
        public override double CalcularPerimetro()
        {
            double cper = 4 * Bas;
            return cper;
        }

        public override string Nombre()
        {
            return "Es Triangulo:";
        }
    }
}