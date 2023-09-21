using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileLight : MonoBehaviour
{
    public GameObject smile;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audioManager.playSFX(audioManager.appear);
            smile.SetActive(true);
        }
    }


}
