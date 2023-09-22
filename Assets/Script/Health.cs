using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float monsTotalHealth=100f;
    public Monster mon;
    Vector3 localScale;
    Vector3 orignalScale;
 
    // Start is called before the first frame update
    void Start()
    {
        localScale = orignalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = (mon.health/monsTotalHealth) * orignalScale.x;
        transform.localScale = localScale;
    }
}
