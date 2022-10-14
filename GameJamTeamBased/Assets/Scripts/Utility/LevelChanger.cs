using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {   Debug.Log(" About to load the new scene");
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIN");
        Debug.Log(" Scene should be loaded");
        
    }
}


