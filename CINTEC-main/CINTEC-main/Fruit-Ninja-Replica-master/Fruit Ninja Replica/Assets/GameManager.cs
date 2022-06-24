using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public float remainingTime = 120f;
    public float delay = 5f;
    public RestartCanvas restartCanvas;
    public bool isGameStart = false;
    public bool gameStarted = false;
    public Score score;
    public GameObject fruitSlicedPrefab;

    public void GameStart()
    {
        isGameStart = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            return;
        }

        CountDown();
    }

    void CountDown()
    {
        remainingTime -= 1f * Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = 0f;
            isGameStart = false;
            StartCoroutine(RestartGame(isGameStart));
        }
    }

    IEnumerator RestartGame(bool restartGame)
    {
        while (restartGame == false)
        {
            yield return new WaitForSeconds(GameManager.instance.delay);
            restartCanvas.ShowResult();
        }
    }

    public void HandleCollide(Blade _blade,Fruit _fruit)
    {
        Vector3 direction = (_blade.transform.position - _fruit.transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);

        GameObject slicedFruit = Instantiate(fruitSlicedPrefab, _fruit.transform.position, rotation);
        _fruit.audioSource.Play();
        Destroy(slicedFruit, 3f);
        Destroy(_fruit.gameObject);
        if (_fruit.CompareTag("Pests"))
        {
            score.score += 1;
        }
        else if (_fruit.CompareTag("BeneficialInsects"))
        {
            score.score -= 1;
        }
    }
}
