using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayer : MonoBehaviour
{
    public float speed;
    private float startTime = 0f;
    private float endTime = 1.5f;
    private Rigidbody2D itemRB;
    public float dropForce = 5;
    int randomnum;
    private bool touch = false;
    // Start is called before the first frame update
    void Start()
    {
        randomnum = UnityEngine.Random.Range(1, 5);
        Debug.Log(randomnum);
        itemRB = GetComponent<Rigidbody2D>();
        itemRB.AddForce(itemRB.mass * Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (touch == false)
        {
            itemRB.transform.position += new Vector3(randomnum * Time.deltaTime * speed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            touch = true;
    }
}
