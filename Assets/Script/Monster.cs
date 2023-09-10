using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public float health = 100;
    public float damage;
    HeatlhBar playerHealth;
    ChasePlayer mon1;
    EnemyPatrol mon2;
    public SpriteRenderer sr;
    public int delay = 1;
    float tempSpeed1;
    float tempSpeed2;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
        mon1 = GameObject.FindGameObjectWithTag("Monster").GetComponent<ChasePlayer>();
        mon2 = GameObject.FindGameObjectWithTag("Monster").GetComponent<EnemyPatrol>();

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
            monsterDead();
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
    void monsterDead()
    {
        anim.SetBool("IsDead",true);
        Debug.Log("Die");
        StartCoroutine(Wait());
        Destroy(gameObject);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.DecreaseHP(damage);
            tempSpeed1 = mon1.moveSpeed;
            tempSpeed2 = mon2.speed;
            mon1.moveSpeed = 0;
            mon2.speed = 0;

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        mon1.moveSpeed = tempSpeed1;
        mon2.speed = tempSpeed2;
    }



}
