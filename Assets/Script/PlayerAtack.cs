using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{

    public Animator animator;

    public float attackRange = 0.5f;
    public float attackPower;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public Sword sword;
    public playerMovement player;
    public staminabar enegry;
    // Start is called before the first frame update

    //audio
    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<Sword>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        enegry = GameObject.FindGameObjectWithTag("Stamina").GetComponent<staminabar>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J) && player.isalive == true && player.isJumping == false)
            {
                LightAttack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K) && player.isalive == true && enegry.stamina > 10 && player.isJumping == false)
            {
                enegry.DecreaseStamina(10f);
                HeavyAttack();
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }

    void LightAttack()
    {
        audioManager.playSFX(audioManager.attack);
        animator.SetTrigger("LightAttack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Light Attack");
        foreach (Collider2D enemy in hit)
        {
                enemy.GetComponent<Monster>().TakeDamage((int)(attackPower + sword.AttackPower));
                Debug.Log("hit");
        }
    }
    void HeavyAttack()
    {
        audioManager.playSFX(audioManager.attack);
        animator.SetTrigger("HeavyAttack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Heavy Attack");
        foreach (Collider2D enemy in hit)
        {
            enemy.GetComponent<Monster>().TakeDamage((int)((attackPower + sword.AttackPower) * 1.5));
            Debug.Log("hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
