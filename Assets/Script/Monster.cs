using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
