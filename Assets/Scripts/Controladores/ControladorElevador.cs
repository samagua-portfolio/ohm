using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorElevador : MonoBehaviour
{
    #region Attributes
    private GameObject objHabitacion;
    private GameObject objPlataformas;
    #endregion

    #region Methods
    public void Actualizar()
    {
        TipoPosicion tipoPosicion = Random.Range(0, 2) == 0 ? TipoPosicion.IZQUIERDA : TipoPosicion.DERECHA;

        if (tipoPosicion == TipoPosicion.IZQUIERDA)
        {
            objHabitacion.transform.localPosition = new Vector3(-4.125f, objHabitacion.transform.localPosition.y);
            objPlataformas.transform.localPosition = new Vector3(4.125f, objPlataformas.transform.localPosition.y);
        }
        else
        {
            objHabitacion.transform.localPosition = new Vector3(4.125f, objHabitacion.transform.localPosition.y);
            objPlataformas.transform.localPosition = new Vector3(-4.125f, objPlataformas.transform.localPosition.y);
        }
    }

    private void Start()
    {
        objHabitacion = transform.GetChild(0).gameObject;
        objPlataformas = transform.GetChild(1).gameObject;

        Actualizar();
    }
    #endregion
}
