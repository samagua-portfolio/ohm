using UnityEngine;
using UnityEngine.UI;

public class ControladorLanzamiento : MonoBehaviour
{
    #region Attributes
    private GameObject objLabel;
    #endregion

    #region Methods
    private void Start()
    {
        objLabel = transform.GetChild(0).gameObject;

        EstablecerVersion();
    }

    private void EstablecerVersion()
    {
        objLabel.GetComponent<Text>().text = "release-2025-0323-010000";
    }
    #endregion
}
