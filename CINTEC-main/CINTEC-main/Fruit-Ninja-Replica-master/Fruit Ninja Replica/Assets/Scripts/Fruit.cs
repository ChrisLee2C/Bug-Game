using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {
    public float startForce = 15f;
	public AudioSource audioSource;

	Rigidbody2D rb;

	void Start ()
	{
        audioSource = GameObject.FindWithTag("SliceSoundEffect").GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
            GameManager.instance.HandleCollide(col.GetComponent<Blade>(), this);
        }
	}

}
