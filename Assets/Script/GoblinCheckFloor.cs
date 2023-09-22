using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCheckFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }




}
