using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorMetros : MonoBehaviour
{
    #region Attributes
    private GameObject objEcuacion;
    private GameObject objVoltimetro;
    private GameObject objOhmetro;
    #endregion    

    #region Methods
    public void Actualizar(LeyOhm leyOhm)
    {
        objEcuacion.GetComponent<ControladorEcuacion>().EstablecerValores(leyOhm);
        objVoltimetro.GetComponent<ControladorMetro>().EstablecerValor((int)leyOhm.Voltage);
        objOhmetro.GetComponent<ControladorMetro>().EstablecerValor((int)leyOhm.Resistencia);
    }

    private void Awake()
    {
        objEcuacion = transform.GetChild(0).gameObject;
        objVoltimetro = transform.GetChild(1).gameObject;
        objOhmetro = transform.GetChild(2).gameObject;
    }
    #endregion
}