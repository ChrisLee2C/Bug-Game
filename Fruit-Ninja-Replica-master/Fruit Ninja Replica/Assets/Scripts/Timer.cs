using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float remainingTime = 120f;
    public bool isGameStart = false;
    public bool gameStarted = false;
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

    // Update is called once per frame
    void Update()
    {
        if(isGameStart == true)
        {
            txt.text = "Remaining Time: " + remainingTime;
            remainingTime -= 1f*Time.deltaTime;
            if(remainingTime <= 0)
            {
                remainingTime = 0f;
                isGameStart = false;
            }
        }
    }
}
