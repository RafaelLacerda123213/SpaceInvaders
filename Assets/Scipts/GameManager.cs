using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ship nave;
    public SpawnInvanders bicho;
    private Vector2 naveStart;
    private Vector2 bichoStart;

    public GameObject gameOverTela;

    public LivesManager theLM;




    // Start is called before the first frame update
    void Start()
    {
        naveStart = nave.transform.position;
        bichoStart = bicho.transform.position;
    }

    public void GameOver()
    {
        gameOverTela.SetActive(true);
        nave.gameObject.SetActive(false);
        bicho.gameObject.SetActive(false);
        

    }




    public void Reset()
    {

        gameOverTela.SetActive(false);
        nave.gameObject.SetActive(true);
        bicho.gameObject.SetActive(true);
        nave.transform.position = naveStart;
        bicho.transform.position = bichoStart;
        theLM.LivesCounter = theLM.deafultLives;


    }


}
