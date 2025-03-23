using System.Collections.Generic;
using UnityEngine;

public class ControladorPlataformasVarias : MonoBehaviour
{
    #region Attributes
    private List<GameObject> objsPlataformas;
    private List<Vector3> posiciones;
    #endregion    

    #region Methods
    public void Actualizar()
    {
        int cantidadPosiciones = posiciones.Count;

        while (cantidadPosiciones > 1)
        {
            cantidadPosiciones--;
            int indice = Random.Range(0, cantidadPosiciones + 1);
            Vector3 posicion = posiciones[indice];
            posiciones[indice] = posiciones[cantidadPosiciones];
            posiciones[cantidadPosiciones] = posicion;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            objsPlataformas[i].transform.localPosition = posiciones[i];
        }
    }

    private void Start()
    {
        objsPlataformas = new List<GameObject>();
        posiciones = new List<Vector3>();

        for (int i = 0; i < transform.childCount; i++)
        {
            objsPlataformas.Add(transform.GetChild(i).gameObject);
            posiciones.Add(transform.GetChild(i).localPosition);
        }

        Actualizar();
    }
    #endregion
}
