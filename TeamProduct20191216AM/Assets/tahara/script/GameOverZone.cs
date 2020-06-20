using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

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
            //
            SceneManager.LoadScene("stage");
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

        else
        {
            //showObject.SetActive (false);
        }

        GUI.Label(new Rect(300, 80, 500, 300), label);
    }

}
