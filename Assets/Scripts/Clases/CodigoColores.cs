using System.Collections.Generic;

namespace Assets.Scripts.Clases
{
    // Clase singleton
    public class CodigoColores
    {
        #region Attributes
        private static CodigoColores codigoColores;
        private Dictionary<TipoColor, FilaCodigoColores> tablaCodigoColores;
        #endregion

        #region Properties
        public Dictionary<TipoColor, FilaCodigoColores> TablaCodigoColores
        {
            get
            {
                return tablaCodigoColores;
            }
        }
        #endregion

        #region Methods
        public static CodigoColores ObtenerInstancia()
        {
            if (codigoColores == null)
            {
                codigoColores = GenerarInstancia();
            }

            return codigoColores;
        }

        private CodigoColores()
        {

        }

        private static CodigoColores GenerarInstancia()
        {
            CodigoColores codigoColores = new CodigoColores();
            Dictionary<TipoColor, FilaCodigoColores> tablaCodigoColores = new Dictionary<TipoColor, FilaCodigoColores>();

            // Ninguno
            FilaCodigoColores filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Ninguno";
            filaCodigoColores.Color = UnityEngine.Color.clear;
            filaCodigoColores.Digito = string.Empty;
            filaCodigoColores.Multiplicador = string.Empty;
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("20");
            filaCodigoColores.CoeficienteTemperatura = string.Empty;
            tablaCodigoColores.Add(TipoColor.NINGUNO, filaCodigoColores);

            // Rosa
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Rosa";
            filaCodigoColores.Color = new UnityEngine.Color(0.9686f, 0.7490f, 0.7450f);
            filaCodigoColores.Digito = string.Empty;
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("-3");
            filaCodigoColores.Tolerancia = string.Empty;
            filaCodigoColores.CoeficienteTemperatura = string.Empty;
            tablaCodigoColores.Add(TipoColor.ROSA, filaCodigoColores);

            // Plateado
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Plateado";
            filaCodigoColores.Color = new UnityEngine.Color(0.7529f, 0.7529f, 0.7529f);
            filaCodigoColores.Digito = string.Empty;
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("-2");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("10");
            filaCodigoColores.CoeficienteTemperatura = string.Empty;
            tablaCodigoColores.Add(TipoColor.PLATEADO, filaCodigoColores);

            // Dorado
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Dorado";
            filaCodigoColores.Color = new UnityEngine.Color(0.8431f, 0.6862f, 0.2156f);
            filaCodigoColores.Digito = string.Empty;
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("-1");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("5");
            filaCodigoColores.CoeficienteTemperatura = string.Empty;
            tablaCodigoColores.Add(TipoColor.DORADO, filaCodigoColores);

            // Negro
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Negro";
            filaCodigoColores.Color = UnityEngine.Color.black;
            filaCodigoColores.Digito = ObtenerCadenaDigito("0");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("0");
            filaCodigoColores.Tolerancia = string.Empty;
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("250");
            tablaCodigoColores.Add(TipoColor.NEGRO, filaCodigoColores);

            // Café
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Café";
            filaCodigoColores.Color = new UnityEngine.Color(0.5529f, 0.2862f, 0.1450f);
            filaCodigoColores.Digito = ObtenerCadenaDigito("1");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("1");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("1");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("100");
            tablaCodigoColores.Add(TipoColor.CAFE, filaCodigoColores);

            // Rojo
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Rojo";
            filaCodigoColores.Color = UnityEngine.Color.red;
            filaCodigoColores.Digito = ObtenerCadenaDigito("2");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("2");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("2");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("50");
            tablaCodigoColores.Add(TipoColor.ROJO, filaCodigoColores);

            // Naranja
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Naranja";
            filaCodigoColores.Color = new UnityEngine.Color(0.9372f, 0.4980f, 0.1019f);
            filaCodigoColores.Digito = ObtenerCadenaDigito("3");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("3");
            filaCodigoColores.Tolerancia = string.Empty;
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("15");
            tablaCodigoColores.Add(TipoColor.NARANJA, filaCodigoColores);

            // Amarillo
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Amarillo";
            filaCodigoColores.Color = UnityEngine.Color.yellow;
            filaCodigoColores.Digito = ObtenerCadenaDigito("4");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("4");
            filaCodigoColores.Tolerancia = string.Empty;
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("25");
            tablaCodigoColores.Add(TipoColor.AMARILLO, filaCodigoColores);

            // Verde
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Verde";
            filaCodigoColores.Color = UnityEngine.Color.green;
            filaCodigoColores.Digito = ObtenerCadenaDigito("5");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("5");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("0.5");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("20");
            tablaCodigoColores.Add(TipoColor.VERDE, filaCodigoColores);

            // Azul
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Azul";
            filaCodigoColores.Color = UnityEngine.Color.blue;
            filaCodigoColores.Digito = ObtenerCadenaDigito("6");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("6");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("0.25");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("10");
            tablaCodigoColores.Add(TipoColor.AZUL, filaCodigoColores);

            // Violeta
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Violeta";
            filaCodigoColores.Color = new UnityEngine.Color(0.2980f, 0.1568f, 0.5098f);
            filaCodigoColores.Digito = ObtenerCadenaDigito("7");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("7");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("0.1");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("5");
            tablaCodigoColores.Add(TipoColor.VIOLETA, filaCodigoColores);

            // Gris
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Gris";
            filaCodigoColores.Color = UnityEngine.Color.gray;
            filaCodigoColores.Digito = ObtenerCadenaDigito("8");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("8");
            filaCodigoColores.Tolerancia = ObtenerCadenaTolerancia("0.05");
            filaCodigoColores.CoeficienteTemperatura = ObtenerCadenaCoeficienteTemperatura("1");
            tablaCodigoColores.Add(TipoColor.GRIS, filaCodigoColores);

            // Blanco
            filaCodigoColores = new FilaCodigoColores();
            filaCodigoColores.NombreColor = "Blanco";
            filaCodigoColores.Color = UnityEngine.Color.white;
            filaCodigoColores.Digito = ObtenerCadenaDigito("9");
            filaCodigoColores.Multiplicador = ObtenerCadenaMultiplicador("9");
            filaCodigoColores.Tolerancia = string.Empty;
            filaCodigoColores.CoeficienteTemperatura = string.Empty;
            tablaCodigoColores.Add(TipoColor.BLANCO, filaCodigoColores);

            codigoColores.tablaCodigoColores = tablaCodigoColores;

            return codigoColores;
        }

        private static string ObtenerCadenaDigito(string valor)
        {
            return valor;
        }

        private static string ObtenerCadenaMultiplicador(string valor)
        {
            return valor;
        }

        private static string ObtenerCadenaTolerancia(string valor)
        {
            return "±" + valor + "%";
        }

        private static string ObtenerCadenaCoeficienteTemperatura(string valor)
        {
            return valor + "ppm";
        }
        #endregion
    }
}
