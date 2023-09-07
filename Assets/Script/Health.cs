using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Monster mon;
    Vector3 localScale;
    Vector3 orignalScale;
 
    // Start is called before the first frame update
    void Start()
    {
     
        localScale = orignalScale = transform.localScale;
        mon = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
        localScale.x = (mon.health/100f) * orignalScale.x;
        transform.localScale = localScale;
    }
}
