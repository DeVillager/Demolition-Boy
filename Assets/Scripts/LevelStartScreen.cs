using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //GameObject.FindWithTag("SplashScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
