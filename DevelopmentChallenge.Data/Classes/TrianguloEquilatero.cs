using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private decimal Lado { get; set; }

        public TrianguloEquilatero(decimal lado)
        {
            Lado = lado;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
