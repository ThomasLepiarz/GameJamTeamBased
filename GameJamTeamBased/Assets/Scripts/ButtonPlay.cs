using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    //Transfer to next scene in builder
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.ChangeState(GameManager.GameState.NewGame); 
        Debug.Log("Clicked Start Button");
    }

    //Quit Game... duh
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Credits()
    {
        GameManager.Instance.levelChanger.FadeToLevel("Credits");
        Debug.Log("Clicked Start Button");
    }
}