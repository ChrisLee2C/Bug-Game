using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public float startForce = 15f;
    public GameObject fruitSlicedPrefab;
    private AudioSource audioSource;
    private GameObject score;
    private Score scoreScript;

	Rigidbody2D rb;

	void Start ()
	{
        audioSource = GameObject.FindWithTag("SliceSoundEffect").GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        score = GameObject.FindWithTag("Score");
        scoreScript = score.GetComponent<Score>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            audioSource.Play();
            Destroy(slicedFruit, 3f);
			Destroy(gameObject);
            scoreScript.score += 1;
		}
	}

}
