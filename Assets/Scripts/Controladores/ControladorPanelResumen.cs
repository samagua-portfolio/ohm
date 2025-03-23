using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Clases;

public class ControladorPanelResumen : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private GameObject objContenido;
    private Text cpntTextoPuntuacion;
    private Text cpntTextoRecord;
    private bool nuevoRecord;
    #endregion

    #region Methods
    public void Mostrar()
    {
        objContenido.SetActive(true);
        nuevoRecord = VerificarRecord();
        cpntTextoPuntuacion.text = "¡Has obtenido " + ctrlNivel.IndicadorPuntuacion.Puntos + " puntos en " + ctrlNivel.IndicadorTiempo.Segundos + " segundos!";
        cpntTextoRecord.text = nuevoRecord ? "¡Nuevo récord!" : "¡Récord no superado!";

        if (nuevoRecord)
        {
            GuardarRecord();
        }
    }

    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        objContenido = transform.GetChild(0).gameObject;
        cpntTextoPuntuacion = objContenido.transform.GetChild(0).gameObject.GetComponent<Text>();
        cpntTextoRecord = objContenido.transform.GetChild(1).gameObject.GetComponent<Text>();
        objContenido.SetActive(false);
    }

    private bool VerificarRecord()
    {
        if (ctrlNivel.IndicadorPuntuacion.Puntos == 0)
        {
            return false;
        }

        if (PlayerPrefs.GetInt(Constantes.PREFERENCIA_RECORD_PUNTOS, 0) < ctrlNivel.IndicadorPuntuacion.Puntos)
        {
            return true;
        }
        if (PlayerPrefs.GetInt(Constantes.PREFERENCIA_RECORD_TIEMPO, 0) > ctrlNivel.IndicadorTiempo.Segundos && PlayerPrefs.GetInt(Constantes.PREFERENCIA_RECORD_PUNTOS, 0) == ctrlNivel.IndicadorPuntuacion.Puntos)
        {
            return true;
        }

        return false;
    }

    private void GuardarRecord()
    {
        PlayerPrefs.SetInt(Constantes.PREFERENCIA_RECORD_PUNTOS, ctrlNivel.IndicadorPuntuacion.Puntos);
        PlayerPrefs.SetInt(Constantes.PREFERENCIA_RECORD_TIEMPO, ctrlNivel.IndicadorTiempo.Segundos);
    }
    #endregion
}
