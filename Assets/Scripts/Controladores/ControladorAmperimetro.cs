using UnityEngine;

public class ControladorAmperimetro : MonoBehaviour
{
    #region Attributes
    private GameObject[] objsValor;
    private static Sprite[] sprtsNumeros;
    #endregion

    #region Methods
    public void EstablecerValor(float valorActual)
    {
        if (valorActual > 0f && valorActual < 10f)
        {
            char[] cadenaValor = valorActual.ToString("f2").ToCharArray();
            objsValor[0].GetComponent<SpriteRenderer>().sprite = sprtsNumeros[(int)char.GetNumericValue(cadenaValor[0])];
            objsValor[2].GetComponent<SpriteRenderer>().sprite = sprtsNumeros[(int)char.GetNumericValue(cadenaValor[2])];
            objsValor[3].GetComponent<SpriteRenderer>().sprite = sprtsNumeros[(int)char.GetNumericValue(cadenaValor[3])];
        }
    }

    private void Awake()
    {
        objsValor = new GameObject[4];
        objsValor[0] = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        objsValor[1] = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        objsValor[2] = transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        objsValor[3] = transform.GetChild(0).GetChild(0).GetChild(3).gameObject;

        if (sprtsNumeros == null)
        {
            sprtsNumeros = Resources.LoadAll<Sprite>("Otros/numeros");
        }
    }
    #endregion
}
