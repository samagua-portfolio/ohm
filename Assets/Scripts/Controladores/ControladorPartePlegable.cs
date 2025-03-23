using System.Collections;
using UnityEngine;

public class ControladorPartePlegable : MonoBehaviour
{
    #region Attributes    
    public bool plegarseDerecha;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    #endregion    

    #region Methods
    private void Start()
    {
        posicionInicial = Vector3.zero;

        if (plegarseDerecha)
        {
            posicionFinal = Vector3.left;
        }
        else
        {
            posicionFinal = Vector3.right;
        }

        transform.localPosition = posicionInicial;
        posicionFinal *= 0.5f;

        StartCoroutine(CorutinaPlegar());
    }

    private IEnumerator CorutinaPlegar()
    {
        Vector3 posicionObjetivo = posicionFinal;
        float velocidad = 1.5f;
        float segundosEspera = 2.5f;

        while (true)
        {
            float paso = velocidad * Time.deltaTime;

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicionObjetivo, paso);

            if (transform.localPosition == posicionFinal)
            {
                posicionObjetivo = posicionInicial;
                yield return new WaitForSecondsRealtime(segundosEspera);
            }
            if (transform.localPosition == posicionInicial)
            {
                posicionObjetivo = posicionFinal;
                yield return new WaitForSecondsRealtime(segundosEspera);
            }

            yield return null;
        }
    }
    #endregion
}
