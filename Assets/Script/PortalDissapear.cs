using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalDissapear : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.52f);
        player.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        Destroy(gameObject);
    }
  
}
