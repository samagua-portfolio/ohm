namespace Assets.Scripts.Clases
{
    public class MatrizPosiciones
    {
        #region Attributes
        private bool[] matriz;
        private TipoPosicion tipoPosicionPrimeraFila;
        private TipoPosicion tipoPosicionUltimaFila;
        #endregion

        #region Properties
        public bool[] Matriz
        {
            get
            {
                return matriz;
            }
            internal set
            {
                matriz = value;
            }
        }

        public TipoPosicion TipoPosicionPrimeraFila
        {
            get
            {
                return tipoPosicionPrimeraFila;
            }
            internal set
            {
                tipoPosicionPrimeraFila = value;
            }
        }

        public TipoPosicion TipoPosicionUltimaFila
        {
            get
            {
                return tipoPosicionUltimaFila;
            }
            internal set
            {
                tipoPosicionUltimaFila = value;
            }
        }
        #endregion

        #region Methods
        internal MatrizPosiciones()
        {

        }
        #endregion
    }
}
