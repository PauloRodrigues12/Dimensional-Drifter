using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraController camController;
    public Camera cam;
    public float camSize;
    public Transform Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AreaOfCamera();
            cam.orthographicSize = camSize;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (camController.player == transform)
            {
                BackToPlayer();
                cam.orthographicSize = 7;
            }
        }
    }
    public void AreaOfCamera()
    {
        camController.player = transform;
    }
    public void BackToPlayer()
    {
        camController.player = Player.transform;
    }
}
