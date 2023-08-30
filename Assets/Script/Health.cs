using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Monster mon;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        mon = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = localScale;
    }
}
