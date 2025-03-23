using UnityEngine;

public class ControladorFragmentoCentral : MonoBehaviour
{
    #region Attributes
    private GameObject objPlataformasFijas;
    private GameObject objTribuna;
    private GameObject objElevador;
    private GameObject objPlataformasVarias;
    private GameObject objCelda;
    private GameObject objHabitacion;
    #endregion

    #region Methods
    public void Actualizar()
    {
        objElevador.GetComponent<ControladorElevador>().Actualizar();
        objPlataformasFijas.GetComponent<ControladorPlataformasFijas>().Actualizar();
        objPlataformasVarias.GetComponent<ControladorPlataformasVarias>().Actualizar();
        objCelda.GetComponent<ControladorCelda>().Actualizar();
        objHabitacion.GetComponent<ControladorHabitacion>().Actualizar();
    }

    private void Start()
    {
        objTribuna = transform.GetChild(0).gameObject;
        objElevador = transform.GetChild(1).gameObject;
        objPlataformasFijas = transform.GetChild(2).gameObject;        
        objPlataformasVarias = transform.GetChild(3).gameObject;
        objCelda = objTribuna.transform.GetChild(0).gameObject;
        objHabitacion = objElevador.transform.GetChild(0).gameObject;
    }
    #endregion
}
