using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseController : MonoBehaviour
{
    public Vector2 ImpulseVector;
    public float force;
    private float forceDefault;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Object"))
        {
            forceDefault = force;
        }
    }

    private Rigidbody2D rb2d;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Object"))
        {
            //collision.transform.position += new Vector3(ImpulseVector.x, ImpulseVector.y, 0) * force;
            rb2d = collision.GetComponent<Rigidbody2D>();
            rb2d.AddForce(ImpulseVector * force);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Object"))
        {
            force = forceDefault;
        }
    }
}
