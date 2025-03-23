using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    #region Attributes    
    public float distanciaCentroExtremo;

    private Transform cpntTransformAvatar;
    private float aspectoOriginal;
    private float minimaDistanciaSeparacion;
    private float distanciaIzquierda;
    private float distanciaDerecha;
    private float camaraPosicionX;
    private float camaraPosicionY;
    private Vector3 posicionAuxiliar;
    #endregion    

    #region Methods
    private void Start()
    {
        aspectoOriginal = 16f / 9f;
    }

    private void Update()
    {
        if (cpntTransformAvatar == null)
        {
            cpntTransformAvatar = FindObjectOfType<ControladorAvatar>().gameObject.transform;
            return;
        }

        minimaDistanciaSeparacion = (Camera.main.aspect * distanciaCentroExtremo) / aspectoOriginal;
        distanciaIzquierda = Mathf.Abs(cpntTransformAvatar.position.x + distanciaCentroExtremo);
        distanciaDerecha = Mathf.Abs(cpntTransformAvatar.position.x - distanciaCentroExtremo);

        if (distanciaIzquierda > minimaDistanciaSeparacion && distanciaDerecha > minimaDistanciaSeparacion)
        {
            camaraPosicionX = cpntTransformAvatar.position.x;
        }
        else
        {
            if (distanciaIzquierda <= minimaDistanciaSeparacion)
            {
                camaraPosicionX = -(distanciaCentroExtremo - minimaDistanciaSeparacion);
            }
            else
            {
                camaraPosicionX = (distanciaCentroExtremo - minimaDistanciaSeparacion);
            }
        }

        camaraPosicionY = cpntTransformAvatar.position.y + 1;

        if (camaraPosicionY < 0)
        {
            camaraPosicionY = 0;
        }

        posicionAuxiliar = transform.position;
        posicionAuxiliar.x = camaraPosicionX;
        posicionAuxiliar.y = camaraPosicionY;
        transform.position = posicionAuxiliar;
    }
    #endregion
}
