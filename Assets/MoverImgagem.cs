using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverImgagem : MonoBehaviour
{

    public Transform transf;
    public Vector3 v;
    public string nomeBanda;
    public bool mover = false;

    public float limitador;
    public float positionx;
    public float positiony;
    Rigidbody rb;

    bool iniciaMovimento;
    bool pararMovimento;


    // Use this for initialization
    void Start()
    {
        iniciaMovimento = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            //v.x = positionX;
            //v.y = positiony;
            //v.z = positionz;


            // Debug.Log("teste limitadorTempo =  " + limitador + "    rb.position.x.ToString() = " + rb.position.x.ToString() + "    ----  " + (rb.position.x >= limitador).ToString());

            //limitadorTempo = rb.position.x;

            if (limitador > 0)
            {
                pararMovimento = (rb.position.x >= limitador);
            }
            else
            {
                pararMovimento = (rb.position.x <= -limitador);
            }

            if (pararMovimento)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;

                mover = false;

                Debug.Log(" PAROU - xxx " + rb.position.x.ToString());
                Debug.Log(" yyyy " + rb.position.y.ToString());
            }
            else
            {
                if (iniciaMovimento)
                {

                    Debug.Log(" INICIOU xxx " + rb.position.x.ToString());
                    Debug.Log(" yyyy " + rb.position.y.ToString());

                    rb.constraints = RigidbodyConstraints.None;
                    iniciaMovimento = false;
                }
            }


        }
    }

    void FixedUpdate()
    {
        // Debug.Log("FixedUpdate   ---------- " + positionx.ToString());
        rb.AddForce(new Vector3(positionx, positiony, 0));
    }


    public void MoverImagem_Onclick()
    {
        mover = true;
    }

}
