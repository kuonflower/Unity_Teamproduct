using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    //public static int coinCount;
    // Start is called before the first frame update
    void OnGUI()
    {
        GUI.color = Color.black;

        string label = "coinの枚数:" + CoinDestroyer.coinCount;

        GUI.Label(new Rect(250, 0, 100, 30), label);
    }

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
