using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    private ChasePlayer parent;
    private EnemyPatrol patrol;
    private void Start()
    {
        patrol = GetComponentInParent<EnemyPatrol>();
        parent = GetComponentInParent<ChasePlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //patrol.enabled = false;
        //parent.enabled = true;
        if (other.gameObject.CompareTag("Player"))
        {
            parent.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //parent.enabled = false;
        //patrol.enabled = true;
        if (other.gameObject.CompareTag("Player"))
        {
            parent.target = null;
        }
    }

}
