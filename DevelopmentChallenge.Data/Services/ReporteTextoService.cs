using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
    public class ReporteTextoService
    {
        public ReporteTextoService(IdiomasEnum idioma)
        {
            _Idioma = idioma;
        }
        private IdiomasEnum _Idioma { get; set; }
        public string GetListaVacia()
        {
            if (_Idioma == IdiomasEnum.Castellano)
                return "<h1>Lista vacía de formas!</h1>";
            else if (_Idioma == IdiomasEnum.Ingles)
                return "<h1>Empty list of shapes!</h1>";
            else if (_Idioma == IdiomasEnum.Italiano)
                return "<h1>Elenco vuoto di forme!</h1>";

            return string.Empty;
        }

        private string GetTitulo()
        {
            if (_Idioma == IdiomasEnum.Castellano)
                return "<h1>Reporte de Formas</h1>";
            else if (_Idioma == IdiomasEnum.Ingles)
                return "<h1>Shapes report</h1>";
            else if (_Idioma == IdiomasEnum.Italiano)
                return "<h1>Rapporto sui moduli</h1>";

            return string.Empty;
        }

        private string GetTotal()
        {
            if (_Idioma == IdiomasEnum.Italiano)
                return "TOTALE:<br/>";

            return "TOTAL:<br/>";
        }

        public string Imprimir(List<IFormaGeometrica> formaGeometrica)
        {
            var cantidadCuadrados = 0;
            var cantidadTriangulos = 0;
            var cantidadCirculos = 0;
            var cantidadRectangulo= 0;
            var cantidadTrapecio= 0;

            var areaCuadrados = 0m;
            var areaCirculos = 0m;
            var areaTriangulos = 0m;
            var areaRectangulo = 0m;
            var areaTrapecio = 0m;

            var perimetroCuadrados = 0m;
            var perimetroCirculos = 0m;
            var perimetroTriangulos = 0m;
            var perimetroRectangulo = 0m;
            var perimetroTrapecio = 0m;

            foreach (var forma in formaGeometrica)
            {
                if (forma is Cuadrado)
                {
                    cantidadCuadrados++;
                    areaCuadrados += forma.CalcularArea();
                    perimetroCuadrados += forma.CalcularPerimetro();
                }
                if (forma is Circulo)
                {
                    cantidadCirculos++;
                    areaCirculos += forma.CalcularArea();
                    perimetroCirculos += forma.CalcularPerimetro();
                }
                if (forma is TrianguloEquilatero)
                {
                    cantidadTriangulos++;
                    areaTriangulos += forma.CalcularArea();
                    perimetroTriangulos += forma.CalcularPerimetro();
                }
                if (forma is Rectangulo)
                {
                    cantidadRectangulo++;
                    areaRectangulo += forma.CalcularArea();
                    perimetroRectangulo += forma.CalcularPerimetro();
                }
                if (forma is Trapecio)
                {
                    cantidadTrapecio++;
                    areaTrapecio += forma.CalcularArea();
                    perimetroTrapecio += forma.CalcularPerimetro();
                }
            }
            var respuesta = new StringBuilder();

            respuesta.Append(GetTitulo());

            respuesta.Append(CrearLinea(cantidadCuadrados, areaCuadrados, perimetroCuadrados, FormaEnum.Cuadrado));
            respuesta.Append(CrearLinea(cantidadCirculos, areaCirculos, perimetroCirculos, FormaEnum.Circulo));
            respuesta.Append(CrearLinea(cantidadTriangulos, areaTriangulos, perimetroTriangulos, FormaEnum.Triangulo));
            respuesta.Append(CrearLinea(cantidadRectangulo, areaRectangulo, perimetroRectangulo, FormaEnum.Rectangulo));
            respuesta.Append(CrearLinea(cantidadTrapecio, areaTrapecio, perimetroTrapecio, FormaEnum.Trapecio));

            respuesta.Append(GetTotal());

            respuesta.Append($"{cantidadCuadrados + cantidadTriangulos + cantidadCirculos + cantidadRectangulo + cantidadTrapecio} {GetTraduccionTextoFormas()} ");
            respuesta.Append($"{GetTraduccionPerimetro()} {(perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroRectangulo + perimetroTrapecio).ToString("#.##")} ");
            respuesta.Append($"{GetTraduccionArea()} {(areaCuadrados + areaCirculos + areaTriangulos + areaRectangulo + areaTrapecio).ToString("#.##")}");

            return respuesta.ToString();
        }

        private string CrearLinea(int cantidad, decimal area, decimal perimetro, FormaEnum forma)
        {
            if (cantidad > 0)
            {
                var respuesta = new StringBuilder();

                respuesta.Append($"{cantidad} {GetTraduccionFormas(forma, cantidad > 1)} | {GetTraduccionArea()} {area:#.##} | {GetTraduccionPerimetro()} {perimetro:#.##} <br/>");

                return respuesta.ToString();
            }
            return string.Empty;
        }

        private string GetTraduccionPerimetro()
        {
            if (_Idioma == IdiomasEnum.Castellano || _Idioma == IdiomasEnum.Italiano)
                return "Perimetro";
            else if (_Idioma == IdiomasEnum.Ingles)
                return "Perimeter";

            return string.Empty;
        }
        private string GetTraduccionArea()
        {
            return "Area";
        }
        private string GetTraduccionTextoFormas()
        {
            if (_Idioma == IdiomasEnum.Castellano)
                return "formas";
            else if (_Idioma == IdiomasEnum.Ingles)
                return "shapes";
            else if (_Idioma == IdiomasEnum.Italiano)
                return "forme";

            return string.Empty;
        }

        private string GetTraduccionFormas(FormaEnum forma, bool masDeUno)
        {
            if (_Idioma == IdiomasEnum.Castellano)
            {
                if (forma == FormaEnum.Cuadrado)
                {
                    return masDeUno ? "Cuadrados" : "Cuadrado";
                }
                else if (forma == FormaEnum.Circulo)
                {
                    return masDeUno ? "Círculos" : "Círculo";
                }
                else if (forma == FormaEnum.Triangulo)
                {
                    return masDeUno ? "Triángulos" : "Triángulo";
                }
                else if (forma == FormaEnum.Rectangulo)
                {
                    return masDeUno ? "Rectangulos" : "Rectangulo";
                }
                else if (forma == FormaEnum.Trapecio)
                {
                    return masDeUno ? "Trapecios" : "Trapecio";
                }
            }
            else if (_Idioma == IdiomasEnum.Ingles)
            {
                if (forma == FormaEnum.Cuadrado)
                {
                    return masDeUno ? "Squares" : "Square";
                }
                else if (forma == FormaEnum.Circulo)
                {
                    return masDeUno ? "Circles" : "Circle";
                }
                else if (forma == FormaEnum.Triangulo)
                {
                    return masDeUno ? "Triangles" : "Triangle";
                }
                else if (forma == FormaEnum.Rectangulo)
                {
                    return masDeUno ? "Rectangles" : "Rectangle";
                }
                else if (forma == FormaEnum.Trapecio)
                {
                    return masDeUno ? "Trapezoids" : "Trapeze";
                }
            }
            else if (_Idioma == IdiomasEnum.Italiano)
            {
                if (forma == FormaEnum.Cuadrado)
                {
                    return masDeUno ? "Piazze" : "Piazza";
                }
                else if (forma == FormaEnum.Circulo)
                {
                    return masDeUno ? "Cerchi" : "Cerchio";
                }
                else if (forma == FormaEnum.Triangulo)
                {
                    return masDeUno ? "Triangoli" : "Triangolo";
                }
                else if (forma == FormaEnum.Rectangulo)
                {
                    return masDeUno ? "Rettangoli" : "Rettangolo";
                }
                else if (forma == FormaEnum.Trapecio)
                {
                    return masDeUno ? "Trapezio" : "Trapezio";
                }
            }

            return string.Empty;
        }
    }
}
