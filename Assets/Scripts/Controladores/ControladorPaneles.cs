using System.Collections.Generic;
using UnityEngine;

public class ControladorPaneles : MonoBehaviour
{
    #region Attributes    
    private List<GameObject> objsPaneles;
    #endregion       

    #region Methods
    public void ActivarPanel(int numeroPanel)
    {
        if (numeroPanel < 0 || numeroPanel >= objsPaneles.Count)
        {
            return;
        }

        objsPaneles[numeroPanel].transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DesactivarPanel(int numeroPanel)
    {
        if (numeroPanel < 0 || numeroPanel >= objsPaneles.Count)
        {
            return;
        }

        objsPaneles[numeroPanel].transform.GetChild(0).gameObject.SetActive(false);
    }

    public bool EstadoPanel(int numeroPanel)
    {
        if (numeroPanel < 0 || numeroPanel >= objsPaneles.Count)
        {
            return false;
        }

        return objsPaneles[numeroPanel].transform.GetChild(0).gameObject.activeInHierarchy;
    }

    public void DesactivarPaneles()
    {
        for (int i = 0; i < objsPaneles.Count; i++)
        {
            objsPaneles[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        objsPaneles = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            objsPaneles.Add(transform.GetChild(i).gameObject);
        }
    }
    #endregion
}
