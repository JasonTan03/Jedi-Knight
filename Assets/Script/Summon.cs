using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject mushroomKing;
    public GameObject mushroom;
    public GameObject mushroom2;

    public Animator anim;
    public static bool MushroomKingDead = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mushroomKing.GetComponent<Monster>().health < 0)
        {
            MushroomKingDead = true;
        }

        if (mushroomKing.GetComponent<Monster>().health < 100)
        {
            anim.SetBool("Summon", true);
            mushroom.SetActive(true);
            mushroom2.SetActive(true);
        }
    }


}
