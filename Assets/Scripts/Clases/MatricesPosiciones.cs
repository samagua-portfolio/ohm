using System.Collections.Generic;

namespace Assets.Scripts.Clases
{
    // Clase Singleton
    public class MatricesPosiciones
    {
        #region Attributes
        private static MatricesPosiciones matricesPosiciones;
        private List<MatrizPosiciones> tablaMatricesPosiciones;
        #endregion

        #region Properties
        public List<MatrizPosiciones> TablaMatricesPosiciones
        {
            get
            {
                return tablaMatricesPosiciones;
            }
        }
        #endregion

        #region Methods
        public static MatricesPosiciones ObtenerInstancia()
        {
            if (matricesPosiciones == null)
            {
                matricesPosiciones = GenerarInstancia();
            }

            return matricesPosiciones;
        }

        private MatricesPosiciones()
        {

        }

        private static MatricesPosiciones GenerarInstancia()
        {
            MatricesPosiciones matricesPosiciones = new MatricesPosiciones();
            List<MatrizPosiciones> tablaMatricesPosiciones = new List<MatrizPosiciones>();

            MatrizPosiciones matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                true, false, false,
                true, false, false,
                true, false, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.IZQUIERDA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.IZQUIERDA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                true, false, false,
                true, false, false,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.IZQUIERDA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                true, false, false,
                false, true, false,
                true, false, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.IZQUIERDA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.IZQUIERDA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                true, false, false,
                false, true, false,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.IZQUIERDA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                true, false, false,
                false, true, false,
                false, false, true };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.IZQUIERDA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.DERECHA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                true, false, false,
                true, false, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.IZQUIERDA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                true, false, false,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                false, true, false,
                true, false, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.IZQUIERDA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                false, true, false,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                false, true, false,
                false, false, true };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.DERECHA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                false, false, true,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, true, false,
                false, false, true,
                false, false, true };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.CENTRO;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.DERECHA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, false, true,
                false, true, false,
                true, false, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.DERECHA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.IZQUIERDA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, false, true,
                false, true, false,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.DERECHA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, false, true,
                false, true, false,
                false, false, true };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.DERECHA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.DERECHA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, false, true,
                false, false, true,
                false, true, false };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.DERECHA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.CENTRO;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matrizPosiciones = new MatrizPosiciones();
            matrizPosiciones.Matriz = new bool[] {
                false, false, true,
                false, false, true,
                false, false, true };
            matrizPosiciones.TipoPosicionPrimeraFila = TipoPosicion.DERECHA;
            matrizPosiciones.TipoPosicionUltimaFila = TipoPosicion.DERECHA;
            tablaMatricesPosiciones.Add(matrizPosiciones);

            matricesPosiciones.tablaMatricesPosiciones = tablaMatricesPosiciones;

            return matricesPosiciones;
        }
        #endregion
    }
}