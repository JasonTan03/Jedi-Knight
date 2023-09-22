using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordType : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 2)
        {
            player.SetBool("WoodSword", false);
            player.SetBool("IronSword", true);
            player.SetBool("MagicSword", false);
            player.SetBool("MushroomSword", false);
        }
        if (y == 3 || y == 4)
        {
            player.SetBool("WoodSword", false);
            player.SetBool("IronSword", false);
            player.SetBool("MagicSword", true);
            player.SetBool("MushroomSword", false);
        }
        if (y == 4 && Summon.MushroomKingDead == true)
        {
            player.SetBool("WoodSword", false);
            player.SetBool("IronSword", false);
            player.SetBool("MagicSword", false);
            player.SetBool("MushroomSword", true);
        }
    }
}
