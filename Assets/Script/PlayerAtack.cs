using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{

    public Animator animator;
    public UImanager UImanager;

    bool hitEnemy = false;
    public float attackRange = 0.5f;
    public static float attackPower=10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public static int critRate = 2;

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
        animator.SetTrigger("LightAttack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Light Attack");
        foreach (Collider2D enemy in hit)
        {
            if (Random.Range(1,10) <= critRate)
            {
                audioManager.playSFX(audioManager.c_hit);
                int finalattack = (int)(attackPower + sword.AttackPower) * 2;
                enemy.GetComponent<Monster>().TakeDamage(finalattack);
                UImanager.CriticalDamageEnemy(gameObject, finalattack);
                hitEnemy = true;
                Debug.Log("Critical hit");
            }
            else
            {
                audioManager.playSFX(audioManager.hit);
                int finalattack = (int)(attackPower + sword.AttackPower);
                enemy.GetComponent<Monster>().TakeDamage(finalattack);
                UImanager.DamageEnemy(gameObject, finalattack);
                hitEnemy = true;
                Debug.Log("hit");
            }
            
            
        }
        if (hitEnemy == false)
        {
            audioManager.playSFX(audioManager.attack);
        }
        hitEnemy = false;
    }
    void HeavyAttack()
    {
        audioManager.playSFX(audioManager.attack);
        animator.SetTrigger("HeavyAttack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Heavy Attack");
        foreach (Collider2D enemy in hit)
        {
            if (Random.Range(1, 10) <= critRate)
            {
                int finalattack = (int)(((attackPower + sword.AttackPower) * 1.5) * 2);
                audioManager.playSFX(audioManager.c_hit);
                enemy.GetComponent<Monster>().TakeDamage(finalattack);
                UImanager.CriticalDamageEnemy(gameObject, finalattack);
                hitEnemy = true;
                Debug.Log("Critical hit");
            }
            else
            {
                int finalattack = (int)((attackPower + sword.AttackPower) * 1.5);
                audioManager.playSFX(audioManager.hit);
                enemy.GetComponent<Monster>().TakeDamage(finalattack);
                UImanager.DamageEnemy(gameObject, finalattack);
                hitEnemy = true;
                Debug.Log("hit");
            }

        }
        if (hitEnemy == false)
        {
            audioManager.playSFX(audioManager.attack);
        }
        hitEnemy = false;
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
