using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject textGameObject;
    public GameObject scoreGamObject;
    private TargetScore targetScoreScript;
    private bool pass;
    private Timer timerScript;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        targetScoreScript = scoreGamObject.GetComponent<TargetScore>();
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(5);
        if (pass)
        {
            textGameObject.GetComponent<Text>().color = Color.green;
            textGameObject.GetComponent<Text>().text = "Congratulations!";
        }
        else
        {
            textGameObject.GetComponent<Text>().color = Color.white;
            textGameObject.GetComponent<Text>().text = "Keep Trying!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(score <= 0)
        {
            score = 0;
        }
        txt.text = "Current Score: " + score;
        if(timerScript.isGameStart != true && timerScript.remainingTime == 0)
        {
            textGameObject.SetActive(true);
            if(score < targetScoreScript.targetScore)
            {
                pass = false;
            }
            else
            {
                pass = true;
            }
            StartCoroutine(endGame());
        }
    }
}