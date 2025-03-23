using Assets.Scripts.Clases;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBanda : MonoBehaviour
{
    #region Attributes
    private ControladorNivel ctrlNivel;
    private ControladorResistor ctrlResistor;

    private Banda banda;
    private int numeroColorActual;
    private TipoColor tipoColorActual;
    private bool modificable;
    private bool esCorrectoColor;
    private bool mostrandoValor;

    private AudioSource cpntAudioSource;
    private SpriteRenderer cpntSpriteRenderer;
    private SpriteRenderer cpntSpriteRendererConstante;
    private SpriteRenderer cpntSpriteRendererTexto;
    //private SpriteRenderer cpntSpriteRendererConstanteObjetivo;
    private SpriteRenderer cpntSpriteRendererTextoObjetivo;

    private static Dictionary<TipoBanda, Dictionary<string, Sprite>> sprtsCodigoColores;
    #endregion

    #region Properties
    public bool EsCorrectoColor
    {
        get
        {
            return esCorrectoColor;
        }
    }

    public bool Modificable
    {
        set
        {
            modificable = value;
        }
        get
        {
            return modificable;
        }
    }
    #endregion

    #region Methods
    public void Establecer(Banda parametroBanda, bool parametroModificable)
    {
        if (sprtsCodigoColores == null)
        {
            sprtsCodigoColores = ObtenerSprites();
        }

        banda = parametroBanda;
        modificable = parametroModificable;
        cpntSpriteRenderer = GetComponent<SpriteRenderer>();

        if (banda == null)
        {
            esCorrectoColor = true;
            cpntSpriteRenderer.color = Color.clear;

            cpntSpriteRendererConstante = null;
            cpntSpriteRendererTexto = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            cpntSpriteRendererTexto.sprite = null;

            //cpntSpriteRendererConstanteObjetivo = null;
            cpntSpriteRendererTextoObjetivo = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
            cpntSpriteRendererTextoObjetivo.sprite = null;
        }
        else
        {
            if (banda.TipoBanda != TipoBanda.MULTIPLICADOR)
            {
                cpntSpriteRendererConstante = null;
                cpntSpriteRendererTexto = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

                //cpntSpriteRendererConstanteObjetivo = null;
                cpntSpriteRendererTextoObjetivo = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
            }
            else
            {
                cpntSpriteRendererConstante = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
                cpntSpriteRendererTexto = transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>();

                //cpntSpriteRendererConstanteObjetivo = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
                cpntSpriteRendererTextoObjetivo = transform.GetChild(1).GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            }

            if (modificable == true)
            {
                esCorrectoColor = false;

                do
                {
                    tipoColorActual = (TipoColor)Random.Range(2, 15);
                } while (tipoColorActual == banda.TipoColor);
                numeroColorActual = (int)tipoColorActual;
                cpntSpriteRenderer.color = CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColorActual].Color;

                try
                {
                    cpntSpriteRendererTexto.sprite = sprtsCodigoColores[banda.TipoBanda][ObtenerTexto(banda.TipoBanda, tipoColorActual)];
                    cpntSpriteRendererTexto.color = ObtenerColorTexto(tipoColorActual);
                    if (cpntSpriteRendererConstante != null)
                    {
                        cpntSpriteRendererConstante.enabled = true;
                        cpntSpriteRendererConstante.color = ObtenerColorTexto(tipoColorActual);
                    }
                }
                catch
                {
                    cpntSpriteRendererTexto.sprite = null;
                    if (cpntSpriteRendererConstante != null)
                    {
                        cpntSpriteRendererConstante.enabled = false;
                    }
                }

                cpntSpriteRendererTextoObjetivo.sprite = sprtsCodigoColores[banda.TipoBanda][banda.Valor];
            }
            else
            {
                esCorrectoColor = true;

                cpntSpriteRenderer.color = Color.clear;

                cpntSpriteRendererTexto.sprite = sprtsCodigoColores[banda.TipoBanda][banda.Valor];
                cpntSpriteRendererTexto.color = Color.black;

                cpntSpriteRendererTextoObjetivo.sprite = sprtsCodigoColores[banda.TipoBanda][banda.Valor];
            }
        }
    }

    private void Start()
    {
        ctrlNivel = FindObjectOfType<ControladorNivel>();
        ctrlResistor = transform.parent.parent.GetComponent<ControladorResistor>();
        cpntAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        mostrandoValor = ctrlNivel.MostrandoAyuda;

        if (cpntSpriteRendererTexto != null)
        {
            if (cpntSpriteRendererTexto.enabled != mostrandoValor)
            {
                cpntSpriteRendererTexto.enabled = mostrandoValor;
            }
        }
        if (cpntSpriteRendererConstante != null)
        {
            if (cpntSpriteRendererConstante.enabled != mostrandoValor)
            {
                cpntSpriteRendererConstante.enabled = mostrandoValor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constantes.ETIQUETA_JUGADOR)
        {
            if (modificable)
            {
                CambiarColor();
            }
        }
    }

    private void CambiarColor()
    {
        cpntAudioSource.Play();
        numeroColorActual++;

        if (numeroColorActual > 14)
        {
            numeroColorActual = 2;
        }
        if (numeroColorActual < 2)
        {
            numeroColorActual = 14;
        }

        tipoColorActual = (TipoColor)numeroColorActual;
        cpntSpriteRenderer.color = CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColorActual].Color;

        try
        {
            cpntSpriteRendererTexto.sprite = sprtsCodigoColores[banda.TipoBanda][ObtenerTexto(banda.TipoBanda, tipoColorActual)];
            cpntSpriteRendererTexto.color = ObtenerColorTexto(tipoColorActual);
            if (cpntSpriteRendererConstante != null)
            {
                cpntSpriteRendererConstante.enabled = true;
                cpntSpriteRendererConstante.color = ObtenerColorTexto(tipoColorActual);
            }
        }
        catch
        {
            cpntSpriteRendererTexto.sprite = null;
            if (cpntSpriteRendererConstante != null)
            {
                cpntSpriteRendererConstante.enabled = false;
            }
        }

        if (tipoColorActual == banda.TipoColor)
        {
            esCorrectoColor = true;
        }
        else
        {
            esCorrectoColor = false;
        }
        ctrlResistor.VerificarColores();
    }

    private string ObtenerTexto(TipoBanda tipoBanda, TipoColor tipoColor)
    {
        if (tipoBanda == TipoBanda.DIGITO)
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColor].Digito;
        }
        if (tipoBanda == TipoBanda.MULTIPLICADOR)
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColor].Multiplicador;
        }
        if (tipoBanda == TipoBanda.TOLERANCIA)
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColor].Tolerancia;
        }
        if (tipoBanda == TipoBanda.COEFICIENTE_TEMPERATURA)
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[tipoColor].CoeficienteTemperatura;
        }
        return string.Empty;
    }

    private Color ObtenerColorTexto(TipoColor tipoColor)
    {
        if (tipoColor == TipoColor.NEGRO || tipoColor == TipoColor.CAFE || tipoColor == TipoColor.ROJO || tipoColor == TipoColor.AZUL || tipoColor == TipoColor.VIOLETA)
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.BLANCO].Color;
        }
        else
        {
            return CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NEGRO].Color;
        }
    }

    private Dictionary<TipoBanda, Dictionary<string, Sprite>> ObtenerSprites()
    {
        Sprite[] sprts = Resources.LoadAll<Sprite>("Resistor/imgCodigoColores");
        Dictionary<TipoBanda, Dictionary<string, Sprite>> sprtsCodigoColores = new Dictionary<TipoBanda, Dictionary<string, Sprite>>();
        sprtsCodigoColores.Add(TipoBanda.DIGITO, new Dictionary<string, Sprite>());
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NEGRO].Digito, sprts[0]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.CAFE].Digito, sprts[1]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.ROJO].Digito, sprts[2]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NARANJA].Digito, sprts[3]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AMARILLO].Digito, sprts[4]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VERDE].Digito, sprts[5]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AZUL].Digito, sprts[6]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VIOLETA].Digito, sprts[7]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.GRIS].Digito, sprts[8]);
        sprtsCodigoColores[TipoBanda.DIGITO].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.BLANCO].Digito, sprts[9]);

        sprtsCodigoColores.Add(TipoBanda.MULTIPLICADOR, new Dictionary<string, Sprite>());
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.ROSA].Multiplicador, sprts[10]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.PLATEADO].Multiplicador, sprts[11]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.DORADO].Multiplicador, sprts[12]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NEGRO].Multiplicador, sprts[13]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.CAFE].Multiplicador, sprts[14]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.ROJO].Multiplicador, sprts[15]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NARANJA].Multiplicador, sprts[16]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AMARILLO].Multiplicador, sprts[17]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VERDE].Multiplicador, sprts[18]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AZUL].Multiplicador, sprts[19]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VIOLETA].Multiplicador, sprts[20]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.GRIS].Multiplicador, sprts[21]);
        sprtsCodigoColores[TipoBanda.MULTIPLICADOR].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.BLANCO].Multiplicador, sprts[22]);

        sprtsCodigoColores.Add(TipoBanda.TOLERANCIA, new Dictionary<string, Sprite>());
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NINGUNO].Tolerancia, sprts[23]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.PLATEADO].Tolerancia, sprts[24]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.DORADO].Tolerancia, sprts[25]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.CAFE].Tolerancia, sprts[26]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.ROJO].Tolerancia, sprts[27]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VERDE].Tolerancia, sprts[28]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AZUL].Tolerancia, sprts[29]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VIOLETA].Tolerancia, sprts[30]);
        sprtsCodigoColores[TipoBanda.TOLERANCIA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.GRIS].Tolerancia, sprts[31]);

        sprtsCodigoColores.Add(TipoBanda.COEFICIENTE_TEMPERATURA, new Dictionary<string, Sprite>());
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NEGRO].CoeficienteTemperatura, sprts[32]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.CAFE].CoeficienteTemperatura, sprts[33]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.ROJO].CoeficienteTemperatura, sprts[34]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.NARANJA].CoeficienteTemperatura, sprts[35]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AMARILLO].CoeficienteTemperatura, sprts[36]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VERDE].CoeficienteTemperatura, sprts[37]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.AZUL].CoeficienteTemperatura, sprts[38]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.VIOLETA].CoeficienteTemperatura, sprts[39]);
        sprtsCodigoColores[TipoBanda.COEFICIENTE_TEMPERATURA].Add(CodigoColores.ObtenerInstancia().TablaCodigoColores[TipoColor.GRIS].CoeficienteTemperatura, sprts[40]);
        return sprtsCodigoColores;
    }
    #endregion
}