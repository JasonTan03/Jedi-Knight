using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickering : MonoBehaviour
{
    // Start is called before the first frame update
    private Light2D light;
    public float max;
    public float min;
    void Start()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Flash()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(min,max));
            light.enabled = !light.enabled;
        }
    }
}
