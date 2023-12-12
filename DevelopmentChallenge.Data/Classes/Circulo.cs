using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private decimal Lado { get; set; }

        public Circulo(decimal lado)
        {
            Lado = lado;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }
    }
}
