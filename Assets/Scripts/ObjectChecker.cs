using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public GameObject objectSpawnpoint;
    private Rigidbody2D rb2d;

    [SerializeField]
    private float timer = 0f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
            timer += Time.deltaTime;

        if (timer >= 2f)
            Reset();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
            timer = 0f;
    }

    private void Reset()
    {
        transform.position = objectSpawnpoint.transform.position;
        rb2d.velocity = new Vector3 (0, 0, 0);
        timer = 0f;
    }
}
