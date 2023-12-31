using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public AudioSource footstepSource;
    public AudioSource npc;
    [Header("----------Audio Clip--------------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip c_hit;

    public AudioClip hitPlayer;
    public AudioClip heal;
    public AudioClip pressButton;
    public AudioClip touchGround;
    public AudioClip appear;
    public AudioClip boss;
    public AudioClip grass;
    public AudioClip brick;
    public AudioClip bossAttack;
    public AudioClip bossWalk;
    public AudioClip bossDeath;
    public AudioClip bob;
    public AudioClip mimic;
    public void Start()
    {
        playBackground(); 
        if (footstepSource.clip !=null)
        {
            footstepSource.Pause();
        }

        if (npc.clip != null)
        {
            footstepSource.Pause();
        }
    }

    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void playFootstep()
    {
            footstepSource.UnPause();

    }

    public void pauseFootsetp()
    {
        footstepSource.Pause();
    }
    public void playBossMusic()
    {
        musicSource.clip = boss;
        musicSource.Play();
    }

    public void playBackground()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


    public void BobClip()
    {
        npc.clip = bob;
    }

    public void MimicClip()
    {
        npc.clip = mimic;
    }


}
