using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControladorLogotipo : MonoBehaviour
{
    #region Attributes
    public float opacidadAgregada = 0.3f;
    public float opacidadIntervalo = 0.005f;    

    private Color colorInicial;
    #endregion

    #region Methods
    private void Awake()
    {
        colorInicial = gameObject.GetComponent<Image>().color;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Image>().color = colorInicial;
        StartCoroutine(CorutinaResaltar());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator CorutinaResaltar()
    {
        yield return null;

        Color colorAuxiliar;
        opacidadAgregada = Mathf.Abs(opacidadAgregada);
        opacidadIntervalo = Mathf.Abs(opacidadIntervalo);

        while (true)
        {
            for (int i = 0; i * opacidadIntervalo <= opacidadAgregada; i++)
            {
                colorAuxiliar = gameObject.GetComponent<Image>().color;
                colorAuxiliar.a += opacidadIntervalo;
                gameObject.GetComponent<Image>().color = colorAuxiliar;
                yield return null;
            }            

            for (int i = 0; i * opacidadIntervalo <= opacidadAgregada; i++)
            {
                colorAuxiliar = gameObject.GetComponent<Image>().color;
                colorAuxiliar.a -= opacidadIntervalo;
                gameObject.GetComponent<Image>().color = colorAuxiliar;
                yield return null;
            }            
        }
    }
    #endregion
}
