using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    [Header("PlayerObject")] public GameObject playerObj;
    [Header("リトライの位置")] public GameObject[] continuePoint;

    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0)
        {
            playerObj.transform.position = continuePoint[0].transform.position;
            AudioManager.Instance.PlayVoice("StartVoice1");
        }
    }
}
