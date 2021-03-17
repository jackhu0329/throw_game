using System.Collections;
using System.Collections.Generic;
using GameData;
using LabData;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject launcher;
    public GameObject editor;
    public Button startButton;
    public Button settingButton;
    public Button settingFinishButton;
    public InputField scriptName;
    public Dropdown mode;
    public Dropdown count;
    private int modev,countv;
    private void Start()
    {
        modev = 0;
        countv = 5;
        startButton.onClick.AddListener(StartButtonClick);
        settingButton.onClick.AddListener(SettingButtonClick);
        settingFinishButton.onClick.AddListener(FinishButtonClick);
    }

    public void StartButtonClick()
    {
        //MyGameData data = LabTools.GetData<MyGameData>(choose.captionText.text);
        GameFlowData gameFlow = new GameFlowData();
       // Debug.Log(data.angle);
        GameDataManager.FlowData = gameFlow;
        //GameDataManager.FlowData = new GameFlowData("01", data);
        GameDataManager.FlowData.count = countv;
        GameDataManager.FlowData.mode = modev;
        //var Id = gameFlow.UserId;

        //GameDataManager.LabDataManager.LabDataCollectInit(() => Id);
        GameSceneManager.Instance.Change2MainScene();
        //Application.Quit();
    }

    public void SettingButtonClick()
    {
        launcher.SetActive(false);
        editor.SetActive(true);

    }

    public void FinishButtonClick()
    {
        modev = mode.value; ;
        countv = count.value;
        switch (count.value)
        {
            case 0:
                countv = 5;
                break;
            case 1:
                countv = 10;
                break;
            case 2:
                countv = 15;
                break;
        }
        Debug.Log(modev + " " + countv);
        launcher.SetActive(true);
        editor.SetActive(false);

    }
}
