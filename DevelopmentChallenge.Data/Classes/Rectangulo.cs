using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : IFormaGeometrica
    {
        private decimal Lado1 { get; set; }
        private decimal Lado2 { get; set; }
        public Rectangulo(decimal lado1, decimal lado2)
        {
            Lado1 = lado1;
            Lado2 = lado2;
        }

        public decimal CalcularArea()
        {
            return Lado1 * Lado2;
        }

        public decimal CalcularPerimetro()
        {
            return 2 * (Lado1 + Lado2);
        }
    }
}
