using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemy : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy1.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);
        enemy4.SetActive(true);
        enemy5.SetActive(true);
    }
}
