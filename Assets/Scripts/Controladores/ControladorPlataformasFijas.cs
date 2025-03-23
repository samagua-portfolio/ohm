using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlataformasFijas : MonoBehaviour
{
    #region Attributes
    private ControladorRepositorio ctrlRepositorio;
    private List<GameObject> objsPlataformasInferiores;
    private List<GameObject> objsPlataformasSuperiores;
    private List<GameObject> objsPlataformasActivas;
    #endregion

    #region Methods
    public void Actualizar()
    {
        GuardarObjetos();
        UbicarPlataformas();

        if (PlayerPrefs.HasKey(Constantes.PREFERENCIA_DIFICULTAD))
        {
            TipoDificultad tipoDificultadActual = (TipoDificultad)PlayerPrefs.GetInt(Constantes.PREFERENCIA_DIFICULTAD);

            if (tipoDificultadActual == TipoDificultad.FACIL)
            {
                UbicarObjetos(Constantes.PREFAB_ENEMIGO, 2);
            }
            if (tipoDificultadActual == TipoDificultad.NORMAL)
            {
                UbicarObjetos(Constantes.PREFAB_ENEMIGO, 3);
            }
            if (tipoDificultadActual == TipoDificultad.DIFICIL)
            {
                UbicarObjetos(Constantes.PREFAB_ENEMIGO, 4);
            }
        }
        else
        {
            UbicarObjetos(Constantes.PREFAB_ENEMIGO, 4);
        }
    }

    private void Start()
    {
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();

        objsPlataformasInferiores = new List<GameObject>();
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            objsPlataformasInferiores.Add(transform.GetChild(0).GetChild(i).gameObject);
        }

        objsPlataformasSuperiores = new List<GameObject>();
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            objsPlataformasSuperiores.Add(transform.GetChild(1).GetChild(i).gameObject);
        }

        Actualizar();
    }

    private void GuardarObjetos()
    {
        GameObject objObjetos;
        GameObject objObjeto;

        for (int i = 0; i < objsPlataformasInferiores.Count; i++)
        {
            objObjetos = objsPlataformasInferiores[i].transform.GetChild(0).gameObject;

            while (objObjetos.transform.childCount > 0)
            {
                objObjeto = objObjetos.transform.GetChild(0).gameObject;
                ctrlRepositorio.Guardar(objObjeto);
            }
        }

        for (int i = 0; i < objsPlataformasSuperiores.Count; i++)
        {
            objObjetos = objsPlataformasSuperiores[i].transform.GetChild(0).gameObject;

            while (objObjetos.transform.childCount > 0)
            {
                objObjeto = objObjetos.transform.GetChild(0).gameObject;
                ctrlRepositorio.Guardar(objObjeto);
            }
        }
    }

    private void UbicarPlataformas()
    {
        objsPlataformasActivas = new List<GameObject>();
        List<MatrizPosiciones> tablaMatricesPosiciones = MatricesPosiciones.ObtenerInstancia().TablaMatricesPosiciones;

        MatrizPosiciones matrizPosiciones = tablaMatricesPosiciones[Random.Range(0, tablaMatricesPosiciones.Count)];

        for (int i = 0; i < objsPlataformasInferiores.Count; i++)
        {
            objsPlataformasInferiores[i].SetActive(matrizPosiciones.Matriz[i]);
            if (objsPlataformasInferiores[i].activeInHierarchy)
            {
                objsPlataformasActivas.Add(objsPlataformasInferiores[i]);
            }
        }

        matrizPosiciones = tablaMatricesPosiciones[Random.Range(0, tablaMatricesPosiciones.Count)];

        for (int i = 0; i < objsPlataformasSuperiores.Count; i++)
        {
            objsPlataformasSuperiores[i].SetActive(matrizPosiciones.Matriz[i]);
            if (objsPlataformasSuperiores[i].activeInHierarchy)
            {
                objsPlataformasActivas.Add(objsPlataformasSuperiores[i]);
            }
        }
    }

    private void UbicarObjetos(string nombrePrefab, int cantidad)
    {
        GameObject objObjeto;

        if (cantidad < 0 || cantidad > objsPlataformasActivas.Count)
        {
            cantidad = objsPlataformasActivas.Count;
        }
        else
        {
            int cantidadPlataformasActivas = objsPlataformasActivas.Count;

            while (cantidadPlataformasActivas > 1)
            {
                cantidadPlataformasActivas--;
                int indice = Random.Range(0, cantidadPlataformasActivas + 1);
                objObjeto = objsPlataformasActivas[indice];
                objsPlataformasActivas[indice] = objsPlataformasActivas[cantidadPlataformasActivas];
                objsPlataformasActivas[cantidadPlataformasActivas] = objObjeto;
            }
        }

        for (int i = 0; i < cantidad; i++)
        {
            objObjeto = ctrlRepositorio.Obtener(nombrePrefab);
            objObjeto.transform.SetParent(objsPlataformasActivas[i].transform.GetChild(0));
            objObjeto.transform.localPosition = new Vector3(0, 0.48f, 0);
            objObjeto.SetActive(true);
        }
    }
    #endregion
}
