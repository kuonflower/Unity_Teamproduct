﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LifePanel lifePanel;

    void Update()
    {
        lifePanel.UpdateLife(StatusPlayer.hitPoint);

    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
