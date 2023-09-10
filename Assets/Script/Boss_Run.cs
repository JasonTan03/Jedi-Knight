using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{

	public float speed = 2.5f;
	public float attackRange = 3f;
	float nextAttackTime = 1f;
	public float attackRate = 1f;

	Transform player;
	Rigidbody2D rb;
	Boss boss;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		boss.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		if (Time.time >= nextAttackTime)
		{
			if (Vector2.Distance(player.position, rb.position) <= attackRange)
			{
				animator.SetTrigger("BringerBossAttack");
			}
			nextAttackTime = Time.time + 2f / attackRate;
		}

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("BringerBossAttack");
	}
}