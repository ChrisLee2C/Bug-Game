using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {
    
    public GameObject[] beneficialInsects;
    public GameObject[] pests;
    public Transform[] spawnPoints;
    public int ratio = 9;
    private GameObject timer;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        timer = GameObject.FindWithTag("Timer");
    }

    void Update()
    {
        if (GameManager.instance.isGameStart == true && GameManager.instance.gameStarted == false)
        {
            StartCoroutine(SpawnFruits());
            GameManager.instance.gameStarted = true;
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

            if (Random.Range(0,10) >= ratio)
            {
                int beneficialInsectIndex = Random.Range(0, beneficialInsects.Length);
                GameObject spawnedBug = Instantiate(beneficialInsects[beneficialInsectIndex], spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedBug, 5f);
            }
            else
            {
                int pestIndex = Random.Range(0, pests.Length);
                GameObject spawnedBug = Instantiate(pests[pestIndex], spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedBug, 5f);
            }
            if(GameManager.instance.isGameStart == false)
            {
                break;
            }
		}
	}
	
}
