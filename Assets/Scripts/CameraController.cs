using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public PauseMenu pauseMenu;

	public float smoothSpeed = 2f;
	public Vector3 offset;
	public Transform player;

	[Space(10)] // 10 pixels of spacing here.

	public Transform mapCam;
	public float mapCamSize;
	private Camera cam;

	[Space(10)] // 10 pixels of spacing here.

	public GameObject background;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Tab) && pauseMenu.gamePaused == false)
		{
			transform.position = mapCam.transform.position;
			background.SetActive(false);
			
			cam.orthographicSize = mapCamSize;
			
			Time.timeScale = 0;
		} 
		else if (player != null && pauseMenu.gamePaused == false)
		{
			Time.timeScale = 1;

			background.SetActive(true);
			cam.orthographicSize = 8;

			Vector3 movingToPos = transform.position = player.position + offset;
			Vector3 smoothedPos = Vector3.Lerp(transform.position, movingToPos, smoothSpeed * Time.deltaTime);
			transform.position = smoothedPos;
			background.transform.position = new Vector3(smoothedPos.x, smoothedPos.y, 0);
		}
	}
}
