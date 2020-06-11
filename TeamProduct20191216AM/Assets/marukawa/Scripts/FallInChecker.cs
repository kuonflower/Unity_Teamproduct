using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour
{
    public Hole red;
    // Start is called before the first frame update
    void OnGUI()
     {
        string label = " ";

        if(red.IsGoal())
        {
            label = "Fall in hole!";
        }
        GUI.Label(new Rect(0, 0, 100, 30), label);
     }



    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
