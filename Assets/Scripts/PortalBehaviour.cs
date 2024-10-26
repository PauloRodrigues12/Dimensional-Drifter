using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private float portalSpeed = 20f;

	public bool collided;
	private Rigidbody2D rb2d;

	public GameObject portalObject;

	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		collided = false;
	}

	private void Update()
	{
		if (collided == true)
		{
			Debug.Log("Portal has Collided!");
		}
		else PortalFlying();
	}

	private void PortalFlying()
	{
		rb2d.velocity = transform.right * portalSpeed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Terrain"))
		{
			CollisionDetected();
		}
		else if (collision.gameObject.CompareTag("Platform"))
        {
			PlatformDetected(collision);
        }
    }

	private void CollisionDetected()
	{
		Debug.Log("Collision detected with the Terrain");

		collided = true;

		rb2d.velocity = Vector3.zero;
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

		Instantiate(portalObject, this.transform.position, Quaternion.identity);

		Destroy(gameObject);
	}

    private void PlatformDetected(Collision2D collision)
    {
        Debug.Log("Collision detected with the Terrain");

        collided = true;

        rb2d.velocity = Vector3.zero;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        GameObject obj = Instantiate(portalObject, this.transform.position, Quaternion.identity);

		obj.transform.parent = collision.transform;

        Destroy(gameObject);
    }
}
