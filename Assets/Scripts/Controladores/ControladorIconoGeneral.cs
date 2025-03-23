using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControladorIconoGeneral : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Attributes   
    public bool cambiarColor;
    public bool cambiarEscala;

    private GameObject objImagen;
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
        objImagen = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        objImagen.GetComponent<Image>().color = new Color(0.196f, 0.196f, 0.196f);
        objImagen.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    private void Resaltar(bool resaltar)
    {
        if (cambiarColor)
        {
            objImagen.GetComponent<Image>().color = resaltar ? Color.gray : new Color(0.196f, 0.196f, 0.196f);
        }
        if (cambiarEscala)
        {
            objImagen.GetComponent<RectTransform>().localScale = resaltar ? new Vector3(1.25f, 1.25f, 1f) : Vector3.one;
        }
    }
    #endregion    
}
