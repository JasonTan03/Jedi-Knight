using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    public static float hp = 100;
    public static float maxhp = 100;
    public Slider hpBar;
    public float decrease;
    public float regenerate;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = hp;
        hpBar.maxValue = maxhp;
    }

    public void DecreaseHP(float damage)
    { 
        animator.SetTrigger("PlayerHit");
        if (hp != 0)
        {
            if (hp != 0)
                hp = hp - decrease - damage;
            if (hp <= -1)
                hp = 0;
        }
    }

}
