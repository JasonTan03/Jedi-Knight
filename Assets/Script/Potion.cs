using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public HeatlhBar health;
    public playerMovement player;
    public Text potionCount;
    public int numpotion;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        numpotion = 5;
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
        if (numpotion != 0 && health.hp != health.maxhp)
        {
            numpotion -= 1;
            health.hp += health.regenerate;
            if (health.hp >= health.maxhp)
                health.hp = health.maxhp;
        }
    }
}
