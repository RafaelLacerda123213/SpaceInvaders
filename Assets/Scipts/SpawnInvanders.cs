using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvanders : MonoBehaviour
{

    [SerializeField]
    GameObject invasorA;

    [SerializeField]
    GameObject invasorB;

    [SerializeField]
    GameObject invasorC;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    public GameObject[] invasores;

    [SerializeField]
    GameObject[] invasoresInd;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;

    [SerializeField]
    float xInc = 1f;

    [SerializeField]
    float yInc = 0.5f;

    [SerializeField]
    float probabilidadeDeInd = 0.15f;

    float minX, maxX;

    float velocidade = 0.005f;

    float tempo = 0f;

    bool mov = true;

    bool vmov = false;






    public void Awake()
    {
        float y = yMin;

        for (int line = 0; line < invasores.Length; line++)
        {
           
            float x = xMin;
            for( int i = 1; i <= nInvasores; i++)
            {
                if(Random.value <= probabilidadeDeInd)
                {
                    GameObject newInvader = Instantiate(invasoresInd[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                } else
                {
                    GameObject newInvader = Instantiate(invasores[line], transform);
                    newInvader.transform.position = new Vector3(x, y, 0f);
                    
                }
                x += xInc;

            }
            y += yInc;
        }

    }

    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 3.3f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 3.3f;

    }



    void Update()
    {

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;

        if(mov == true)
        {
            transform.position += velocidade * Vector3.right;

            if(position.x == maxX && vmov == false)
            {
                if (position.y <= -2)
                    vmov = true;
                else
                    transform.position += 0.2f * Vector3.down; 
            }
            if (position.x == maxX)
                mov = false;
        }
        else
        {
            transform.position -= velocidade * Vector3.right;

            if(position.x == minX && vmov == false)
            {
                if (position.y <= -2)
                    vmov = true;
                else
                    transform.position += 0.2f * Vector3.down;
            }
            if (position.x == minX)
                mov = true;
        }




    }



}
