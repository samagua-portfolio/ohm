using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControladorIndicadorTiempo : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private GameObject objValor;
    private Text cpntTextoValor;
    private int segundos;
    #endregion

    #region Properties
    public int Segundos
    {
        get
        {
            return segundos;
        }
    }
    #endregion

    #region Methods
    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        objValor = transform.GetChild(1).gameObject;
        cpntTextoValor = objValor.GetComponent<Text>();
        StartCoroutine(CorutinaActualizar());
    }

    private IEnumerator CorutinaActualizar()
    {
        segundos = 0;
        while (segundos <= 999999)
        {
            cpntTextoValor.text = segundos.ToString().PadLeft(6, '0');
            yield return new WaitForSecondsRealtime(1f);

            if (ctrlNivel.EsCompletado)
            {
                break;
            }

            segundos++;
        }
    }
    #endregion
}
