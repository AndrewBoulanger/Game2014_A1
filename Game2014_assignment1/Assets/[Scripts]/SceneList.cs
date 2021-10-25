///
///Author: Andrew Boulanger 101292574
///
/// File: SceneList.cs
/// 
/// Description: list of scenes. used for changing to a specific scene without using buttons/tags. 
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 created file. only used to switch from the game scene to the game over screen
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// list of scenes. used for changing to a specific scene without using tags
/// </summary>
public static class SceneList 
{
    public const int startScene = 0;
    public const int instructions1 = 1;
    public const int instructions2 = 2;
    public const int instructions3 = 3;
    public const int scoresScreen = 4;
    public const int gameScene = 5;
    public const int GameOverScreen = 6;
}
