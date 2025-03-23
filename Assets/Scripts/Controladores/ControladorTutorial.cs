using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTutorial : MonoBehaviour
{
    #region Attributes
    private ControladorEscenas ctrlEscenas;
    private List<GameObject> objsPasos;
    private GameObject objBotonAnterior;
    private GameObject objBotonSiguiente;
    private GameObject objBotonMenuPrincipal;
    private GameObject objBotonComenzar;
    private GameObject objNumeroPaso;
    private int numeroPasoActual;
    #endregion

    #region Methods
    public void CargarEscena(string nombreEscena)
    {
        if (ctrlEscenas != null)
        {
            ctrlEscenas.Cargar(nombreEscena);
        }
    }

    public void CambiarPaso(int cantidadPaso)
    {
        numeroPasoActual = numeroPasoActual + cantidadPaso;
        if (numeroPasoActual < 0)
        {
            numeroPasoActual = 0;
        }
        if (numeroPasoActual > (objsPasos.Count - 1))
        {
            numeroPasoActual = objsPasos.Count - 1;
        }

        DesactivarPasos();
        objsPasos[numeroPasoActual].SetActive(true);
        ActualizarBotones();
        ActualizarNumeroPaso();
    }

    private void Awake()
    {
        ctrlEscenas = FindObjectOfType<ControladorEscenas>();

        objsPasos = new List<GameObject>();

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            objsPasos.Add(transform.GetChild(0).GetChild(i).gameObject);
        }

        objBotonAnterior = transform.GetChild(1).GetChild(0).gameObject;
        objBotonSiguiente = transform.GetChild(1).GetChild(1).gameObject;
        objBotonMenuPrincipal = transform.GetChild(1).GetChild(2).gameObject;
        objBotonComenzar = transform.GetChild(1).GetChild(3).gameObject;
        objNumeroPaso = transform.GetChild(1).GetChild(4).gameObject;

        numeroPasoActual = 0;
        DesactivarPasos();
        objsPasos[numeroPasoActual].SetActive(true);
        ActualizarBotones();
        ActualizarNumeroPaso();
    }

    private void DesactivarPasos()
    {
        for (int i = 0; i < objsPasos.Count; i++)
        {
            objsPasos[i].SetActive(false);
        }
    }

    private void ActualizarBotones()
    {
        if (numeroPasoActual == 0)
        {
            objBotonAnterior.SetActive(false);
        }
        else
        {
            objBotonAnterior.SetActive(true);
        }

        if (numeroPasoActual == (objsPasos.Count - 1))
        {
            objBotonSiguiente.SetActive(false);
        }
        else
        {
            objBotonSiguiente.SetActive(true);
        }

        objBotonMenuPrincipal.SetActive(!objBotonAnterior.activeInHierarchy);
        objBotonComenzar.SetActive(!objBotonSiguiente.activeInHierarchy);
    }

    private void ActualizarNumeroPaso()
    {
        int numero = numeroPasoActual + 1;
        objNumeroPaso.GetComponent<Text>().text = numero + "/" + objsPasos.Count;
    }
    #endregion
}
