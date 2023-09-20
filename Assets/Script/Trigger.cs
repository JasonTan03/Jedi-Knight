using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject mimic;
    public GameObject nextLevel;
    public GameObject unseal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Monster>().health <= 0)
        {
            mimic.SetActive(true);
            nextLevel.SetActive(true);
            unseal.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            boss.SetActive(true);
    }
}
