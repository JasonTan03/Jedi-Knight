using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class volumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private GameObject gc;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()

    {
        
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadMusicVolume();
        }
        else
            setMusicVolume();

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadSfxVolume();
        }
        else
            setSfxVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setMusicVolume()
    { 
        float volume =musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadMusicVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        setMusicVolume();
    }

    public void setSfxVolume()
    {
        float volumesfx = sfxSlider.value;
        myMixer.SetFloat("Sfx", Mathf.Log10(volumesfx) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volumesfx);
        myMixer.SetFloat("FootStep", Mathf.Log10(volumesfx) * 20);
        myMixer.SetFloat("NPC", Mathf.Log10(volumesfx) * 20);
    }

    private void LoadSfxVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        setSfxVolume();
    }
}
