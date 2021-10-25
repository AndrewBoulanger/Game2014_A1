
///
///Author: Andrew Boulanger 101292574
///
/// File: MusicPlayer.cs
/// 
/// Description: singleton which plays background music and holds a pool of sound effects players
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 originally only played background music between
///     v2 made it a singleton so it could continue playing the instruction screen music between scenes
///     v3 also gave it a pool to play sound effects
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// singleton which plays background music and holds a pool of sound effects players
/// </summary>
public class MusicPlayer
{
    private static MusicPlayer instance = null;
    private AudioSource musicPlayer;
    private float volume = 0.1f;

    private ObjectPool SFXPlayersPool;

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

    // sets up the game objects owned by the music player
    void Initialize()
    {
        GameObject audioSourceObject = new GameObject();
        GameObject.DontDestroyOnLoad(audioSourceObject);
        musicPlayer = audioSourceObject.AddComponent<AudioSource>();
        
        musicPlayer.volume = volume;
        musicPlayer.loop = true;

        GameObject sfxplyer_prefab = Resources.Load("Prefabs/SFXPlayer") as GameObject;
        SFXPlayersPool = new ObjectPool(sfxplyer_prefab);

    }

    //allows the background music object to change the music when changing scenes
    public void SetBackGroundMusic(AudioClip music)
    {
        if(music != musicPlayer.clip)
        { 
            musicPlayer.clip = music;
            musicPlayer.Play();
        }
    }

    public void setVolume(float volume)
    {
        musicPlayer.volume = volume;
    }
   
    //adds an inactive sound effect player from a pool into the scene, playing the passed in clip. the sfxplayer is returned to the pool when the clip is done
    public void PlaySFX(AudioClip clip)
    {
        GameObject sfxPlayer = SFXPlayersPool.GetObject(Vector3.zero);
        GameObject.DontDestroyOnLoad(sfxPlayer);
        sfxPlayer.GetComponent<AudioSource>().PlayOneShot(clip);
        sfxPlayer.GetComponent<SFXPlayer>().owner = SFXPlayersPool;

    }

}
