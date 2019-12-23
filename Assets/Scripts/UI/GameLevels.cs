using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using TMPro;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevels : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject levelButton;
    private int latestLevel;

    void Start()
    {

        //int[] points = LevelManager.instance.levelPoints;
        // string folderName = Application.dataPath + "/Scenes/FinalLevels";
        // var dirInfo = new DirectoryInfo(folderName);
        // var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        //List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        //EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();

        int scenes = SceneManager.sceneCountInBuildSettings;

        //EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        //scenes = scenes.Skip(2).ToArray();
        // Debug.Log("moi "+ scenes.Length);
        for (int i = 0; i < scenes - 2; i++)
        {
            //string levelName = Path.GetFileNameWithoutExtension(allFileInfos[i].FullName);
            string levelName = i+1+"";
            GameObject levelBtn = Instantiate(levelButton, Vector3.zero, Quaternion.identity);
            levelBtn.GetComponent<LevelButton>().levelNumber = i+1;
            levelBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelName;
            //levelBtn.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{points[i]} stars";
            //GameObject stars = levelBtn.transform.GetChild(1).gameObject;
            //if (points[i] != -1)
            //{
            //    for (int j = 0; j < points[i]; j++)
            //    {
            //        stars.transform.GetChild(j).gameObject.SetActive(true);
            //    }
            //}
            levelBtn.transform.SetParent(this.gameObject.transform);
            //if (points[i] == -1)
            //{
            //    levelBtn.GetComponent<Button>().interactable = false;
            //    levelBtn.transform.GetChild(1).gameObject.SetActive(false);
            //}
            //else
            //{
            //    latestLevel = i;
            //}
        }
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.GetChild(latestLevel).gameObject);
    }
}
