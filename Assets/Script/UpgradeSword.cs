using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSword : MonoBehaviour
{
    public Animator player;
    public bool level1;
    public bool level2;
    public bool HLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(level1 && Input.GetKeyDown(KeyCode.E))
        {
            player.SetBool("WoodSword", false);
            player.SetBool("IronSword", true);
        }

        if (level2 && Input.GetKeyDown(KeyCode.E))
        {
            player.SetBool("IronSword", false);
            player.SetBool("MagicSword", true);
        }

        if (HLevel && Input.GetKeyDown(KeyCode.E))
        {
            player.SetBool("MagicSword", false);
            player.SetBool("MushroomSword", true);
        }
    }
}
