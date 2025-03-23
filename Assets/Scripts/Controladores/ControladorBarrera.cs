using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorBarrera : MonoBehaviour
{
    #region Attributes    
    private ControladorRepositorio ctrlRepositorio;

    private GameObject objCampoEnergia;
    private GameObject objGrupoAmigos;
    private GameObject objMonedas;
    private GameObject objMensaje;

    private static Sprite[] sprtsMensajes;
    private const string ANIMACION_PARAMETRO_RESCATADOS = "Rescatados";
    #endregion

    #region Methods
    public void Activar()
    {
        objCampoEnergia.SetActive(true);
        objGrupoAmigos.SetActive(true);
        objMensaje.SetActive(false);

        GuardarMonedas();
    }

    public void Desactivar()
    {
        StartCoroutine(CorutinaDesactivar());
    }

    private void Start()
    {
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();

        objCampoEnergia = transform.GetChild(0).gameObject;
        objGrupoAmigos = transform.GetChild(1).gameObject;
        objMonedas = transform.GetChild(2).gameObject;
        objMensaje = objGrupoAmigos.transform.GetChild(0).gameObject;


        objMensaje.SetActive(false);

        if (sprtsMensajes == null)
        {
            sprtsMensajes = Resources.LoadAll<Sprite>("Amigos/mensajes");
        }

        Activar();
    }

    private IEnumerator CorutinaDesactivar()
    {
        objCampoEnergia.SetActive(false);
        objGrupoAmigos.GetComponent<Animator>().SetBool(ANIMACION_PARAMETRO_RESCATADOS, true);
        objMensaje.GetComponent<SpriteRenderer>().sprite = sprtsMensajes[Random.Range(0, sprtsMensajes.Length)];
        objMensaje.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        objGrupoAmigos.SetActive(false);

        UbicarMonedas();
    }

    private void UbicarMonedas()
    {
        GameObject objtMoneda;
        bool ubicarAbajo = Random.Range(0, 2) == 0 ? true : false;

        for (float i = -1f; i <= 1f; i += 1f)
        {
            objtMoneda = ctrlRepositorio.Obtener(Constantes.PREFAB_MONEDA);
            objtMoneda.transform.parent = objMonedas.transform;

            if (ubicarAbajo)
            {
                objtMoneda.transform.localPosition = new Vector3(i, -0.25f, 0f);
            }
            else
            {
                objtMoneda.transform.localPosition = new Vector3(i, 0f, 0f);
            }

            ubicarAbajo = !ubicarAbajo;
            objtMoneda.SetActive(true);
        }
    }

    private void GuardarMonedas()
    {
        GameObject objtMoneda;

        while (objMonedas.transform.childCount > 0)
        {
            objtMoneda = objMonedas.transform.GetChild(0).gameObject;
            ctrlRepositorio.Guardar(objtMoneda);
        }
    }
    #endregion
}
