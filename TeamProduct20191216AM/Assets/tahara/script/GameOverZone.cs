using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public bool GameOverflag = false;
    public GameObject showObject;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    void onTriggerEnter(Collider gameover)
    {
        if(gameover.gameObject.tag == "Player")
        {
            GameOverflag = true;
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
        GUI.Label(new Rect(300, 80, 500, 300), label);
    }

}
