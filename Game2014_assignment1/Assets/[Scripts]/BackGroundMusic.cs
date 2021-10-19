using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
