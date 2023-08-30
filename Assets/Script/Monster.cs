using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public int health = 100;
    public float damage;
    public HeatlhBar playerHealth;
    public ChasePlayer mon;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
        mon = GameObject.FindGameObjectWithTag("Monster").GetComponent<ChasePlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int attackPower)
    {
        // Tints the sprite red and fades back to the origin color after a delay of 1 second
        StartCoroutine(DamageEffectSequence(sr, Color.red, 2, 1));
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
        Debug.Log("Die");
        StartCoroutine(Wait());
        Destroy(gameObject);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.DecreaseHP(damage);
            mon.moveSpeed = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        mon.moveSpeed = 1;
    }



}
