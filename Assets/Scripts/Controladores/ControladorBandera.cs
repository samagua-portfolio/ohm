using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorBandera : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private ControladorAvatar ctrlAvatar;
    #endregion

    #region Methods
    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlAvatar = FindObjectOfType<ControladorAvatar>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            ctrlNivel.IndicadorPuntuacion.AgregarPuntos(10000);
            ctrlAvatar.AlcanzarMeta();
        }
    }
    #endregion
}
