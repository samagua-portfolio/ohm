using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorPadre : MonoBehaviour
{
    #region Methods    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            other.transform.parent = null;
        }
    }
    #endregion
}
