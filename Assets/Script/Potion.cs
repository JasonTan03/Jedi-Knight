using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public ParticleSystem heal;
    public UImanager UImanager;
    public AudioManager audioManager;
    public HeatlhBar health;
    public playerMovement player;
    public Text potionCount;
    public static int numpotion=5;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        potionCount.text = numpotion.ToString();
        if (Input.GetKeyDown(KeyCode.L) == true && player.isalive == true)
        {
            Heal();
        }
    }
    public void Heal()
    {
        
        if (numpotion != 0 && HeatlhBar.hp != HeatlhBar.maxhp)
        {
            heal.Play();
            UImanager.heal(player.gameObject, health.regenerate);
            audioManager.playSFX(audioManager.heal);
            
            numpotion -= 1;
            HeatlhBar.hp += health.regenerate;
            if (HeatlhBar.hp >= HeatlhBar.maxhp)
                HeatlhBar.hp = HeatlhBar.maxhp;
        }
    }
}
