using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invader : MonoBehaviour
{



    [SerializeField]
    GameObject fire;

    //[SerializeField]
    //float cadencia = 0.997f;

    [SerializeField]
    int indLives = 10;

    int indLivesCounter;

    //float tempoQuePassou = 0f;

    public float minFireRateTime = 1.0f;

    public float maxFireRateTime = 3.0f;

    float baseFireWaitTime = 3.0f;



    private void Start()
    {
        baseFireWaitTime = baseFireWaitTime +
                         Random.Range(minFireRateTime, maxFireRateTime);
    }


    //Fazer com que os Aliens disparem num tempo random
    void FixedUpdate()
    {
        if(tag == "destrutivel")
        {
            if (Time.time > baseFireWaitTime)
            {

                baseFireWaitTime = baseFireWaitTime +
                    Random.Range(minFireRateTime, maxFireRateTime);

                Instantiate(fire, transform.position, Quaternion.identity);

            }

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "destrutivel")
        {
            if (collision.gameObject.tag == "ProjetilAmigo")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);

            }


        }
        else
        {
            Destroy(collision.gameObject);
        }


     

        //vida para os Industrutiveis = 10 vidas
        if (tag == "industrutivel")
        {
                 if (collision.gameObject.tag == "ProjetilAmigo")
                 {
                        indLives--;



                        if (indLives < 1)
                        {
                            Destroy(gameObject);
                            Destroy(collision.gameObject);

                        }


                 }


        }
        else
        {
            Destroy(collision.gameObject);
        }


    }



}
