using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConditions : MonoBehaviour
{
    public int sceneIndex;
    public GameObject deathMenu;
    public bool deathArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && transform.gameObject.CompareTag("Laser"))
        {
			deathMenu.SetActive(true);
            Time.timeScale = 0;
		}
        else if (collision.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(sceneIndex);
		}
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FirstProjectile") && deathArea == false ||
            collision.gameObject.CompareTag("SecondProjectile") && deathArea == false)
        {
            Destroy(collision.gameObject);
        }
    }
}