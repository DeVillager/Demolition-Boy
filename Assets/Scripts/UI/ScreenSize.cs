using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    void Start()
    {
        //Screen.fullScreen = !Screen.fullScreen;
        Screen.SetResolution(800, 600, true);
    }
}
