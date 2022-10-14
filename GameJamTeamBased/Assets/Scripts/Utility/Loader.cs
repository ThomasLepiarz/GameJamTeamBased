using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    //where I am 
    //public string currentSceneName;
    //where I wanna go 
    public string transitionScene;

    public void Load(string transitionScene)
    {   //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("You changed Scene to:" + transitionScene);
        SceneManager.LoadScene(transitionScene);

    }
    public void LoadSartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
