using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Color original;
    // Start is called before the first frame update
    void Start()
    {
        original = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Turnback());
           
        }
    }

    private IEnumerator Turnback()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
