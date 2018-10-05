using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;

	// Update is called once per frame
	void Update ()
	{
		if (!autoPlay)
		{
			moveWithMouse();
		}
		else
		{
			AutoPlay();
		}
	}

	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = GameObject.FindObjectOfType<Ball>().transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.84f, 15.15f);
		this.transform.position = paddlePos;
	}

	void moveWithMouse ()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosinBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosinBlocks, 0.84f, 15.15f);
		this.transform.position = paddlePos;
	}
}
