///////-------------------------------------------------------
/// ButtonBehaviour.cs created by Andrew Boulanger 101292574
/// Last modified Oct 2, 2021
/// added to button objects to call unity button events
/// used to change scenes or quit the application
//////------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
