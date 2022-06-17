using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float remainingTime = 120f;
    public bool isGameStart = false;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Text txt = GetComponent<Text>();
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
            txt.Text = "Remaining time: " + remainingTime;
            remainingTime -= 1f*Time.deltaTime;
            if(remainingTime <= 0)
            {
                remainingTime = 0f;
                isGameStart = false;
            }
            //Debug.Log(remainingTime);
        }
    }
}
