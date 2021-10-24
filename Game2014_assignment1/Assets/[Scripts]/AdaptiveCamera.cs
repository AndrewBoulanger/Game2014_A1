///
///Author: Andrew Boulanger 101292574
///
/// File: AdaptiveCamera.cs
/// 
/// Description: changes camera hight and viewport rect to match the screen to the size of the phone safe area
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 added file
///     v2 added static class for constant screen size.
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSize
{
    public const int width = 21;
}


///changes camera hight and viewport rect to match the screen to the size of the phone safe area
public class AdaptiveCamera : MonoBehaviour
{
    ScreenOrientation orientation;

    Camera camera;
    public float targetScreenWidth = ScreenSize.width;
    public Rect targetResolution;
    private Rect newViewPortRect;


    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
       UpdateCameraViewPort();
       AdjustToResolution();

    }

    // Update is called once per frame
    void Update()
    {

        if (Screen.orientation != orientation)
        {
           UpdateCameraViewPort();
           AdjustToResolution();
        }
    }

    //credit to gamedev.stackexchange.com user DMGregory
    void AdjustToResolution()
    {
        float widthPerPixel = targetScreenWidth / Screen.safeArea.width;
        float desiredHalfHeight = 0.5f * widthPerPixel * Screen.safeArea.height;

        camera.orthographicSize = desiredHalfHeight;
        
    }

    ///called when screen orientation changes, updates main camera viewport rect
    void UpdateCameraViewPort()
    {
        orientation = Screen.orientation;

        newViewPortRect.width = (Screen.safeArea.width / targetResolution.width);
        newViewPortRect.height = (Screen.safeArea.height / targetResolution.height);
        newViewPortRect.position = Screen.safeArea.position / targetResolution.size;

        camera.rect = newViewPortRect;

    }

}