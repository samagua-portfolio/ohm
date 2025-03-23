using UnityEngine;

public class ControladorMetro : MonoBehaviour
{
    #region Attributes
    private GameObject objValor;
    private static Sprite[] sprtsNumeros;
    #endregion

    #region Methods
    public void EstablecerValor(float valor)
    {
        if (valor > 0f && valor < 10f)
        {
            objValor.GetComponent<SpriteRenderer>().sprite = sprtsNumeros[(int)valor];
        }
    }

    private void Awake()
    {
        objValor = transform.GetChild(0).GetChild(0).gameObject;

        if (sprtsNumeros == null)
        {
            sprtsNumeros = Resources.LoadAll<Sprite>("Otros/numeros");
        }
    }
    #endregion
}
