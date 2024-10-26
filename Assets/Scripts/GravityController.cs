using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private float speed = .15f;

	private AudioSource source;
	public AudioClip clip;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	// Detect player or object and swap gravity and flip sprite
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") ||
			collision.gameObject.CompareTag("Object"))
		{
			rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
			FlipY(collision.gameObject);
			rb2d.gravityScale *= -1;

			source.PlayOneShot(clip);
		}
	}

	// Detect portal projectile and rotate the trajectory
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FirstProjectile") ||
			collision.gameObject.CompareTag("SecondProjectile"))
		{
			collision.transform.rotation = Quaternion.Lerp(collision.transform.rotation, transform.rotation, speed);
		}
    }

    // Detect player or object and swap gravity and flip sprite

    private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") ||
			collision.gameObject.CompareTag("Object"))
		{
			rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
			FlipY(collision.gameObject);
			rb2d.gravityScale *= -1;
		}
	}

	private void FlipY(GameObject obj)
	{
		Vector3 scale = obj.transform.localScale;
		scale.y *= -1;
		obj.transform.localScale = scale;
	}
}
