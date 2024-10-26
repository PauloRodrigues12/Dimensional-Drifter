using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShooter : MonoBehaviour
{
    private Camera cam;
    private Vector2 mousepos;
    private Vector2 direction;

    private GameObject portalInstance;

    public GameObject projectileOne;
	public GameObject projectileTwo;

	void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousepos - (Vector2)this.transform.position).normalized;
        this.transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            // Detect current portal and destroy it
            GameObject[] thisPortal = GameObject.FindGameObjectsWithTag("FirstPortal");
			foreach (GameObject go in thisPortal) Destroy(go);

            // Detect current projectile and destroy it
            GameObject[] projectile = GameObject.FindGameObjectsWithTag("FirstProjectile");
            foreach (GameObject go in projectile) Destroy(go);

            portalInstance = Instantiate(projectileOne, this.transform.position, this.transform.rotation);
		}
        else if (Input.GetMouseButtonDown(1))
        {
            // Detect current portal and destroy it
			GameObject[] thisPortal = GameObject.FindGameObjectsWithTag("SecondPortal");
			foreach (GameObject go in thisPortal) Destroy(go);

            // Detect current projectile and destroy it
            GameObject[] projectile = GameObject.FindGameObjectsWithTag("SecondProjectile");
            foreach (GameObject go in projectile) Destroy(go);

            portalInstance = Instantiate(projectileTwo, this.transform.position, this.transform.rotation);

		}
	}
}
