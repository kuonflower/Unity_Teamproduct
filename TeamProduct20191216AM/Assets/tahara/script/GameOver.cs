using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool GameOverflag;
    public GameObject showObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider gameover)
    {
        if (gameover.gameObject.tag == "Player")
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

        else if (!GameOverflag)
        {
            showObject.SetActive(false);
        }

        GUI.Label(new Rect(300, 80, 500, 300), label);
    }

}
