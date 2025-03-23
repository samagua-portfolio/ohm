using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNumeroFlotante : MonoBehaviour
{
    #region Attributes
    private ControladorRepositorio ctrlRepositorio;
    private GameObject objContenido;
    private List<GameObject> objsDigitos;
    private static Sprite[] sprtsNumeros;
    private int puntos;
    #endregion

    #region Properties
    public int Puntos
    {
        set
        {
            puntos = value;
        }
    }
    #endregion

    #region Methods
    private void Awake()
    {
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();
        objContenido = transform.GetChild(0).gameObject;
        objsDigitos = new List<GameObject>();
        objsDigitos.Add(objContenido.transform.GetChild(1).gameObject);
        objsDigitos.Add(objContenido.transform.GetChild(2).gameObject);
        objsDigitos.Add(objContenido.transform.GetChild(3).gameObject);
        objsDigitos.Add(objContenido.transform.GetChild(4).gameObject);
        objsDigitos.Add(objContenido.transform.GetChild(5).gameObject);

        if (sprtsNumeros == null)
        {
            sprtsNumeros = Resources.LoadAll<Sprite>("Otros/numeros");
        }
    }

    private void OnEnable()
    {
        StartCoroutine(CorutinaMostrar());
    }

    private IEnumerator CorutinaMostrar()
    {
        yield return null;

        if (puntos > 0 && puntos < 100000)
        {
            Vector3 posicionFinal = transform.localPosition + (0.75f * Vector3.up);
            float velocidad = 1.5f;
            char[] cadena = puntos.ToString().ToCharArray();

            for (int i = 0; i < objsDigitos.Count; i++)
            {
                if (i < cadena.Length)
                {
                    objsDigitos[i].GetComponent<SpriteRenderer>().sprite = sprtsNumeros[(int)char.GetNumericValue(cadena[i])];
                }
                else
                {
                    objsDigitos[i].GetComponent<SpriteRenderer>().sprite = null;
                }
            }

            while (true)
            {
                float paso = velocidad * Time.deltaTime;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, posicionFinal, paso);

                if (transform.localPosition == posicionFinal)
                {
                    break;
                }

                yield return null;
            }
        }

        ctrlRepositorio.Guardar(gameObject);
    }
    #endregion
}
