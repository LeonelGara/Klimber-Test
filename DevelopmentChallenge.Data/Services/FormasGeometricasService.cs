using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Services
{
    public class FormasGeometricasService
    {
        public FormasGeometricasService() { }


        public static string Imprimir(List<IFormaGeometrica> formas, IdiomasEnum idioma)
        {
            var reporteTexto = new ReporteTextoService(idioma);

            if (!formas.Any())
            {
                return reporteTexto.GetListaVacia();
            }

            return reporteTexto.Imprimir(formas);
        }
    }
}
