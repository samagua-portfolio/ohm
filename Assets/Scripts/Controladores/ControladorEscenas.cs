using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour
{
    #region Attributes
    private GameObject objFondo;
    #endregion

    #region Properties
    public void Cargar(string nombreEscena)
    {
        StartCoroutine(CorutinaCargar(nombreEscena));
    }

    private IEnumerator CorutinaCargar(string nombreEscena)
    {
        yield return null;
        objFondo.SetActive(true);

        AsyncOperation ao = SceneManager.LoadSceneAsync(nombreEscena);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }

        objFondo.SetActive(false);
    }

    private void Awake()
    {
        objFondo = transform.GetChild(0).gameObject;
        objFondo.SetActive(false);
    }
    #endregion
}
