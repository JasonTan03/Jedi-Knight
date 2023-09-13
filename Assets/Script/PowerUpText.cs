using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpText : MonoBehaviour
{
    public Vector3 movespeed = new Vector3(0, 75, 0); //text fade speed
    RectTransform textTransform; //text transform
    public float timeToFade = 1f; //text fade time
    private float timeElapsed = 0f;

    TextMeshProUGUI textMeshPro;
    private Color startColor; // text start color

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textTransform.position += movespeed * Time.deltaTime;

        timeElapsed += Time.deltaTime;

        if(timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a *(1-timeElapsed/timeToFade);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
