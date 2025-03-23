using System.Collections;
using UnityEngine;

public class ControladorNivel : MonoBehaviour
{
    #region Attributes
    public AudioClip[] clipsAudio;

    private ControladorIndicadorPuntuacion ctrlIndicadorPuntuacion;
    private ControladorIndicadorTiempo ctrlIndicadorTiempo;
    private ControladorPanelResumen ctrlPanelResumen;
    private AudioSource cpntAudioSource;
    private bool esCompletado;
    private bool mostrandoAyuda;
    private bool ayudaMostrada;
    #endregion

    #region Properties    
    public ControladorIndicadorPuntuacion IndicadorPuntuacion
    {
        get
        {
            return ctrlIndicadorPuntuacion;
        }
    }

    public ControladorIndicadorTiempo IndicadorTiempo
    {
        get
        {
            return ctrlIndicadorTiempo;
        }
    }

    public bool EsCompletado
    {
        get
        {
            return esCompletado;
        }
    }

    public bool MostrandoAyuda
    {
        get
        {
            return mostrandoAyuda;
        }
    }

    public bool AyudaMostrada
    {
        get
        {
            return ayudaMostrada;
        }
    }
    #endregion

    #region Methods
    public void Terminar(bool metaAlcanzada)
    {
        esCompletado = true;
        ReproducirAudio(metaAlcanzada);
        StartCoroutine(CorutinaTerminar());
    }

    public void MostrarAyuda(bool mostrar)
    {
        mostrandoAyuda = mostrar;
        if (!ayudaMostrada && mostrandoAyuda)
        {
            ayudaMostrada = true;
        }
    }

    private void Awake()
    {
        ctrlIndicadorPuntuacion = transform.GetChild(0).GetChild(0).gameObject.GetComponent<ControladorIndicadorPuntuacion>();
        ctrlIndicadorTiempo = transform.GetChild(0).GetChild(1).gameObject.GetComponent<ControladorIndicadorTiempo>();
        ctrlPanelResumen = transform.GetChild(0).GetChild(2).gameObject.GetComponent<ControladorPanelResumen>();
        cpntAudioSource = GetComponent<AudioSource>();
        esCompletado = false;
        mostrandoAyuda = false;
    }

    private IEnumerator CorutinaTerminar()
    {
        yield return new WaitForSecondsRealtime(1f);
        ctrlPanelResumen.Mostrar();
    }

    private void ReproducirAudio(bool metaAlcanzada)
    {
        if (metaAlcanzada)
        {
            cpntAudioSource.clip = clipsAudio[0];
        }
        else
        {
            cpntAudioSource.clip = clipsAudio[1];
        }
        cpntAudioSource.Play();
    }
    #endregion
}
