﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverZone : MonoBehaviour
{
    public bool GameOverflag = false;
    public GameObject showObject;

    void Start()
    {
        GameOverflag = false;
    }

    
    void Update()
    {
      

    }
    
    void onTriggerEnter(Collider gameover)
    {
        if(gameover.gameObject.tag == "Player")
        {
            Debug.Log("プレイヤー感知");
            //
            //SceneManager.LoadScene("stage");
            GameOverflag = true;
        }
        else
        {
            //GameOverflag = false;
        }
    }

    void OnGUI()
    {
        string label = " ";

        if (GameOverflag)
        {
            label = "GameOver";
            showObject.SetActive(true);


        }

        else if(!GameOverflag)
        {
            showObject.SetActive (false);
        }

        GUI.Label(new Rect(300, 80, 500, 300), label);
    }

}
