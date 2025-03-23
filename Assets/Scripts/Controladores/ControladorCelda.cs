using UnityEngine;

public class ControladorCelda : MonoBehaviour
{
    #region Attributes
    private GameObject objResistor;
    private GameObject objBarrera;
    #endregion

    #region Properties
    public GameObject Barrera
    {
        get
        {
            return objBarrera;
        }
    }
    #endregion

    #region Methods
    public void Actualizar()
    {
        objResistor.GetComponent<ControladorResistor>().Establecer();
        objBarrera.GetComponent<ControladorBarrera>().Activar();
    }

    private void Start()
    {
        objResistor = transform.GetChild(0).gameObject;
        objBarrera = transform.GetChild(1).gameObject;
    }
    #endregion
}
