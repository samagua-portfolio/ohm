using UnityEngine;
using UnityEngine.UI;

public class ControladorIndicadorPuntuacion : MonoBehaviour
{
    #region Attributes
    private ControladorTextoCombate ctrlTextoCombate;
    private Text cpntTextoEtiqueta;
    private Text cpntTextoValor;
    private int puntos;
    #endregion

    #region Properties
    public int Puntos
    {
        get
        {
            return puntos;
        }
    }
    #endregion

    #region Methods
    public void AgregarPuntos(int puntosAgregar)
    {
        puntosAgregar = Mathf.Abs(puntosAgregar);

        if (ctrlTextoCombate != null)
        {
            ctrlTextoCombate.Mostrar(puntosAgregar);
        }

        puntos += puntosAgregar;

        if (puntos > 999999)
        {
            puntos = 999999;
        }

        Establecer();
    }

    private void Start()
    {
        ctrlTextoCombate = FindObjectOfType<ControladorTextoCombate>();
        cpntTextoEtiqueta = transform.GetChild(0).gameObject.GetComponent<Text>();
        cpntTextoValor = transform.GetChild(1).gameObject.GetComponent<Text>();

        cpntTextoEtiqueta.color = Color.white;
        cpntTextoValor.color = Color.white;

        puntos = 0;
        Establecer();
    }

    private void Establecer()
    {
        cpntTextoValor.text = puntos.ToString().PadLeft(6, '0');
    }
    #endregion
}
