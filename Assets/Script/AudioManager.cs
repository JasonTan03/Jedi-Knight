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
    [Header("----------Audio Clip--------------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip c_hit;
    public AudioClip heal;
    public AudioClip pressButton;
    public AudioClip touchGround;
    public AudioClip appear;
    public AudioClip boss;
    public AudioClip grass;
    public AudioClip brick;
    public void Start()
    {
        playBackground(); 
        if (footstepSource.clip !=null)
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


}
