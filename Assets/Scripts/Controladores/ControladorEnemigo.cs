using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    #region Attributes    
    public float velocidadHorizontal = 1;

    public GameObject objVerificadorTerreno;
    public float radioVerificadorTerreno;
    public LayerMask queEsTerreno;
    
    private ControladorNivel ctrlNivel;
    private ControladorRepositorio ctrlRepositorio;
    private ControladorAvatar ctrlAvatar;
    private bool enTerreno;
    private bool estoyEliminado;
    private bool estoyAtacando;
    private bool moverseDerecha;
    
    private Rigidbody2D cpntRigidBody;
    private BoxCollider2D cpntBoxCollider;
    private Animator cpntAnimator;

    private const string ANIMACION_PARAMETRO_ESTOY_ELIMINADO = "EstoyEliminado";
    private const string ANIMACION_PARAMETRO_ESTOY_ATACANDO = "EstoyAtacando";
    #endregion

    #region Methods
    public void Morir()
    {
        StartCoroutine(CorutinaMorir());
    }

    private void Awake()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();
        ctrlAvatar = FindObjectOfType<ControladorAvatar>();

        cpntRigidBody = GetComponent<Rigidbody2D>();
        cpntBoxCollider = GetComponent<BoxCollider2D>();
        cpntAnimator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        moverseDerecha = Random.Range(0, 2) == 0 ? true : false;
        cpntRigidBody.gravityScale = 5f;
        cpntBoxCollider.enabled = true;
        estoyEliminado = false;
        estoyAtacando = false;
    }

    private void Update()
    {
        if (estoyEliminado || estoyAtacando)
        {
            cpntRigidBody.velocity = new Vector2(0, cpntRigidBody.velocity.y);
            return;
        }

        if (!enTerreno)
        {
            moverseDerecha = !moverseDerecha;
        }

        transform.localScale = new Vector3(moverseDerecha ? 1f : -1f, 1f, 1f);
        cpntRigidBody.velocity = new Vector2(moverseDerecha ? velocidadHorizontal : -velocidadHorizontal, cpntRigidBody.velocity.y);
    }

    private void FixedUpdate()
    {
        enTerreno = Physics2D.OverlapCircle(objVerificadorTerreno.transform.position, radioVerificadorTerreno, queEsTerreno);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Constantes.ETIQUETA_JUGADOR)
        {
            if (!estoyEliminado)
            {
                Atacar();
                ctrlAvatar.Morir();
            }
        }
    }

    private IEnumerator CorutinaMorir()
    {
        ctrlNivel.IndicadorPuntuacion.AgregarPuntos(1000);

        estoyEliminado = true;
        cpntRigidBody.gravityScale = 0f;
        cpntBoxCollider.enabled = false;
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_ESTOY_ELIMINADO, estoyEliminado);

        yield return new WaitForSecondsRealtime(0.3f);

        GameObject objMoneda = ctrlRepositorio.Obtener(Constantes.PREFAB_MONEDA);
        objMoneda.transform.parent = transform.parent;
        objMoneda.transform.localPosition = transform.localPosition;
        objMoneda.SetActive(true);

        ctrlRepositorio.Guardar(gameObject);
    }

    private void Atacar()
    {
        StartCoroutine(CorutinaAtacar());
    }

    private IEnumerator CorutinaAtacar()
    {
        estoyAtacando = true;
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_ESTOY_ATACANDO, estoyAtacando);
        yield return new WaitForSecondsRealtime(1f);
        estoyAtacando = false;
        cpntAnimator.SetBool(ANIMACION_PARAMETRO_ESTOY_ATACANDO, estoyAtacando);
    }
    #endregion
}
