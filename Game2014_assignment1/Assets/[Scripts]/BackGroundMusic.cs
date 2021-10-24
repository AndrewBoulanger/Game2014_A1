///
///Author: Andrew Boulanger 101292574
///
/// File: BackgroundMusic.cs
/// 
/// Description: changes the background when the scene starts. uses the music player singleton
/// 
/// last Modified: Oct 19th 2021
///
/// version history: 
///     v1 added file, set it to call hold an audio clip and call the music player
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// changes the background when the scene starts. uses the music player singleton
/// </summary>
public class BackGroundMusic : MonoBehaviour
{
    public AudioClip musicFile;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer.Instance().SetBackGroundMusic(musicFile);
        MusicPlayer.Instance().setVolume(volume);
    }


}
