using UnityEngine;

public class ControladorPlataformaMovil : MonoBehaviour
{
    #region Attributes
    public Vector3 posicionInicial;
    public Vector3 posicionFinal;
    public float velocidad;

    private Transform cpntTransformPlataforma;
    private Vector3 posicionObjetivo;
    #endregion

    #region Methods
    private void Start()
    {
        cpntTransformPlataforma = transform.GetChild(0);

        cpntTransformPlataforma.localPosition = posicionInicial;
        posicionObjetivo = posicionFinal;
    }

    private void Update()
    {
        float paso = velocidad * Time.deltaTime;
        cpntTransformPlataforma.localPosition = Vector3.MoveTowards(cpntTransformPlataforma.localPosition, posicionObjetivo, paso);

        if (cpntTransformPlataforma.localPosition == posicionFinal)
        {
            posicionObjetivo = posicionInicial;
        }
        if (cpntTransformPlataforma.localPosition == posicionInicial)
        {
            posicionObjetivo = posicionFinal;
        }
    }
    #endregion
}
