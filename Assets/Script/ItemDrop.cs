using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float speed;
    private float startTime = 0f;
    private float endTime = 1.5f;
    private Rigidbody2D itemRB;
    public float dropForce=5;
    // Start is called before the first frame update
    void Start()
    { 
        itemRB = GetComponent<Rigidbody2D>();
        itemRB.AddForce(itemRB.mass*Vector2.up*dropForce,ForceMode2D.Impulse); 
    }

    void Update()
    {
        if(startTime <endTime)
        {
            startTime += Time.deltaTime;
            itemRB.transform.position += new Vector3(UnityEngine.Random.Range(-3,3)*Time.deltaTime*speed, 0,0);
        }
    }

}
