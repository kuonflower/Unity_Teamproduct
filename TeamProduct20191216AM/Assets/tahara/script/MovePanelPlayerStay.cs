using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanelPlayerStay : MonoBehaviour
{

    public GameObject PanelMoveStayl;
    public string Player;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MovePanel.PanelMoveStay = true;
        }
        else
        {
            MovePanel.PanelMoveStay = false;
        }

    }
}
