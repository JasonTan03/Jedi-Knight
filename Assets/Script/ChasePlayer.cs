using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public Animator animator;
    void Update()
    {
        followTarget();
    }

    private void followTarget()
    {
        if(target != null)
        {
            Vector2 distance = target.position - transform.position;

            transform.Translate(new Vector3(distance.x, 0, 0) * moveSpeed * Time.deltaTime);
            
        }
    }


}
