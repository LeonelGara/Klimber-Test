using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {
        public decimal Lado1 { get; set; }
        public decimal Lado2 { get; set; }
        public decimal Lado3 { get; set; }
        public decimal Lado4 { get; set; }
        public decimal Altura { get; set; }
        public Trapecio(decimal lado1, decimal lado2, decimal lado3, decimal lado4, decimal altura)
        {
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
            Lado4 = lado4;
            Altura = altura;
        }

        public decimal CalcularArea()
        {
            return 0.5m * (Lado1 + Lado2) * Altura;
        }

        public decimal CalcularPerimetro()
        {
            return Lado1 + Lado2 + Lado3 + Lado4;
        }
    }
}
