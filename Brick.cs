using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public AudioClip crack;
	public GameObject smoke;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable)
		{
			brickCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable)
		{
			HandleHits();
		}
	}

	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{
			brickCount--;
			levelManager.BrickDestroyed();
			puffSmoke();
			Destroy (gameObject);
		}
		else
		{
			LoadSprites();
		}
	}

	void puffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
		main.startColor = this.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites()
	{
		// Loads the element at timeshit - 1 so if hit once it will load element 0.. etc
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; //Loads the sprite at the whatever element in
		}
	}

	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
