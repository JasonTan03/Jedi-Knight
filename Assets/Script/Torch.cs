using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    private Light2D light;
    public float minTime;
    public float maxTime;
    
    public int minIntensity;
    public int maxIntensity;
   
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(TorchLight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TorchLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTime, maxTime));
            light.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
