using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
	[Header("Moving Direction")]
	public bool horizontal = true;
	public bool vertical = false;
	public float speed;
	public float pauseInterval;

	[Header("Moving Points")]
	public GameObject negativePoint;
	public GameObject positivePoint;

	private bool movement = true; // True = RIGHT - False = LEFT

	void Update()
	{
		// Verify which one is active
		if (vertical == true)	
			horizontal = false;
		else 
			horizontal = true;

		// Detect side of the movement
		if (horizontal == true)
		{
			if (transform.position.x - .001 <= negativePoint.transform.position.x)
			{
				//movement = true;
				StartCoroutine(stopMovingInterval(pauseInterval, true));
			}
			else if (transform.position.x + .001 >= positivePoint.transform.position.x)
			{
				//movement = false;
				StartCoroutine(stopMovingInterval(pauseInterval, false));
			}
		}
		else
		{
			if (transform.position.y - .001 <= negativePoint.transform.position.y)
			{
				//movement = true;
				StartCoroutine(stopMovingInterval(pauseInterval, true));
			}
			else if (transform.position.y + .001 >= positivePoint.transform.position.y)
			{
				//movement = false;
				StartCoroutine(stopMovingInterval(pauseInterval, false));
			}
		}

		// Make the move
        platformMovement();
	}

	public void platformMovement()
	{
		if (horizontal == true)
		{
			if (movement == true)
				transform.position = Vector2.MoveTowards(transform.position, positivePoint.transform.position, speed * Time.deltaTime);
			else if (movement == false)
				transform.position = Vector2.MoveTowards(transform.position, negativePoint.transform.position, speed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		collision.transform.SetParent(transform);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		collision.transform.SetParent(transform);
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		collision.transform.SetParent(null);
	}

	IEnumerator stopMovingInterval(float intervalTime, bool state)
	{
		yield return new WaitForSeconds(intervalTime);
		movement = state;
	}
}
