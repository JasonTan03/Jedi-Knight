using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Color original;
    public float incAttack;
    public float incHealth;
    public int incCrit;
    public UImanager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        original = GetComponent<SpriteRenderer>().color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PowerUpHealth"))
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(Turnback());
            GetComponentInChildren<HeatlhBar>().maxhp += incHealth;
            UIManager.takeHealthPowerUp(this.gameObject);

        }

        if (other.gameObject.CompareTag("PowerUpAttack"))
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Turnback());
            GetComponent<PlayerAtack>().attackPower += incAttack;
            UIManager.takeDamagePowerUp(this.gameObject);
        }

        if (other.gameObject.CompareTag("PowerUpCritical"))
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(Turnback());
            PlayerAtack.critRate += incCrit;
            UIManager.takeCriticalPowerUp(this.gameObject);

        }
    }


    private IEnumerator Turnback()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
