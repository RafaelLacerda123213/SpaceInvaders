using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{

    public int dfltLives;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentLives", dfltLives);
    }

    public void Replay()
    {
        FindObjectOfType<GameManager>().Reset();
    }



}
