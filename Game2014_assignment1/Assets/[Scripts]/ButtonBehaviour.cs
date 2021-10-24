/// Author: Andrew Boulanger 101292574
/// 
/// File: ButtonBehvaiour.cs
/// 
/// Description: loads scenes when a button is pressed
/// 
/// last Modified: Oct 19th 2021
///
/// version history: 
///     v1 loads scene based on tag or adjacent scene
///     v2 now plays sound effects when button is pressed
///     
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// loads scenes when a button is pressed
public class ButtonBehaviour : MonoBehaviour
{

    public void LoadScene()
    {
        PlaySoundEffect();
        SceneManager.LoadScene(tag);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        PlaySoundEffect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadlastLevel()
    {
        PlaySoundEffect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void PlaySoundEffect()
    {
        AudioClip sfx = Resources.Load("Audio/PageTurn") as AudioClip;
        MusicPlayer.Instance().PlaySFX(sfx);
    }
}
