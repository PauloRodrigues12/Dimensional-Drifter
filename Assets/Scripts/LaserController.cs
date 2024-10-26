using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laser;
    public bool usarTemporizador = false;
    public float tempoAtivo;
    public float tempoDesativo;

    void Start()
    {
        if (tempoAtivo <= 0) tempoAtivo = 1;
        if (tempoDesativo <= 0) tempoDesativo = 1;

        if (usarTemporizador == true)
            StartCoroutine(laserManagement(tempoAtivo, tempoDesativo));
    }

    IEnumerator laserManagement(float activeTime, float deactiveTime)
    {
        yield return new WaitForSeconds(activeTime);
        laser.SetActive(false);

        yield return new WaitForSeconds(deactiveTime);
        laser.SetActive(true);

        StartCoroutine(laserManagement(tempoAtivo, tempoDesativo));
    }
}
