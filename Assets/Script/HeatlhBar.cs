using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject bloodscreen;
    private float timeToFade = 0.7f; //screen fade time
    private float timeElapsed = 0f;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        startColor = bloodscreen.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = hp;
        hpBar.maxValue = maxhp;
        
        if(bloodscreen.activeInHierarchy==false)
        {
            timeElapsed = 0;
            bloodscreen.GetComponent<Image>().color = new Color (startColor.r,startColor.g,startColor.b,startColor.a);               
        }
        else
        {
            if (timeElapsed < timeToFade)
            {
                float fadeAlpha = startColor.a * (1 - timeElapsed / timeToFade);
                bloodscreen.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
                timeElapsed += Time.deltaTime;
            }
            
        }
        if(timeElapsed>timeToFade)
        {
            bloodscreen.SetActive(false);
        }
    }

    public void DecreaseHP(float damage)
    { 
        animator.SetTrigger("PlayerHit");
        if (hp != 0)
        {
            bloodscreen.SetActive(true);
            if (hp != 0)
                hp = hp - decrease - damage;
            if (hp <= -1)
                hp = 0;
        }
    

    }

    

}
