using UnityEngine;
using UnityEngine.EventSystems;

public class ControladorJuego : MonoBehaviour
{
    #region Attributes
    private static ControladorJuego ctrlJuego;
    #endregion

    #region Methods
    private void Awake()
    {
        if (ctrlJuego == null)
        {
            ctrlJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (ctrlJuego != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    #endregion
}
