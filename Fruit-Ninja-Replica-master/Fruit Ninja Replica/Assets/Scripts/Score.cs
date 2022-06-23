using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20;
    public GameObject textGameObject;
    private bool pass;
    private Timer timerScript;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        timerScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(3);
        if (pass)
        {
            textGameObject.GetComponent<Text>().color = Color.green;
            textGameObject.GetComponent<Text>().text = "You Passed!";
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
        txt.text = "Score: " + score;
        if(timerScript.isGameStart != true && timerScript.remainingTime == 0)
        {
            textGameObject.SetActive(true);
            if(score < targetScore)
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