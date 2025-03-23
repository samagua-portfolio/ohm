using UnityEngine;

public class ControladorBonificacion : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    #endregion

    #region Methods
    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
    }

    private void Update()
    {
        if (ctrlNivel.AyudaMostrada)
        {
            if (transform.GetChild(0).gameObject.activeInHierarchy)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
    #endregion
}
