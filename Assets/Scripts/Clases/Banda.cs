namespace Assets.Scripts.Clases
{
    public class Banda
    {
        #region Attributes
        private TipoColor tipoColor;
        private string valor;
        private TipoBanda tipoBanda;
        #endregion

        #region Properties
        public TipoColor TipoColor
        {
            get
            {
                return tipoColor;
            }
            internal set
            {
                tipoColor = value;
            }
        }

        public string Valor
        {
            get
            {
                return valor;
            }
            internal set
            {
                valor = value;
            }
        }

        public TipoBanda TipoBanda
        {
            get
            {
                return tipoBanda;
            }
            internal set
            {
                tipoBanda = value;
            }
        }
        #endregion;

        #region Methods
        internal Banda()
        {

        }
        #endregion
    }
}
