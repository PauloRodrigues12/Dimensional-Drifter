using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public void HideMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
}
