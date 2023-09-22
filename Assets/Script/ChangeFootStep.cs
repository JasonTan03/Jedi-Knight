using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFootStep : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioManager.footstepSource.clip = audioManager.brick;
            audioManager.footstepSource.pitch = 1.49f;
            audioManager.footstepSource.Play();
            audioManager.footstepSource.Pause();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.footstepSource.clip = audioManager.grass;
            audioManager.footstepSource.pitch = 1f;
            audioManager.footstepSource.Play();
            audioManager.footstepSource.Pause();
        }
    }
}
