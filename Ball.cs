using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Paddle Paddle;
	private bool hasSatarted = false;
	private Vector3 paddleToBallVector;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		Paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - Paddle.transform.position;
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.3f), Random.Range(0f, 0.1f));
		if (hasSatarted)
		{
			audioSource.Play();
			int rand = Random.Range(1, 11);
			if (rand >= 5)
			{
				gameObject.GetComponent<Rigidbody2D>().velocity -= tweak;
			}
			else
			{
				gameObject.GetComponent<Rigidbody2D>().velocity += tweak;
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!hasSatarted)
		{
			// Lock the ball relative to the paddle
			this.transform.position = Paddle.transform.position + paddleToBallVector;
			// Wait for mouse press to launch ball/start game
			if (Input.GetMouseButton(0))
			{
				print("Mouse Clicked, Ball Launched");
				hasSatarted = true;
				gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}
}
