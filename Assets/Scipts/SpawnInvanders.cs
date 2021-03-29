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
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;




    void Awake()
    {
        float x = xMin;
        float y = yMin;

        for(int i = 1; i <= 5; i++)
        {
          for(int j = 1; j <= nInvasores; j++)
          {
                if (j == 1)
                    x = xMin;

                if (i == 1)
                    Invasores(invasorA, 0);

                if (i == 2)
                    Invasores(invasorA, 0.5f);

                if (i == 3)
                    Invasores(invasorB, 1f);

                if (i == 4)
                    Invasores(invasorB, 1.5f);

                if (i == 5)
                    Invasores(invasorC, 2f);


          }


        }



        void Invasores(GameObject Invasor, float p)
        {
            y = yMin + p;

            GameObject newInvader = Instantiate(Invasor, transform);
            newInvader.transform.position = new Vector3(x, y, 0f);
            x += 1f;
        }

    }





}
