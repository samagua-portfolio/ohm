using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControladorBotonGeneral : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Attributes
    private GameObject objTexto;
    #endregion    

    #region Methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        Resaltar(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Resaltar(false);
    }

    private void Awake()
    {
        objTexto = GetComponentInChildren<Text>().gameObject;
    }

    private void OnEnable()
    {
        objTexto.GetComponentInChildren<Text>().fontStyle = FontStyle.Normal;
    }

    private void Resaltar(bool resaltar)
    {
        objTexto.GetComponentInChildren<Text>().fontStyle = resaltar ? FontStyle.Bold : FontStyle.Normal;
    }
    #endregion    
}