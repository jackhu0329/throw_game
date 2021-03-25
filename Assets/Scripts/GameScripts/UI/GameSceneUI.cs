using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    private int score = 0;
    private float timer;
    private bool timerBool = true,UI=true;
    public Text time;
    public Text textScore;
    private int failCount = 0;
    private bool hasCorrection = false;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;
        transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(false);
        GameEventCenter.AddEvent("GetScore", GetScore);
        GameEventCenter.AddEvent("MotionFailed", MotionFailed);
        GameEventCenter.AddEvent("CorrectionUI", CorrectionUI); 
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBool)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameEventCenter.DispatchEvent("SpawnCup");
            GameEventCenter.DispatchEvent("MotionFailed");
        }

        if(failCount == 3)
        {
            UI = false;
            TimerEnd();
            time.text = "花費時間:" + Mathf.FloorToInt(timer);
            textScore.text = "任務完成數:" + score;
            transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
        }

        if (score == GameDataManager.FlowData.count)
        {
            UI = false;
            TimerEnd();
            time.text = "花費時間:" + Mathf.FloorToInt(timer);
            textScore.text = "任務完成數:" + score;
            transform.GetComponent<Canvas>().transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnGUI()
    {
        GUIStyle gameUI = new GUIStyle();
        gameUI.normal.textColor = new Color(0, 0, 0);
        gameUI.fontSize = 60;
        gameUI.fontStyle = FontStyle.Bold;

        if (UI&& hasCorrection)
        {
            GUI.Label(new Rect(Screen.width / 10 * 1, (Screen.height / 6 * 5), 200, 100),
            "已完成" + score + "次"
            , gameUI);
        }
        else if (UI)
        {
            GUI.Label(new Rect(Screen.width / 10 * 2, (Screen.height / 6 * 1), 200, 100),
            "請伸直手臂並按住扳機鍵進行校正"
            , gameUI);
        }

    }

    public void GetScore()
    {
        score++;
    }

    private void TimerStart()
    {
        timerBool = true;
    }

    private void TimerEnd()
    {
        if (timerBool)
        {
            timerBool = false;
        }
        
    }

    private void CorrectionUI()
    {
        hasCorrection = true;
        TimerStart();
    }
    private void MotionFailed()
    {
        failCount++;
        transform.GetComponent<Canvas>().transform.GetChild(failCount).gameObject.SetActive(true);
    }


}
