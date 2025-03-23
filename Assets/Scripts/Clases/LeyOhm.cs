using System;

namespace Assets.Scripts.Clases
{
    public class LeyOhm
    {
        #region Attributes
        private float voltage;
        private float resistencia;
        #endregion

        #region Properties
        public float Voltage
        {
            set
            {
                voltage = value;
            }
            get
            {
                return voltage;
            }
        }

        public float Resistencia
        {
            set
            {
                resistencia = value;
            }
            get
            {
                return resistencia;
            }
        }
        #endregion

        #region Methods
        public float ObtenerCorriente()
        {
            if (resistencia > 0)
            {
                return voltage / resistencia;
            }
            else
            {
                return 0f;
            }
        }
        #endregion
    }
}
