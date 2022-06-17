using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float remainingTime = 120f;
    public bool isGameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
