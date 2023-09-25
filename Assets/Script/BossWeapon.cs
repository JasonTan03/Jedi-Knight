using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	HeatlhBar health;
	AudioManager audioManager;
    private UImanager UImanager;

    private void Start()
    {
		health = GameObject.FindGameObjectWithTag("Health").GetComponent<HeatlhBar>();
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        UImanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UImanager>();
    }

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
            UImanager.MonsterDamage(gameObject, attackDamage);
            health.DecreaseHP(attackDamage);
			audioManager.playSFX(audioManager.hitPlayer);
        }
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
            UImanager.MonsterDamage(gameObject, attackDamage);
            colInfo.GetComponent<HeatlhBar>().DecreaseHP(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

	void playAttackSound()
	{
		audioManager.playSFX(audioManager.bossAttack);
	}

    void playwalkSound()
    {
        audioManager.playSFX(audioManager.bossWalk);
    }

    void playDeathSound()
    {
        audioManager.playSFX(audioManager.bossDeath);
    }
}