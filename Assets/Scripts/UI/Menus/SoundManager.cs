using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource battleSource;

	// Use this for initialization
	void Start ()
    {
        musicSource.volume = Settings.instance.musicVolume;

        sfxSource.volume = Settings.instance.sfxVolume;

        battleSource.volume = Settings.instance.battleVolume;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (musicSource.volume != Settings.instance.musicVolume)
            musicSource.volume = Settings.instance.musicVolume;

        if (sfxSource.volume != Settings.instance.sfxVolume)
            sfxSource.volume = Settings.instance.sfxVolume;

        if (battleSource.volume != Settings.instance.battleVolume)
            battleSource.volume = Settings.instance.battleVolume;

    }
}
