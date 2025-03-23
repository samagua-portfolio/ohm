using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControladorRepositorio : MonoBehaviour
{
    #region Attributes
    public GameObject prefabEnemigo;
    public GameObject prefabBala;
    public GameObject prefabMoneda;
    public GameObject prefabNumeroFlotante;

    private Stack<GameObject> objsEnemigos;
    private Stack<GameObject> objsBalas;
    private Stack<GameObject> objsMonedas;
    private Stack<GameObject> objsNumerosFlotantes;
    #endregion

    #region Methods
    public GameObject Obtener(string nombrePrefab)
    {
        Stack<GameObject> objetos;
        GameObject prefab;

        if (nombrePrefab.Contains(Constantes.PREFAB_ENEMIGO))
        {
            objetos = objsEnemigos;
            prefab = prefabEnemigo;
        }
        else if (nombrePrefab.Contains(Constantes.PREFAB_BALA))
        {
            objetos = objsBalas;
            prefab = prefabBala;
        }
        else if (nombrePrefab.Contains(Constantes.PREFAB_MONEDA))
        {
            objetos = objsMonedas;
            prefab = prefabMoneda;
        }
        else if (nombrePrefab.Contains(Constantes.PREFAB_NUMERO_FLOTANTE))
        {
            objetos = objsNumerosFlotantes;
            prefab = prefabNumeroFlotante;
        }
        else
        {
            return new GameObject();
        }

        if (objetos.Count == 0)
        {
            return Instantiate(prefab, gameObject.transform);
        }
        else
        {
            return objetos.Pop();
        }
    }

    public void Guardar(GameObject objeto)
    {
        Stack<GameObject> objetos;

        if (objeto.name.Contains(Constantes.PREFAB_ENEMIGO))
        {
            objetos = objsEnemigos;
        }
        else if (objeto.name.Contains(Constantes.PREFAB_BALA))
        {
            objetos = objsBalas;
        }
        else if (objeto.name.Contains(Constantes.PREFAB_MONEDA))
        {
            objetos = objsMonedas;
        }
        else if (objeto.name.Contains(Constantes.PREFAB_NUMERO_FLOTANTE))
        {
            objetos = objsNumerosFlotantes;
        }
        else
        {
            Destroy(objeto);
            return;
        }

        objeto.SetActive(false);
        objeto.transform.parent = transform;
        objetos.Push(objeto);
    }

    private void Awake()
    {
        objsEnemigos = new Stack<GameObject>();
        objsBalas = new Stack<GameObject>();
        objsMonedas = new Stack<GameObject>();
        objsNumerosFlotantes = new Stack<GameObject>();
    }

    internal GameObject Obtener(object constanes)
    {
        throw new NotImplementedException();
    }
    #endregion
}
