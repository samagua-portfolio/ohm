using Assets.Scripts.Clases;
using System.Collections;
using UnityEngine;

public class ControladorHabitacion : MonoBehaviour
{
    #region Attributes
    public Vector3 desplazamiento;
    public float velocidad;

    private ControladorNivel ctrlNivel;
    private ControladorRepositorio ctrlRepositorio;
    private GameObject objMetros;
    private GameObject objObjetivo;
    private GameObject objAumentarVoltage;
    private GameObject objDisminuirVoltage;
    private GameObject objAumentarResistencia;
    private GameObject objDisminuirResistencia;
    private GameObject objBarreras;
    private GameObject objMonedas;
    private LeyOhm leyOhm;
    private float corrienteObjetivo;
    private float maximoValorMagnitud;
    private float minimoValorMagnitud;
    private bool movida;

    private Sprite sprtBotonActivo;
    private Sprite sprtBotonInactivo;
    #endregion   

    #region Methods
    public void Actualizar()
    {
        GuardarMonedas();

        if (movida)
        {
            transform.localPosition -= desplazamiento;
            movida = false;
        }

        objBarreras.SetActive(false);

        if (leyOhm == null)
        {
            leyOhm = new LeyOhm();
        }

        leyOhm.Voltage = Random.Range((int)minimoValorMagnitud, (int)(maximoValorMagnitud + 1));
        leyOhm.Resistencia = Random.Range((int)minimoValorMagnitud, (int)(maximoValorMagnitud + 1));
        corrienteObjetivo = leyOhm.ObtenerCorriente();

        do
        {
            leyOhm.Voltage = Random.Range((int)(minimoValorMagnitud + 1), (int)maximoValorMagnitud);
            leyOhm.Resistencia = Random.Range((int)(minimoValorMagnitud + 1), (int)maximoValorMagnitud);
        } while (leyOhm.ObtenerCorriente() == corrienteObjetivo);

        objMetros.GetComponent<ControladorMetros>().Actualizar(leyOhm);
        objObjetivo.GetComponent<ControladorAmperimetro>().EstablecerValor(corrienteObjetivo);

        ActivarBotones(true);
    }

    public void ModificarMagnitud(int identificadorGameObject)
    {
        if (movida)
        {
            return;
        }

        if (objAumentarVoltage.GetInstanceID() == identificadorGameObject)
        {
            if (leyOhm.Voltage < maximoValorMagnitud)
            {
                leyOhm.Voltage = leyOhm.Voltage + 1;
            }
        }
        if (objDisminuirVoltage.GetInstanceID() == identificadorGameObject)
        {
            if (leyOhm.Voltage > minimoValorMagnitud)
            {
                leyOhm.Voltage = leyOhm.Voltage - 1;
            }
        }
        if (objAumentarResistencia.GetInstanceID() == identificadorGameObject)
        {
            if (leyOhm.Resistencia < maximoValorMagnitud)
            {
                leyOhm.Resistencia = leyOhm.Resistencia + 1;
            }
        }
        if (objDisminuirResistencia.GetInstanceID() == identificadorGameObject)
        {
            if (leyOhm.Resistencia > minimoValorMagnitud)
            {
                leyOhm.Resistencia = leyOhm.Resistencia - 1;
            }
        }

        objMetros.GetComponent<ControladorMetros>().Actualizar(leyOhm);

        VerificarBotones();

        if (Mathf.Abs(corrienteObjetivo - leyOhm.ObtenerCorriente()) < 0.01f)
        {
            movida = true;
            ActivarBotones(false);
            ctrlNivel.IndicadorPuntuacion.AgregarPuntos(3000);
            StartCoroutine(CorutinaMover());
        }

    }

    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlRepositorio = FindObjectOfType<ControladorRepositorio>();

        sprtBotonActivo = Resources.Load<Sprite>("Elevador/botonActivo");
        sprtBotonInactivo = Resources.Load<Sprite>("Elevador/botonInactivo");

        objMetros = transform.GetChild(0).gameObject;
        objObjetivo = transform.GetChild(1).gameObject;
        objAumentarVoltage = transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        objDisminuirVoltage = transform.GetChild(2).GetChild(0).GetChild(1).gameObject;
        objAumentarResistencia = transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
        objDisminuirResistencia = transform.GetChild(2).GetChild(1).GetChild(1).gameObject;
        objBarreras = transform.GetChild(3).gameObject;
        objMonedas = transform.GetChild(4).gameObject;

        maximoValorMagnitud = 5f;
        minimoValorMagnitud = 1f;
        movida = false;

        Actualizar();
    }

    private void ActivarBotones(bool activar)
    {
        objAumentarVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = activar ? sprtBotonActivo : sprtBotonInactivo;
        objDisminuirVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = activar ? sprtBotonActivo : sprtBotonInactivo;
        objAumentarResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = activar ? sprtBotonActivo : sprtBotonInactivo;
        objDisminuirResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = activar ? sprtBotonActivo : sprtBotonInactivo;
    }

    private void VerificarBotones()
    {
        if (leyOhm.Voltage == maximoValorMagnitud)
        {
            objAumentarVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonInactivo;
        }
        else
        {
            objAumentarVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonActivo;
        }

        if (leyOhm.Voltage == minimoValorMagnitud)
        {
            objDisminuirVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonInactivo;
        }
        else
        {
            objDisminuirVoltage.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonActivo;
        }

        if (leyOhm.Resistencia == maximoValorMagnitud)
        {
            objAumentarResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonInactivo;
        }
        else
        {
            objAumentarResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonActivo;
        }

        if (leyOhm.Resistencia == minimoValorMagnitud)
        {
            objDisminuirResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonInactivo;
        }
        else
        {
            objDisminuirResistencia.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprtBotonActivo;
        }
    }

    private IEnumerator CorutinaMover()
    {
        Vector3 posicionFinal = transform.localPosition + desplazamiento;
        objBarreras.SetActive(true);

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

        objBarreras.SetActive(false);
        UbicarMonedas();
    }

    private void UbicarMonedas()
    {
        GameObject objtMoneda;
        bool ubicarAbajo = Random.Range(0, 2) == 0 ? true : false;

        for (float i = -3f; i <= 3f; i += 1)
        {
            objtMoneda = ctrlRepositorio.Obtener(Constantes.PREFAB_MONEDA);
            objtMoneda.transform.parent = objMonedas.transform;

            if (ubicarAbajo)
            {
                objtMoneda.transform.localPosition = new Vector3(i, -0.25f, 0f);
            }
            else
            {
                objtMoneda.transform.localPosition = new Vector3(i, 0f, 0f);
            }

            ubicarAbajo = !ubicarAbajo;
            objtMoneda.SetActive(true);
        }
    }

    private void GuardarMonedas()
    {
        GameObject objtMoneda;

        while (objMonedas.transform.childCount > 0)
        {
            objtMoneda = objMonedas.transform.GetChild(0).gameObject;
            ctrlRepositorio.Guardar(objtMoneda);
        }
    }
    #endregion
}
