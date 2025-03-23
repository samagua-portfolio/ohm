using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorEcuacion : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private GameObject objAmperimetro;
    private GameObject objVoltimetro;
    private GameObject objOhmetro;
    private bool esMostrada;
    #endregion    

    #region Methods
    public void EstablecerValores(LeyOhm leyOhm)
    {
        objAmperimetro.GetComponent<ControladorAmperimetro>().EstablecerValor(leyOhm.ObtenerCorriente());
        objVoltimetro.GetComponent<ControladorMetro>().EstablecerValor((int)leyOhm.Voltage);
        objOhmetro.GetComponent<ControladorMetro>().EstablecerValor((int)leyOhm.Resistencia);
    }

    private void Awake()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        objAmperimetro = transform.GetChild(0).gameObject;
        objVoltimetro = transform.GetChild(1).gameObject;
        objOhmetro = transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        esMostrada = ctrlNivel.MostrandoAyuda;

        for (int i = 1; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy != esMostrada)
            {
                transform.GetChild(i).gameObject.SetActive(esMostrada);
            }
        }

        if (esMostrada)
        {
            if (transform.GetChild(0).localPosition.x != 0.475f)
            {
                transform.GetChild(0).localPosition = new Vector3(0.475f, 0f);
            }
        }
        else
        {
            if (transform.GetChild(0).localPosition.x != 0f)
            {
                transform.GetChild(0).localPosition = Vector3.zero;
            }
        }
    }
    #endregion
}
