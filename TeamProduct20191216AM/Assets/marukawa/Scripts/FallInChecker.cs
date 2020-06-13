using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour
{
    public Hole red;

    public GameObject showObject;

    void Start()
    {
        //showObject = GameObject.Find("ReturnButton");
    }
    // Start is called before the first frame update
    void OnGUI()
     {
        string label = " ";

        if(red.IsGoal())
        {
            label = "clear";
            showObject.SetActive(true);


        }
        GUI.Label(new Rect(155, 0, 100, 30), label);
     }



    

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
