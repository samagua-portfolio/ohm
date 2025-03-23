using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorMoneda : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private ControladorRepositorio ctrlRepositorio;
    private SpriteRenderer cpntSpriteRenderer;
    private AudioSource cpntAudioSource;
    private bool recogida;
    #endregion

    #region Methods
    private void Awake()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();
        cpntSpriteRenderer = GetComponent<SpriteRenderer>();
        cpntAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        recogida = false;
        cpntSpriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            StartCoroutine(CorutinaRecoger());
        }
    }

    private IEnumerator CorutinaRecoger()
    {
        if (!recogida)
        {
            recogida = true;
            cpntAudioSource.Play();
            ctrlNivel.IndicadorPuntuacion.AgregarPuntos(1000);
            cpntSpriteRenderer.enabled = false;
            while (cpntAudioSource.isPlaying)
            {
                yield return null;
            }
            ctrlRepositorio.Guardar(gameObject);
        }
    }
    #endregion    
}
