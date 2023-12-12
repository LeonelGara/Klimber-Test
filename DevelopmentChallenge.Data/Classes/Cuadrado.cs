using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    {
        private decimal Lado { get; set; }
        public Cuadrado(decimal lado)
        {
            Lado = lado;
        }

        public decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 4;
        }
    }
}
