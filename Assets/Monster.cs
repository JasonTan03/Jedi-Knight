using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public int health = 100;
    public float damage;
    public HeatlhBar playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int attackPower)
    {
        health -= attackPower;
        if (health <= 0)
        {
            monsterDead();
        }
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
        }
    }

}
