 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Monster : MonoBehaviour
{
    public ParticleSystem bossBlood;
    public GameObject[] item;
    public int numberOfDrop;
    public float health = 100;
    public float damage;
    HeatlhBar playerHealth;
    public SpriteRenderer sr;
    public int delay = 1;
    public Animator anim;

    public Transform player;
    public bool isFlipped = false;
    public UImanager UImanager;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int attackPower)
    {
        anim.SetTrigger("IsHurt");
        // Tints the sprite red and fades back to the origin color after a delay of 1 second
        StartCoroutine(DamageEffectSequence(sr, Color.red, 0.5f, 0.5f));
        health -= attackPower;
        if (health <= 0)
        {
            health = 0;
            Instantiate(bossBlood,transform.position, Quaternion.identity);
            DropItem();
            StartCoroutine(monsterDead());
        }
    }

    IEnumerator DamageEffectSequence(SpriteRenderer sr, Color dmgColor, float duration, float delay)
    {
        // save origin color
        Color originColor = sr.color;

        // tint the sprite with damage color
        sr.color = dmgColor;

        // you can delay the animation
        yield return new WaitForSeconds(delay);

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            sr.color = Color.Lerp(dmgColor, originColor, t);

            yield return null;
        }

        // restore origin color
        sr.color = originColor;
    }
    IEnumerator monsterDead()
    {
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UImanager.MonsterDamage(gameObject, damage);
            playerHealth.DecreaseHP(damage);
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void DropItem()
    {
        for (int i=0;i<numberOfDrop;i++)
        {
            Instantiate(item[UnityEngine.Random.Range(0,item.Length)],transform.position + new Vector3(0,3,0),quaternion.identity );
        }

    }

}
