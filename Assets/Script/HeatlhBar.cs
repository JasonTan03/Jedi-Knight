using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public Slider hpBar;
    public float decrease;
    public float regenerate;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp;
        hpBar.maxValue = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = hp;
    }

    public void DecreaseHP(float damage)
    {
        if (hp != 0)
        {
            if (hp != 0)
                hp = hp - decrease - damage;
            if (hp <= -1)
                hp = 0;
        }
    }

}
