using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    public GameObject elite;
    public GameObject gate;
    public GameObject bob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elite.GetComponent<Monster>().health <= 0)
        {
            gate.SetActive(false);
            bob.SetActive(true);
        }
    }
}
