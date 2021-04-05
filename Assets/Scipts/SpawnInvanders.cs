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

    [SerializeField]
    float movLat = -3f;







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

    private void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + movLat;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - movLat;

    }



    void Update()
    {
        {

            tempo += Time.deltaTime;

            Vector3 position = transform.position;
            position.x = Mathf.Clamp(position.x, minX, maxX);
            transform.position = position;

            if (mov == true)
            {
                transform.position += velocidade * Vector3.right;
                transform.position += velocidade * Vector3.down;

                if (position.x == maxX)
                {
                    mov = false;
                }

            }

            if (mov == false)
            {
                transform.position -= velocidade * Vector3.right;
                transform.position -= velocidade * Vector3.down;

                if (position.x == minX)
                {
                    mov = true;
                }
            }


        }

    }



}
