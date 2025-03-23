namespace Assets.Scripts.Clases
{
    public class FilaCodigoColores
    {
        #region Attributes
        private string nombreColor;
        private UnityEngine.Color color;
        private string digito;
        private string multiplicador;
        private string tolerancia;
        private string coeficienteTemperatura;
        #endregion

        #region Properties
        public string NombreColor
        {
            get
            {
                return nombreColor;
            }
            internal set
            {
                nombreColor = value;
            }
        }

        public UnityEngine.Color Color
        {
            get
            {
                return color;
            }

            internal set
            {
                color = value;
            }
        }

        public string Digito
        {
            get
            {
                return digito;
            }
            internal set
            {
                digito = value;
            }
        }

        public string Multiplicador
        {
            get
            {
                return multiplicador;
            }
            internal set
            {
                multiplicador = value;
            }
        }

        public string Tolerancia
        {
            get
            {
                return tolerancia;
            }
            internal set
            {
                tolerancia = value;
            }
        }

        public string CoeficienteTemperatura
        {
            get
            {
                return coeficienteTemperatura;
            }
            internal set
            {
                coeficienteTemperatura = value;
            }
        }
        #endregion

        #region Methods
        internal FilaCodigoColores()
        {

        }
        #endregion
    }
}
