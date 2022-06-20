using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
    public GameObject[] GoodBugs;
    public GameObject[] Pests;
    public Transform[] spawnPoints;
    private GameObject timer;
    private Timer timerScript;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        timer = GameObject.FindWithTag("Timer");
        timerScript = timer.GetComponent<Timer>();
    }

    void Update()
    {
        if (timerScript.isGameStart == true && timerScript.gameStarted == false)
        {
            StartCoroutine(SpawnFruits());
            timerScript.gameStarted = true;
        }

    }

    IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
            if(timerScript.isGameStart == false)
            {
                break;
            }
		}
	}
	
}
