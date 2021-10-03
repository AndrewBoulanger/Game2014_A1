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
        SceneManager.LoadScene(tag);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadlastLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
