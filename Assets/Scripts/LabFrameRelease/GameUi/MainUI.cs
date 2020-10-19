using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    private void Start()
    {
        GameSceneManager.Instance.Change2MainScene();
    }
}
