using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    //public int defaultLives;
    public int LivesCounter;
    public int deafultLives;

    public Text livesText;

    private GameManager theGM;

    

 

    // Start is called before the first frame update
    void Start()
    {
        LivesCounter = deafultLives;

        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x " + LivesCounter;

        if(LivesCounter < 1)
        {
            theGM.GameOver();
            
        }
    }

    public void TakeLife()
    {

        LivesCounter--;
        
        


    }

    public void AddLife()
    {

        LivesCounter++;

    }
}
