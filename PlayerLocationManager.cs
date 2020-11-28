using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLocationManager : MonoBehaviour
{

    Scene sceneName;

    int SceneBuildIndex;

    string MsceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        MsceneName = sceneName.name;
    }
    // Update is called once per frame
    void Update()
    {
        SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
         
        SceneNumerator();
        
    }

    public void SceneNumerator()
    {

        FindObjectOfType<UIScript>().sceneNumber = SceneBuildIndex;

        /*
        if(MsceneName == "TutorialLevel")
        {
            FindObjectOfType<UIScript>().sceneNumber = 1f;
        }
        if (MsceneName == "Tutorial2")
        {
            FindObjectOfType<UIScript>().sceneNumber = 2f;
        }
        if (MsceneName == "Tutorial3")
        {
            FindObjectOfType<UIScript>().sceneNumber = 3f;
        }
        if (MsceneName == "ChallangeLevel1")
        {
            FindObjectOfType<UIScript>().sceneNumber = 4f;
        }
        if (MsceneName == "ChallangeLevel2")
        {
            FindObjectOfType<UIScript>().sceneNumber = 5f;
        }
        */
    }

}
