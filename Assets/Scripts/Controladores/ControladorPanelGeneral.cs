using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPanelGeneral : MonoBehaviour
{
    #region Attributes
    private Scrollbar cpntScrollbarBarra;
    #endregion    

    #region Methods
    private void Awake()
    {
        cpntScrollbarBarra = GetComponentInChildren<Scrollbar>();
    }

    private void OnEnable()
    {
        StartCoroutine(CorutinaReiniciar());
    }

    private IEnumerator CorutinaReiniciar()
    {
        yield return null;
        cpntScrollbarBarra.value = 1f;
    }
    #endregion
}
