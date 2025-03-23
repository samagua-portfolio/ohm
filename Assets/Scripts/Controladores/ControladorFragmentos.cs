using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFragmentos : MonoBehaviour
{
    #region Attributes
    public int cantidadFragmentos;
    public float valorSeparacion;

    private int cantidadFragmentosGenerados;
    private GameObject objFragmentoFinal;
    private Queue<GameObject> objsFragmentosCentrales;
    private BoxCollider2D cpntBoxCollider;

    #endregion

    #region Methods
    private void Start()
    {
        if (cantidadFragmentos < 3 || cantidadFragmentos > 99)
        {
            cantidadFragmentos = 3;
        }

        cantidadFragmentosGenerados = 3;

        objFragmentoFinal = transform.GetChild(1).gameObject;
        objFragmentoFinal.transform.localPosition = new Vector3(objFragmentoFinal.transform.localPosition.x, valorSeparacion * cantidadFragmentos);
        objsFragmentosCentrales = GenerarFragmentosCentrales();

        cpntBoxCollider = GetComponent<BoxCollider2D>();
        cpntBoxCollider.offset = new Vector2(cpntBoxCollider.offset.x, cpntBoxCollider.offset.y + (valorSeparacion * 2));
    }

    private Queue<GameObject> GenerarFragmentosCentrales()
    {
        Queue<GameObject> objsFragmentos = new Queue<GameObject>();
        GameObject objFragmentoCentralBase = transform.GetChild(0).GetChild(0).gameObject;
        GameObject objFragmentoCentral;
        Vector3 posicionAuxiliar;

        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                objFragmentoCentral = objFragmentoCentralBase;
            }
            else
            {
                objFragmentoCentral = Instantiate(objFragmentoCentralBase);
                objFragmentoCentral.transform.parent = objFragmentoCentralBase.transform.parent;
            }

            posicionAuxiliar = objFragmentoCentralBase.transform.localPosition;
            posicionAuxiliar.y += valorSeparacion * i;
            objFragmentoCentral.transform.localPosition = posicionAuxiliar;

            objsFragmentos.Enqueue(objFragmentoCentral);
        }

        return objsFragmentos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            MoverFragmento();
        }
    }

    private void MoverFragmento()
    {
        if (cantidadFragmentosGenerados == cantidadFragmentos)
        {
            return;
        }

        GameObject objFragmentoCentral;
        Vector3 posicionAuxiliar;

        objFragmentoCentral = objsFragmentosCentrales.Dequeue();
        posicionAuxiliar = objFragmentoCentral.transform.localPosition;
        posicionAuxiliar.y += valorSeparacion * 3;
        objFragmentoCentral.transform.localPosition = posicionAuxiliar;
        objFragmentoCentral.GetComponent<ControladorFragmentoCentral>().Actualizar();
        objsFragmentosCentrales.Enqueue(objFragmentoCentral);

        cpntBoxCollider.offset = new Vector2(cpntBoxCollider.offset.x, cpntBoxCollider.offset.y + valorSeparacion);
        cantidadFragmentosGenerados++;
    }
    #endregion
}
