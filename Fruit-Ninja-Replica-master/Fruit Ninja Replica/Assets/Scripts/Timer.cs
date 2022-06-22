using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float remainingTime = 120f;
    public float delay = 5f;
    public bool isGameStart = false;
    public bool gameStarted = false;
    public GameObject restartButton;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    public void GameStart()
    {
        isGameStart = true;
    }

    IEnumerator RestartGame(bool restartGame)
    {
        while (restartGame == false)
        {
            yield return new WaitForSeconds(delay);
            restartButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStart == true)
        {
            txt.text = "Remaining Time: " + Convert.ToInt32(remainingTime);
            remainingTime -= 1f*Time.deltaTime;
            if(remainingTime <= 0)
            {
                remainingTime = 0f;
                isGameStart = false;
                StartCoroutine(RestartGame(isGameStart));
            }
        }
    }
}
