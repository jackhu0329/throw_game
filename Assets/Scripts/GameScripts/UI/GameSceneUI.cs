﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameEventCenter.AddEvent("GetScore", GetScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(255, 255, 255);
        gameUI.fontSize = 30;

        GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
        "已完成" + score + "次"
        , gameUI);
    }

    public void GetScore()
    {
        score++;
    }
}