using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTextoCombate : MonoBehaviour
{
    #region Attributes
    private ControladorRepositorio ctrlRepositorio;
    private Transform cpntTransformJugador;
    private List<Vector3> escalas;
    #endregion    

    #region Methods
    public void Mostrar(int puntos)
    {
        GameObject objNumeroFlotante = ctrlRepositorio.Obtener(Constantes.PREFAB_NUMERO_FLOTANTE);
        if (objNumeroFlotante.name.Contains(Constantes.PREFAB_NUMERO_FLOTANTE))
        {
            objNumeroFlotante.GetComponent<ControladorNumeroFlotante>().Puntos = puntos;
        }
        objNumeroFlotante.transform.parent = transform;
        objNumeroFlotante.transform.localPosition = Vector3.zero;
        objNumeroFlotante.SetActive(true);
    }

    private void Start()
    {
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();
        cpntTransformJugador = transform.parent;
        escalas = new List<Vector3>();
        escalas.Add(Vector3.one);
        escalas.Add(new Vector3(-1, 1, 1));
    }

    private void Update()
    {
        transform.localScale = cpntTransformJugador.localScale.x > 0 ? escalas[0] : escalas[1];
    }
    #endregion
}
