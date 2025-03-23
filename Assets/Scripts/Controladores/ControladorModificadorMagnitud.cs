using UnityEngine;

public class ControladorModificadorMagnitud : MonoBehaviour
{
    #region Attributes
    private ControladorHabitacion ctrlHabitacion;
    #endregion

    #region Methods
    public void SerImpactado()
    {
        ctrlHabitacion.ModificarMagnitud(gameObject.GetInstanceID());
    }

    private void Start()
    {
        ctrlHabitacion = transform.parent.parent.parent.gameObject.GetComponent<ControladorHabitacion>();
    }
    #endregion
}
