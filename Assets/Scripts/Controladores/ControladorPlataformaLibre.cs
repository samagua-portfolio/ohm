using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorPlataformaLibre : MonoBehaviour
{
    #region Attributes
    private Vector3 posicionInicial;
    private Rigidbody2D cpntRigidBody;
    private BoxCollider2D cpntBoxColliderCuerpo;
    #endregion    

    #region Methods
    private void Start()
    {
        cpntRigidBody = GetComponent<Rigidbody2D>();
        posicionInicial = transform.localPosition;
        cpntBoxColliderCuerpo = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            StartCoroutine(CorutinaCaer());
        }
    }

    private IEnumerator CorutinaCaer()
    {
        yield return new WaitForSecondsRealtime(1f);
        cpntRigidBody.isKinematic = false;
        cpntBoxColliderCuerpo.enabled = false;
        yield return new WaitForSecondsRealtime(5f);
        cpntRigidBody.velocity = Vector3.zero;
        cpntRigidBody.isKinematic = true;
        cpntBoxColliderCuerpo.enabled = true;
        transform.localPosition = posicionInicial;
    }
    #endregion
}
