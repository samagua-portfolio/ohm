using System.Collections.Generic;

namespace Assets.Scripts.Clases
{
    public class Resistencia
    {
        #region Attributes
        private Dictionary<int, Banda> bandas;
        #endregion

        #region Properties
        public Dictionary<int, Banda> Bandas
        {
            get
            {
                return bandas;
            }
        }
        #endregion

        #region Methods
        public static Resistencia Generar(int numeroBandas)
        {
            if (numeroBandas < 3)
            {
                numeroBandas = 3;
            }

            if (numeroBandas > 6)
            {
                numeroBandas = 6;
            }

            Resistencia resistencia = new Resistencia();
            resistencia.bandas = new Dictionary<int, Banda>();
            Banda banda;


            Dictionary<TipoColor, FilaCodigoColores> codigoColores = CodigoColores.ObtenerInstancia().TablaCodigoColores;
            int bandaActual = 1;
            bool bandaAceptada = false;
            TipoBanda tipoBanda = TipoBanda.NO_ASIGNADO;
            TipoColor tipoColor = TipoColor.NINGUNO;

            while (bandaActual <= numeroBandas)
            {
                while (!bandaAceptada)
                {
                    tipoColor = (TipoColor)UnityEngine.Random.Range(2, 15); // Se omite el EnumColor.NINGUNO
                    tipoBanda = TipoBanda.NO_ASIGNADO;

                    if (bandaActual == 1)
                    {
                        if (tipoColor != TipoColor.NEGRO)
                        {
                            tipoBanda = TipoBanda.DIGITO;
                        }
                    }

                    if (bandaActual == 2)
                    {
                        tipoBanda = TipoBanda.DIGITO;
                    }

                    if (bandaActual == 3 && numeroBandas < 5)
                    {
                        tipoBanda = TipoBanda.MULTIPLICADOR;
                    }

                    if (bandaActual == 4 && numeroBandas == 4)
                    {
                        tipoBanda = TipoBanda.TOLERANCIA;
                    }

                    if (bandaActual == 3 && numeroBandas > 4)
                    {
                        tipoBanda = TipoBanda.DIGITO;
                    }

                    if (bandaActual == 4 && numeroBandas > 4)
                    {
                        tipoBanda = TipoBanda.MULTIPLICADOR;
                    }

                    if (bandaActual == 5)
                    {
                        tipoBanda = TipoBanda.TOLERANCIA;
                    }

                    if (bandaActual == 6)
                    {
                        tipoBanda = TipoBanda.COEFICIENTE_TEMPERATURA;
                    }

                    bandaAceptada = ValidarColorBanda(tipoBanda, tipoColor);

                }

                banda = new Banda();
                banda.TipoBanda = tipoBanda;
                banda.TipoColor = tipoColor;
                banda.Valor = ObtenerValorBanda(banda.TipoBanda, banda.TipoColor);
                resistencia.bandas.Add(bandaActual, banda);
                bandaActual++;
                bandaAceptada = false;
            }

            // Los resistores de 3 bandas son resistores de 4 bandas con la última banda sin color.
            if (numeroBandas == 3)
            {
                banda = new Banda();
                banda.TipoBanda = TipoBanda.TOLERANCIA;
                banda.TipoColor = TipoColor.NINGUNO;
                banda.Valor = ObtenerValorBanda(banda.TipoBanda, banda.TipoColor);
                resistencia.bandas.Add(4, banda);
            }

            return resistencia;
        }

        private Resistencia()
        {

        }

        private static bool ValidarColorBanda(TipoBanda tipoBanda, TipoColor tipoColor)
        {
            Dictionary<TipoColor, FilaCodigoColores> codigoColores = CodigoColores.ObtenerInstancia().TablaCodigoColores;

            if (tipoBanda == TipoBanda.DIGITO)
            {
                if (codigoColores[tipoColor].Digito != string.Empty)
                {
                    return true;
                }
            }
            if (tipoBanda == TipoBanda.MULTIPLICADOR)
            {
                if (codigoColores[tipoColor].Multiplicador != string.Empty)
                {
                    return true;
                }
            }
            if (tipoBanda == TipoBanda.TOLERANCIA)
            {
                if (codigoColores[tipoColor].Tolerancia != string.Empty)
                {
                    return true;
                }
            }
            if (tipoBanda == TipoBanda.COEFICIENTE_TEMPERATURA)
            {
                if (codigoColores[tipoColor].CoeficienteTemperatura != string.Empty)
                {
                    return true;
                }
            }

            return false;
        }

        private static string ObtenerValorBanda(TipoBanda tipoBanda, TipoColor tipoColor)
        {
            Dictionary<TipoColor, FilaCodigoColores> codigoColores = CodigoColores.ObtenerInstancia().TablaCodigoColores;

            if (tipoBanda == TipoBanda.DIGITO)
            {
                return codigoColores[tipoColor].Digito;
            }
            if (tipoBanda == TipoBanda.MULTIPLICADOR)
            {
                return codigoColores[tipoColor].Multiplicador;
            }
            if (tipoBanda == TipoBanda.TOLERANCIA)
            {
                return codigoColores[tipoColor].Tolerancia;
            }
            if (tipoBanda == TipoBanda.COEFICIENTE_TEMPERATURA)
            {
                return codigoColores[tipoColor].CoeficienteTemperatura;
            }

            return string.Empty;
        }
        #endregion
    }
}
