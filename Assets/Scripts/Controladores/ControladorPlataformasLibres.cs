using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlataformasLibres : MonoBehaviour
{
    #region Attributes
    private List<GameObject> objsPlataformasLibres;
    #endregion    

    #region Methods
    private void Start()
    {
        objsPlataformasLibres = new List<GameObject>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            objsPlataformasLibres.Add(transform.GetChild(0).GetChild(i).gameObject);
        }

        UbicarPlataformas();
    }

    private void UbicarPlataformas()
    {
        List<MatrizPosiciones> tablaMatricesPosiciones = MatricesPosiciones.ObtenerInstancia().TablaMatricesPosiciones;

        MatrizPosiciones matrizPosiciones = tablaMatricesPosiciones[Random.Range(0, tablaMatricesPosiciones.Count)];

        for (int i = 0; i < objsPlataformasLibres.Count; i++)
        {
            objsPlataformasLibres[i].SetActive(matrizPosiciones.Matriz[i]);
        }
    }
    #endregion
}
