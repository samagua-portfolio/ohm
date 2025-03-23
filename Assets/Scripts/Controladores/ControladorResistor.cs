using Assets.Scripts.Clases;
using UnityEngine;

public class ControladorResistor : MonoBehaviour
{
    #region Attributes    
    private ControladorNivel ctrlNivel;
    private ControladorCelda ctrlCelda;

    private GameObject objBandas;
    private GameObject objIndicador;
    private GameObject objBandaUno;
    private GameObject objBandaDos;
    private GameObject objBandaTres;
    private GameObject objBandaCuatro;
    private GameObject objBandaCinco;
    private GameObject objBandaSeis;
    private int cantidadBandas;
    private Resistencia resistor;
    #endregion    

    #region Methods
    public void Establecer()
    {
        if (PlayerPrefs.HasKey(Constantes.PREFERENCIA_DIFICULTAD))
        {
            TipoDificultad tipoDificultadActual = (TipoDificultad)PlayerPrefs.GetInt(Constantes.PREFERENCIA_DIFICULTAD);

            if (tipoDificultadActual == TipoDificultad.FACIL)
            {
                cantidadBandas = 3;
            }
            if (tipoDificultadActual == TipoDificultad.NORMAL)
            {
                cantidadBandas = Random.Range(4, 6);
            }
            if (tipoDificultadActual == TipoDificultad.DIFICIL)
            {
                cantidadBandas = 6;
            }
        }
        else
        {
            cantidadBandas = 3;
        }

        resistor = Resistencia.Generar(cantidadBandas);

        if (cantidadBandas == 3)
        {
            objBandaUno.GetComponent<ControladorBanda>().Establecer(null, false);
            objBandaDos.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[1], true);
            objBandaTres.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[2], true);
            objBandaCuatro.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[3], true);
            objBandaCinco.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[4], false);
            objBandaSeis.GetComponent<ControladorBanda>().Establecer(null, false);
        }

        if (cantidadBandas == 4)
        {
            objBandaUno.GetComponent<ControladorBanda>().Establecer(null, false);
            objBandaDos.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[1], true);
            objBandaTres.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[2], true);
            objBandaCuatro.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[3], true);
            objBandaCinco.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[4], true);
            objBandaSeis.GetComponent<ControladorBanda>().Establecer(null, false);
        }

        if (cantidadBandas == 5)
        {
            objBandaUno.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[1], true);
            objBandaDos.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[2], true);
            objBandaTres.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[3], true);
            objBandaCuatro.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[4], true);
            objBandaCinco.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[5], true);
            objBandaSeis.GetComponent<ControladorBanda>().Establecer(null, false);
        }

        if (cantidadBandas == 6)
        {
            objBandaUno.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[1], true);
            objBandaDos.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[2], true);
            objBandaTres.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[3], true);
            objBandaCuatro.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[4], true);
            objBandaCinco.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[5], true);
            objBandaSeis.GetComponent<ControladorBanda>().Establecer(resistor.Bandas[6], true);
        }

        objIndicador.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.4f);
    }

    public void VerificarColores()
    {
        if (!objBandaUno.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }
        if (!objBandaDos.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }
        if (!objBandaTres.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }
        if (!objBandaCuatro.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }
        if (!objBandaCinco.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }
        if (!objBandaSeis.GetComponent<ControladorBanda>().EsCorrectoColor)
        {
            return;
        }

        objBandaUno.GetComponent<ControladorBanda>().Modificable = false;
        objBandaDos.GetComponent<ControladorBanda>().Modificable = false;
        objBandaTres.GetComponent<ControladorBanda>().Modificable = false;
        objBandaCuatro.GetComponent<ControladorBanda>().Modificable = false;
        objBandaCinco.GetComponent<ControladorBanda>().Modificable = false;
        objBandaSeis.GetComponent<ControladorBanda>().Modificable = false;

        ctrlNivel.IndicadorPuntuacion.AgregarPuntos(1000 * cantidadBandas);

        ctrlCelda.Barrera.GetComponent<ControladorBarrera>().Desactivar();
        objIndicador.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.4f);
    }

    private void Awake()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlCelda = transform.parent.gameObject.GetComponent<ControladorCelda>();

        objBandas = transform.GetChild(0).gameObject;
        objIndicador = transform.GetChild(1).gameObject;
        objBandaUno = objBandas.transform.GetChild(0).gameObject;
        objBandaDos = objBandas.transform.GetChild(1).gameObject;
        objBandaTres = objBandas.transform.GetChild(2).gameObject;
        objBandaCuatro = objBandas.transform.GetChild(3).gameObject;
        objBandaCinco = objBandas.transform.GetChild(5).gameObject;
        objBandaSeis = objBandas.transform.GetChild(6).gameObject;

        Establecer();
    }
    #endregion
}
