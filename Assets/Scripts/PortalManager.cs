using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject otherPortal;

	private void Update()
	{
		otherPortal = GameObject.FindGameObjectWithTag("SecondPortal");
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
        {
			Debug.Log("Collision detected with the Player");
			collision.transform.position = new Vector3(otherPortal.transform.position.x, otherPortal.transform.position.y, otherPortal.transform.position.z);
        }
    }
}