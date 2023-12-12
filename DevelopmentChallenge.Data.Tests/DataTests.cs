using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Services;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormasGeometricasService.Imprimir(new List<IFormaGeometrica>(), Enums.IdiomasEnum.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormasGeometricasService.Imprimir(new List<IFormaGeometrica>(), Enums.IdiomasEnum.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = FormasGeometricasService.Imprimir(cuadrados, Enums.IdiomasEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormasGeometricasService.Imprimir(cuadrados, Enums.IdiomasEnum.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormasGeometricasService.Imprimir(formas, Enums.IdiomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new Rectangulo(2,3),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormasGeometricasService.Imprimir(formas, Enums.IdiomasEnum.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Rectangulo | Area 6 | Perimetro 10 <br/>TOTAL:<br/>8 formas Perimetro 107,66 Area 97,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormasGeometricasService.Imprimir(formas, Enums.IdiomasEnum.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Piazze | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposIngles()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Trapecio(4,4,2,2,4)
            };

            var resumen = FormasGeometricasService.Imprimir(formas, Enums.IdiomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>1 Circle | Area 7,07 | Perimeter 9,42 <br/>1 Trapeze | Area 16 | Perimeter 12 <br/>TOTAL:<br/>3 shapes Perimeter 41,42 Area 48,07",
                resumen);
        }

        [TestCase]
        public void TestReporteTextoServiceImprimirItaliano()
        {
            var reporteTexto = new ReporteTextoService(Enums.IdiomasEnum.Italiano);

            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = reporteTexto.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Piazze | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTALE:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }


        [TestCase]
        public void TestReporteTextoServiceImprimirIngles()
        {
            var reporteTexto = new ReporteTextoService(Enums.IdiomasEnum.Ingles);

            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = reporteTexto.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }


        [TestCase]
        public void TestReporteTextoServiceListaVaciaIngles()
        {
            var reporteTexto = new ReporteTextoService(Enums.IdiomasEnum.Ingles);

            var resumen = reporteTexto.GetListaVacia();

            Assert.AreEqual(
                "<h1>Empty list of shapes!</h1>",
                resumen);
        }
    }
}
