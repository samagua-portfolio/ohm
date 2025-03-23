using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Clases;

public class ControladorMenuPrincipal : MonoBehaviour
{
    #region Attributes
    private ControladorPaneles ctrlPaneles;
    private ControladorEscenas ctrlEscenas;
    private GameObject objOpcionesPrincipales;
    private GameObject objOpcionesSecundarias;
    private GameObject objRecord;
    private GameObject objBotonSalir;
    #endregion

    #region Methods
    public void ActualizarPreferencia(string preferencia)
    {
        if (preferencia == Constantes.PREFERENCIA_MOSTRAR_TUTORIAL)
        {
            PlayerPrefs.SetInt(Constantes.PREFERENCIA_MOSTRAR_TUTORIAL, GetComponentInChildren<Toggle>().isOn ? 1 : 0);
        }
        if (preferencia == Constantes.PREFERENCIA_DIFICULTAD)
        {
            PlayerPrefs.SetInt(Constantes.PREFERENCIA_DIFICULTAD, GetComponentInChildren<Dropdown>().value);
        }
    }

    public void EmpezarPartida()
    {
        if (PlayerPrefs.GetInt(Constantes.PREFERENCIA_MOSTRAR_TUTORIAL) == 1)
        {
            ctrlEscenas.Cargar(Constantes.ESCENA_TUTORIAL);
        }
        else
        {
            ctrlEscenas.Cargar(Constantes.ESCENA_NIVEL);
        }
    }

    public void CambiarOpciones()
    {
        if (objOpcionesPrincipales.activeInHierarchy)
        {
            objOpcionesPrincipales.SetActive(false);
            objOpcionesSecundarias.SetActive(true);
            EstablecerPreferencias();
        }
        else
        {
            objOpcionesPrincipales.SetActive(true);
            objOpcionesSecundarias.SetActive(false);
        }

    }

    public void ActivarPanel(int numeroPanel)
    {
        ctrlPaneles.ActivarPanel(numeroPanel);
    }

    public void DesactivarPanel(int numeroPanel)
    {
        ctrlPaneles.DesactivarPanel(numeroPanel);
    }

    public void Salir()
    {
        Application.Quit();
    }

    private void Start()
    {
        ctrlPaneles = FindObjectOfType<ControladorPaneles>();
        ctrlEscenas = FindObjectOfType<ControladorEscenas>();
        objOpcionesPrincipales = transform.GetChild(1).gameObject;
        objOpcionesSecundarias = transform.GetChild(2).gameObject;
        objRecord = objOpcionesPrincipales.transform.GetChild(0).gameObject;
        objBotonSalir = objOpcionesPrincipales.transform.GetChild(4).gameObject;

        objOpcionesPrincipales.SetActive(true);
        objOpcionesSecundarias.SetActive(false);

        EstablecerRecord();

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            objBotonSalir.SetActive(true);
        }
    }

    private void EstablecerRecord()
    {
        objRecord.GetComponent<Text>().text = "RÉCORD: " + PlayerPrefs.GetInt(Constantes.PREFERENCIA_RECORD_PUNTOS, 0) + " puntos (" + PlayerPrefs.GetInt(Constantes.PREFERENCIA_RECORD_TIEMPO, 0) + " segundos)";
    }

    private void EstablecerPreferencias()
    {
        if (!PlayerPrefs.HasKey(Constantes.PREFERENCIA_MOSTRAR_TUTORIAL))
        {
            PlayerPrefs.SetInt(Constantes.PREFERENCIA_MOSTRAR_TUTORIAL, 1);
        }

        if (!PlayerPrefs.HasKey(Constantes.PREFERENCIA_DIFICULTAD))
        {
            PlayerPrefs.SetInt(Constantes.PREFERENCIA_DIFICULTAD, (int)TipoDificultad.FACIL);
        }

        StartCoroutine(CorutinaEstablecerPreferencias());
    }

    private IEnumerator CorutinaEstablecerPreferencias()
    {
        yield return null;

        while (true)
        {
            if (GetComponentInChildren<Toggle>().isActiveAndEnabled && GetComponentInChildren<Dropdown>().isActiveAndEnabled)
            {
                GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt(Constantes.PREFERENCIA_MOSTRAR_TUTORIAL) == 1 ? true : false;
                GetComponentInChildren<Dropdown>().value = PlayerPrefs.GetInt(Constantes.PREFERENCIA_DIFICULTAD);
                break;
            }
            else
            {
                yield return null;
            }
        }
    }
    #endregion
}
