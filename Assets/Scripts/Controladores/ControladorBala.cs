using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorBala : MonoBehaviour
{
    #region Attributes
    public float velocidadHorizontal;

    private ControladorRepositorio ctrlRepositorio;
    private Rigidbody2D cpntRigidBody;
    private AudioSource cpntAudioSource;
    private Animator cpntAnimator;
    private bool moverseDerecha;
    private bool heExplotado;

    private const string ANIMACION_PARAMETRO_HE_EXPLOTADO = "HeExplotado";
    #endregion

    #region Properties
    public bool MoverseDerecha
    {
        set
        {
            moverseDerecha = value;
        }
    }
    #endregion

    #region Methods
    private void Awake()
    {
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();

        cpntRigidBody = GetComponent<Rigidbody2D>();
        cpntAudioSource = GetComponent<AudioSource>();
        cpntAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        heExplotado = false;
    }

    private void Update()
    {
        if (heExplotado)
        {
            cpntRigidBody.velocity = Vector2.zero;
            return;
        }

        cpntRigidBody.velocity = new Vector2(moverseDerecha ? velocidadHorizontal : -velocidadHorizontal, cpntRigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_ENEMIGO)
        {
            other.GetComponent<ControladorEnemigo>().Morir();
        }

        if (other.tag == Constantes.ETIQUETA_CIRCUITO_LATERAL)
        {
            other.gameObject.GetComponent<ControladorModificadorMagnitud>().SerImpactado();
        }

        if (other.tag == Constantes.ETIQUETA_ENEMIGO
            || other.tag == Constantes.ETIQUETA_MURO_LATERAL
            || other.tag == Constantes.ETIQUETA_CIRCUITO_LATERAL)
        {
            StartCoroutine(CorutinaExplotar());
        }
    }

    private IEnumerator CorutinaExplotar()
    {
        if (!heExplotado)
        {
            heExplotado = true;
            cpntAudioSource.Play();
            cpntAnimator.SetBool(ANIMACION_PARAMETRO_HE_EXPLOTADO, heExplotado);
            yield return new WaitForSecondsRealtime(0.15f);
            ctrlRepositorio.Guardar(gameObject);
        }
    }
    #endregion
}
