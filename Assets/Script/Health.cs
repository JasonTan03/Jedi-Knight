using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Monster mon;
    Vector3 localScale;
<<<<<<< Updated upstream
    Vector3 ogscale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        ogscale = localScale;
=======
    Vector3 orignalScale;
    // Start is called before the first frame update
    void Start()
    {
        
        localScale = orignalScale = transform.localScale;
>>>>>>> Stashed changes
        mon = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        //localScale.x = (mon.health/100) * ogscale;
=======
        
        localScale.x = (mon.health/100f) * orignalScale.x ;
>>>>>>> Stashed changes
        transform.localScale = localScale;
    }
}
