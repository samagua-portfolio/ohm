using Assets.Scripts.Clases;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorIconos : MonoBehaviour
{
    #region Attributes
    private ControladorPaneles ctrlPaneles;
    private ControladorEscenas ctrlEscenas;
    private GameObject objIconoInicio;
    private GameObject objIconoReinicio;
    private GameObject objIconoTutorial;
    private GameObject objIconoInformacion;
    private GameObject objIconoSonido;

    private Sprite sprtSonidoActivado;
    private Sprite sprtSonidoDesactivado;
    #endregion    

    #region Methods
    public void Reiniciar()
    {
        ctrlPaneles.DesactivarPaneles();
        ctrlEscenas.Cargar(SceneManager.GetActiveScene().name);
    }

    public void VolverInicio()
    {
        ctrlPaneles.DesactivarPaneles();
        ctrlEscenas.Cargar(Constantes.ESCENA_MENU_PRINCIPAL);
    }

    public void ActivarAudio()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            objIconoSonido.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprtSonidoDesactivado;
        }
        else
        {
            AudioListener.volume = 1;
            objIconoSonido.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprtSonidoActivado;
        }
    }

    public void ActivarPanel(int numeroPanel)
    {
        bool estadoPanel = ctrlPaneles.EstadoPanel(numeroPanel);
        ctrlPaneles.DesactivarPaneles();

        if (!estadoPanel)
        {
            ctrlPaneles.ActivarPanel(numeroPanel);
        }
    }

    private void Start()
    {
        ctrlPaneles = transform.parent.GetChild(1).gameObject.GetComponent<ControladorPaneles>();
        ctrlEscenas = FindObjectOfType<ControladorEscenas>();
        objIconoInicio = transform.GetChild(0).gameObject;
        objIconoReinicio = transform.GetChild(1).gameObject;
        objIconoTutorial = transform.GetChild(2).gameObject;
        objIconoInformacion = transform.GetChild(3).gameObject;
        objIconoSonido = transform.GetChild(4).gameObject;

        sprtSonidoActivado = Resources.Load<Sprite>("Iconos/sonidoActivado");
        sprtSonidoDesactivado = Resources.Load<Sprite>("Iconos/sonidoDesactivado");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == Constantes.ESCENA_NIVEL)
        {
            if (!objIconoInicio.activeInHierarchy)
            {
                objIconoInicio.SetActive(true);
            }

            if (!objIconoReinicio.activeInHierarchy)
            {
                objIconoReinicio.SetActive(true);
            }

            if (!objIconoTutorial.activeInHierarchy)
            {
                objIconoTutorial.SetActive(true);
            }

            if (!objIconoInformacion.activeInHierarchy)
            {
                objIconoInformacion.SetActive(true);
            }

            if (!objIconoSonido.activeInHierarchy)
            {
                objIconoSonido.SetActive(true);
            }
        }
        else
        {
            if (objIconoInicio.activeInHierarchy)
            {
                objIconoInicio.SetActive(false);
            }

            if (objIconoReinicio.activeInHierarchy)
            {
                objIconoReinicio.SetActive(false);
            }

            if (objIconoTutorial.activeInHierarchy)
            {
                objIconoTutorial.SetActive(false);
            }

            if (objIconoInformacion.activeInHierarchy)
            {
                objIconoInformacion.SetActive(false);
            }

            if (objIconoSonido.activeInHierarchy)
            {
                objIconoSonido.SetActive(false);
            }
        }
    }
    #endregion    
}
