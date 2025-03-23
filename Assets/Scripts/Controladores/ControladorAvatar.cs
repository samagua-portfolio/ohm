using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorAvatar : MonoBehaviour
{
    #region Attributes
    public float velocidadHorizontal;
    public float velocidadVertical;
    public GameObject objPuntoDisparo;
    public GameObject objVerificadorTerreno;
    public Vector2 dimensionesVerificadorTerreno;
    public LayerMask queEsTerreno;

    private ControladorNivel ctrlNivel;
    private ControladorRepositorio ctrlRepositorio;
    private SpriteRenderer cpntSpriteRenderer;
    private Rigidbody2D cpntRigidBody;
    private PolygonCollider2D cpntPolygonCollider;
    private Animator cpntAnimator;
    private AudioSource cpntAudioSource;
    private bool moverseDerecha;
    private bool partidaIniciada;
    private bool enTerreno;
    private bool metaAlcanzada;
    private bool estoyEliminado;

    private const string ANIMACION_PARAMETRO_PARTIDA = "PartidaIniciada";
    private const string ANIMACION_PARAMETRO_VELOCIDAD = "Velocidad";
    private const string ANIMACION_PARAMETRO_EN_TERRENO = "EnTerreno";
    private const string ANIMACION_PARAMETRO_PERDER = "EstoyEliminado";
    private const string ANIMACION_PARAMETRO_GANAR = "BanderaAlcanzada";
    #endregion    

    #region Methods
    public void Morir()
    {
        estoyEliminado = true;
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_PERDER, estoyEliminado);
        ctrlNivel.Terminar(metaAlcanzada);
        StartCoroutine(CorutinaDesaparecer());
    }

    public void AlcanzarMeta()
    {
        metaAlcanzada = true;
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_GANAR, metaAlcanzada);
        ctrlNivel.Terminar(metaAlcanzada);
        StartCoroutine(CorutinaDesaparecer());
    }

    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();

        moverseDerecha = true;
        cpntSpriteRenderer = GetComponent<SpriteRenderer>();
        cpntRigidBody = GetComponent<Rigidbody2D>();
        cpntPolygonCollider = GetComponent<PolygonCollider2D>();
        cpntAnimator = GetComponent<Animator>();
        cpntAudioSource = GetComponent<AudioSource>();

        StartCoroutine(CorutinaAparecer());
    }

    private void Update()
    {
        // Arreglar problema con desplazamiento no voluntario
        Correr(0, moverseDerecha);

        // Evitar control del avatar
        if (!partidaIniciada || metaAlcanzada || estoyEliminado)
        {
            return;
        }

        // Correr
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            moverseDerecha = Input.GetKey(KeyCode.RightArrow) ? true : false;
            Correr(velocidadHorizontal, moverseDerecha);
        }

        // Saltar
        if (Input.GetKeyDown(KeyCode.S) && enTerreno)
        {
            Saltar();
        }

        // Disparar
        if (Input.GetKeyDown(KeyCode.D))
        {
            Disparar();
        }

        // Mostrar ayuda
        if (Input.GetKeyDown(KeyCode.A))
        {
            ctrlNivel.MostrarAyuda(!ctrlNivel.MostrandoAyuda);
        }

        // Actualizar condición salto        
        enTerreno = Physics2D.OverlapBox(objVerificadorTerreno.transform.position, dimensionesVerificadorTerreno, 0, queEsTerreno);

        // Animaciones
        cpntAnimator.SetFloat(ANIMACION_PARAMETRO_VELOCIDAD, Mathf.Abs(cpntRigidBody.velocity.x));
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_EN_TERRENO, enTerreno);
    }

    private void Correr(float velocidadHorizontal, bool moverseDerecha)
    {
        Vector2 velocidadAuxiliar = cpntRigidBody.velocity;
        Vector3 escalaAuxiliar = transform.localScale;

        if (moverseDerecha)
        {
            velocidadAuxiliar.x = velocidadHorizontal;
            escalaAuxiliar.x = 1f;
        }
        else
        {
            velocidadAuxiliar.x = -velocidadHorizontal;
            escalaAuxiliar.x = -1f;
        }

        cpntRigidBody.velocity = velocidadAuxiliar;
        transform.localScale = escalaAuxiliar;
    }

    private void Saltar()
    {
        Vector2 velocidadAuxiliar = cpntRigidBody.velocity;
        velocidadAuxiliar.y = velocidadVertical;
        cpntRigidBody.velocity = velocidadAuxiliar;
    }

    private void Disparar()
    {
        cpntAudioSource.Play();
        GameObject objBala = ctrlRepositorio.Obtener(Constantes.PREFAB_BALA);
        if (objBala.name.Contains(Constantes.PREFAB_BALA))
        {
            objBala.GetComponent<ControladorBala>().MoverseDerecha = transform.localScale.x > 0 ? true : false;
        }
        objBala.transform.position = objPuntoDisparo.transform.position;
        objBala.SetActive(true);
    }

    private IEnumerator CorutinaAparecer()
    {
        cpntSpriteRenderer.enabled = false;
        yield return new WaitForSecondsRealtime(0.25f);
        cpntSpriteRenderer.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_PARTIDA, true);
        partidaIniciada = true;
    }

    private IEnumerator CorutinaDesaparecer()
    {
        cpntRigidBody.velocity = Vector2.zero;
        cpntRigidBody.gravityScale = 0f;
        cpntPolygonCollider.enabled = false;
        yield return new WaitForSecondsRealtime(1f);
        cpntSpriteRenderer.enabled = false;
    }
    #endregion
}
