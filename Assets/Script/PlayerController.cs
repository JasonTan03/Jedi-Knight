using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float incAttack;
    public float incHealth;
    public int incCrit;
    public UImanager UIManager;
    // Start is called before the first frame update
    void Start()
    {

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
            HeatlhBar.maxhp += incHealth;
            UIManager.takeHealthPowerUp(this.gameObject);

        }

        if (other.gameObject.CompareTag("PowerUpAttack"))
        {
            Destroy(other.gameObject);
            PlayerAtack.attackPower+= incAttack;
            UIManager.takeDamagePowerUp(this.gameObject);
        }

        if (other.gameObject.CompareTag("PowerUpCritical"))
        {
            Destroy(other.gameObject);
            PlayerAtack.critRate += incCrit;
            UIManager.takeCriticalPowerUp(this.gameObject);

        }

        if (other.gameObject.CompareTag("potion"))
        {
            Destroy(other.gameObject);
            Potion.numpotion++;
            UIManager.potion(this.gameObject    );

        }
    }
}

