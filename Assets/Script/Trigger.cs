using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TriggerBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject mimic;
    public GameObject nextLevel;
    public GameObject unseal;
    public Light2D light;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager  = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Monster>().health <= 0)
        {
            mimic.SetActive(true);
            nextLevel.SetActive(true);
            unseal.SetActive(false);
            light.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boss.SetActive(true);
            audioManager.playBossMusic();

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            audioManager.playBackground();

        }
    }
}
