using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// wont be destroyed on load, shares audio
/// </summary>
public class MusicPlayer
{
    private static MusicPlayer instance = null;
    private AudioSource musicPlayer;
    private float volume = 0.1f;

    /// <summary>
    /// constructor
    /// </summary>
    private MusicPlayer()
    {
        Initialize();
    }

    public static MusicPlayer Instance()
    {
        if(instance == null)
        {
            instance = new MusicPlayer();
        }
        return instance;
    }

    // Start is called before the first frame update
    void Initialize()
    {
        GameObject audioSourceObject = new GameObject();
        GameObject.DontDestroyOnLoad(audioSourceObject);
        musicPlayer = audioSourceObject.AddComponent<AudioSource>();
        
        musicPlayer.volume = volume;
        musicPlayer.loop = true;

    }

    public void SetBackGroundMusic(AudioClip music)
    {
        musicPlayer.clip = music;
        musicPlayer.Play();
    }

    public void setVolume(float volume)
    {
        musicPlayer.volume = volume;
    }
   
}
