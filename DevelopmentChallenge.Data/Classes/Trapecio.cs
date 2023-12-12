using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {
        public decimal BaseMayor { get; set; }
        public decimal BaseMenor { get; set; }
        public decimal Pierna1 { get; set; }
        public decimal Pierna2 { get; set; }
        public decimal Altura { get; set; }
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal pierna1, decimal pierna2, decimal altura)
        {
            BaseMayor = baseMayor;
            BaseMenor = baseMenor;
            Pierna1 = pierna1;
            Pierna2 = pierna2;
            Altura = altura;
        }

        public decimal CalcularArea()
        {
            return 0.5m * (BaseMayor + BaseMenor) * Altura;
        }

        public decimal CalcularPerimetro()
        {
            return BaseMayor + BaseMenor + Pierna1 + Pierna2;
        }
    }
}
