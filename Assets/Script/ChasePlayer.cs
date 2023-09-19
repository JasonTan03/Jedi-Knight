using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public bool flip;
    public float moveSpeed;
    public Animator animator;
    float tempSpeed;
    void Update()
    {
        followTarget();
    }
    private void lookPlayer()
    {
        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
    }

    private void followTarget()
    {
        if(target != null)
        {
            //lookPlayer();
            Vector2 distance = target.position - transform.position;

            transform.Translate(new Vector3(distance.x, 0, 0) * moveSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tempSpeed = moveSpeed;
            moveSpeed = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        moveSpeed = tempSpeed;
    }

}
