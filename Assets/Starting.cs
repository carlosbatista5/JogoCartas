using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Starting : MonoBehaviour
{

    public Transform transf;
    public string nomeBanda;
    public bool moverVertical = false;
    // private bool moverHorizontal = false;
    private bool iniciaMovimentoHorizontal = false;
    private bool movimentoHorizontalIniciado = false;

    public float limitador;
    public float positionx;
    public float positiony;
    Rigidbody rb;

    bool iniciaMovimento;
    bool pararMovimento;

    //*********************************************
    // private GameObject gameObjcartaJogardor1;
    // private GameObject gameObjcartaJogardor2;
    //  private Canvas canvas;
    // public GameObject gameObjBotaoJogador1;
    // private GameObject botaoNovo;
    //  public Transform transform;

    //Rigidbody rigidbody;


    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public GameObject carta;
    float posicaoXQuadradoJogador1;
    float posicaoXBotaoDinamico;
    public GameObject goCartaModelo;

    // Use this for initialization
    void Start()
    {

        GameObject goQuadradoJogador1;
        float posicaoYQuadradoJogador1;

        Button tempButtonPreFab = prefabButton.GetComponent<Button>();
        Rigidbody rbPreFab = GameObject.Find("GOLadoEsquerdo").GetComponent<Rigidbody>();
        tempButtonPreFab.onClick.AddListener(() => { ButtonClicked(rbPreFab, tempButtonPreFab.name); });


        goQuadradoJogador1 = GameObject.FindWithTag("QuadradoJogador1");

        posicaoYQuadradoJogador1 = goQuadradoJogador1.transform.position.y;
        posicaoXQuadradoJogador1 = goQuadradoJogador1.transform.position.x;

        limitador = (posicaoYQuadradoJogador1 - 50);
       
        //  Debug.Log("limitador = " + limitador.ToString());
        // Debug.Log("posicaoYQuadradoJogador1 = " + posicaoYQuadradoJogador1.ToString());


        iniciaMovimento = true;



        for (int i = 0; i < 6; i++)
        {

            GameObject goCartaDinamica = (GameObject)Instantiate(goCartaModelo);
            goCartaDinamica.name = "carta_" + i.ToString();
            goCartaDinamica.transform.position = new Vector3(goCartaDinamica.transform.position.x * (i + 2), goCartaDinamica.transform.position.y, 0);

            goCartaDinamica.transform.SetParent(ParentPanel, false);
            Button tempButton = goCartaDinamica.GetComponentInChildren<Button>();
            tempButton.name = "botao_" + i.ToString();

            tempButton.onClick.AddListener(() => { ButtonClicked(goCartaDinamica.GetComponent<Rigidbody>(), tempButton.name); });

            //****************************************************************
            //GameObject gObjCarta = (GameObject)Instantiate(carta);
            //gObjCarta.transform.position = new Vector3(100, 50, 0);
            //gObjCarta.name = "carta_" + i.ToString();
            //gObjCarta.transform.SetParent(ParentPanel, false);

            //GameObject goButton = (GameObject)Instantiate(prefabButton);
            //goButton.transform.SetParent(gObjCarta.transform, false);
            //goButton.transform.localScale = new Vector3(0.5f, 1, 1);
            //goButton.name = "botao_" + i.ToString();
            //goButton.transform.position = new Vector3(250 + i * 80, 250, 0);

            //Button tempButton = goButton.GetComponent<Button>();
            //int tempInt = i;

            //Rigidbody pRigidbody = gObjCarta.GetComponent<Rigidbody>();


            //tempButton.onClick.AddListener(() => { ButtonClicked(pRigidbody, goButton.name); });
        }

    }

    private void DropEventMethod(BaseEventData arg0)
    {
        Debug.Log("entrou  metodo ");
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (moverVertical)
        {

            pararMovimento = (rb.position.y <= limitador);
            // Debug.Log(" posicao y --- " + rb.position.y.ToString());
            // Debug.Log(" limitador --- " + limitador.ToString());

            //if (limitador > 0)
            //{
            //    pararMovimento = (rb.position.y >= limitador);
            //    Debug.Log(" posicao y --- " + rb.position.y.ToString());
            //    Debug.Log(" limitador --- " + limitador.ToString());

            //}
            //else
            //{
            //    pararMovimento = (rb.position.y <= -limitador);
            //    Debug.Log(" posicao y --- " + rb.position.y.ToString());
            //    Debug.Log(" limitador --- " + limitador.ToString());
            //}

            if (pararMovimento)
            {
                // rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                rb.constraints = RigidbodyConstraints.FreezePositionY;

                moverVertical = false;

                // Debug.Log(" PAROU - xxx " + rb.position.x.ToString());
                //  Debug.Log(" yyyy " + rb.position.y.ToString());

                iniciaMovimentoHorizontal = true;
            }
            else
            {
                if (iniciaMovimento)
                {

                    //   Debug.Log(" INICIOU xxx " + rb.position.x.ToString());
                    //  Debug.Log(" yyyy " + rb.position.y.ToString());

                    rb.constraints = RigidbodyConstraints.None;
                    iniciaMovimento = false;
                }
            }
        }

        if (iniciaMovimentoHorizontal)
        {
            IniciarMovimentoHorizontal();
        }

        if (movimentoHorizontalIniciado)
        {
            PararMovimentoHorizontal();
        }
    }

    private void PararMovimentoHorizontal()
    {

        //  posicaoXBotaoDinamico = posicaoXQuadradoJogador1 - posicaoXBotaoDinamico;

       // Debug.Log(" rb.position.x -------  " + rb.position.x.ToString());
        if (posicaoXQuadradoJogador1 > rb.position.x)
        {

            Debug.Log(" ************* PAROU **************************************************** ");
            Debug.Log("  posicaoXQuadradoJogador1 -------  " + posicaoXQuadradoJogador1.ToString());

            Debug.Log(" rb.position.x -------  " + rb.position.x.ToString());

            //Debug.Log(" posicaoXInicial -------  " + posicaoXInicial.ToString());

            // rb.AddForce(new Vector3(0, 0, 0));
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            movimentoHorizontalIniciado = false;
            //Debug.Log("  rb.position.x -------  " + rb.position.x.ToString());
        }
        else
        {
            posicaoXBotaoDinamico = posicaoXBotaoDinamico - 7;
        }


    }

    private void IniciarMovimentoHorizontal()
    {
        ForceMode forceMode = new ForceMode();
        forceMode = ForceMode.VelocityChange;
        //rb.AddForce(new Vector3(positionx, -213, 0), forceMode);
        rb.AddForce(new Vector3(-200, 0, 0), forceMode);

        iniciaMovimentoHorizontal = false;
        movimentoHorizontalIniciado = true;
    }

    void ButtonClicked(Rigidbody rgb, string nomeBotao)
    {
        //  MoverImgagem mover = new MoverImgagem();
        GameObject goBotaoDinamico = GameObject.Find(nomeBotao);




        //limitador = pLimitador;
        positionx = rgb.position.x;
        positiony = rgb.position.y;
        moverVertical = true;
        iniciaMovimento = true;

        rb = rgb;

        posicaoXBotaoDinamico = goBotaoDinamico.transform.position.x - posicaoXQuadradoJogador1;
       // Debug.Log(" posicaoXBotaoDinamico  = " + posicaoXBotaoDinamico.ToString());

        //limitadorX = (posicaoXBotaoDinamico - posicaoXQuadradoJogador1) - 200;
        // Debug.Log(" limitadorX -- " + limitadorX.ToString());


        ForceMode forceMode = new ForceMode();
        forceMode = ForceMode.VelocityChange;
        //rb.AddForce(new Vector3(positionx, -213, 0), forceMode);
        rb.AddForce(new Vector3(0, -400, 0), forceMode);


        //  Debug.Log("Button clicked = " + rgb.ToString() + "nome botao = " + nomeBotao);
        // Debug.Log(" positionx  " + positionx.ToString());
        // Debug.Log(" posicao y " + rb.position.y.ToString());

    }



    void FixedUpdate()
    {
        //  Debug.Log("FixedUpdate   ---------- " + positionx.ToString());
        //  rb.AddForce(new Vector3(positionx, -positiony, 0));
    }

    private void OnTransformChildrenChanged()
    {
        Debug.Log("OnTransformChildrenChanged  ");
    }
}
