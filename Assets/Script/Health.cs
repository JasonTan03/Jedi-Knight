using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Monster mon;
    Vector3 localScale;
    Vector3 ogscale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        ogscale = localScale;
        mon = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        //localScale.x = (mon.health/100) * ogscale;
        transform.localScale = localScale;
    }
}
