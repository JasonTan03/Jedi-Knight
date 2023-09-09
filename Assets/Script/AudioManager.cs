using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("----------Audio Source------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [Header("----------Audio Clip--------------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip attack;
    public AudioClip hit;
    public AudioClip c_hit;
    public AudioClip heal;

    public void Start()
    {
        musicSource.Play(); 
    }

    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
