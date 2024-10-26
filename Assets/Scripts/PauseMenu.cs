using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public PauseMenu pauseMenuScript;
	public GameObject pausemenu;
	public GameObject portalShooter;
	public GameObject deathMenu;

	public bool gamePaused = false;

	private void Start()
	{
		Time.timeScale = 1;
	}
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape) && pausemenu.activeInHierarchy == false && deathMenu.activeInHierarchy == false)
		{
			pauseMenuScript.Pause();
			pausemenu.SetActive(true);
			gamePaused = true;
		}
		else if (Input.GetKeyUp(KeyCode.Escape) && pausemenu.activeInHierarchy == true && deathMenu.activeInHierarchy == false)
		{
			pauseMenuScript.Resume();
			pausemenu.SetActive(false);
			gamePaused = false;
		}

		if (Time.timeScale == 0) portalShooter.SetActive(false);
		else portalShooter.SetActive(true);
	}
	public void Pause()
    {
		Time.timeScale = 0;
		gamePaused = true;
	}
	public void Resume()
	{
		Time.timeScale = 1;
		gamePaused = false;
	}
	public void HideMenu(GameObject menu)
	{
		menu.SetActive(false);
	}
	public void ShowMenu(GameObject menu)
	{
		menu.SetActive(true);
	}
	public void LoadScene(int index)
	{
		SceneManager.LoadScene(index);
	}
}