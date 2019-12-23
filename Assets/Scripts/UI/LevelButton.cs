using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelNumber;

    public void LoadLevel()
    {
        // SoundManager.Instance.PlayOrPauseMusic();
        //GameManager.instance.level = levelNumber;
        if (GameManager.instance != null)
        {
            GameManager.instance.level = levelNumber;
            GameManager.instance.LoadScene(levelNumber);
        }
        else
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
