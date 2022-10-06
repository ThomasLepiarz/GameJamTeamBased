using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;


using Enums;


public class GameManager : MonoBehaviour
{

    #region Fields

    public static GameManager Instance;
    private static AudioManager _audioManager;
    private static TaskManager _taskManager;
    public LevelChanger levelChanger;

    public GameObject MenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject BedroomCanvas;
    public GameObject HallCanvas;
    public GameObject SnakeCanvas;
    public GameObject LivingRoomCanvas;
    public GameObject KitchenCanvas;
    public GameObject BathroomCanvas;
    public GameObject GarageCanvas;

    #endregion

    #region Properties

    private int _dayCount;

    public int DayCount
    {
        get { return _dayCount; }
        private set { _dayCount = value; }
    }

    private int _currentDay;

    public int CurrentDay
    {
        get { return _currentDay; }
        private set { _currentDay = value; }
    }

    private int _currentTask;

    public int CurrentTask
    {
        get { return _currentTask; }
        set { _currentTask = value; }
    }

    #endregion

    #region Public Methods

    public void QuitSnake()
    {
        SceneManager.LoadScene(Scenes.Bedroom.ToString());
    }

    public void SwitchState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Starting:
                Debug.Log("Game Starting");
                Instance.MenuCanvas.SetActive(true);
                Instance.CreditsCanvas.SetActive(false);
                Instance.BedroomCanvas.SetActive(false);
                Instance.HallCanvas.SetActive(false);
                Instance.LivingRoomCanvas.SetActive(false);
                Instance.KitchenCanvas.SetActive(false);
                Instance.SnakeCanvas.SetActive(false);
                Instance.GarageCanvas.SetActive(false);
                _audioManager.playMenuMusic();
                break;

            case GameState.NewGame:
                Instance.MenuCanvas.SetActive(false);
                Instance.BedroomCanvas.SetActive(true);
                break;

            case GameState.Bedroom:
                Instance.HallCanvas.SetActive(false);
                Instance.BedroomCanvas.SetActive(true);
                break;

            case GameState.Bathroom:
                Instance.BathroomCanvas.SetActive(true);

                break;

            case GameState.Kitchen:
                break;

            case GameState.LivingRoom:
                break;

            case GameState.Garage:
                break;

            case GameState.Hallway:
                break;

            case GameState.BadEnding:
                break;

            case GameState.NextDay:
                break;

            case GameState.GoodEnding:
                break;

            default:
                break;
        }



    }

    //Go to main menu from credits
    public void GoToMainMenu()
    {
        Debug.Log("Clicked Back Button");
        Instance.CreditsCanvas.SetActive(false);
        Instance.MenuCanvas.SetActive(true);
    }

    //Transfer to bedroom
    public void PlayGame()
    {
        Debug.Log("Clicked Start Button");
        Instance.MenuCanvas.SetActive(false);
        Instance.BedroomCanvas.SetActive(true);
    }

    //Quit Game... duh
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //GoToCredits from main menu
    public void GoToCredits()
    {
        Instance.MenuCanvas.SetActive(false);
        Instance.CreditsCanvas.SetActive(true);
        Debug.Log("Clicked Credits Button");
    }

    #endregion

    #region Private Methods

    //instantiates GameManager and thus all Manager children
    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("DestroyObject");
            Destroy(gameObject);
            return;
        }
       
        Instance = this;
        Debug.Log(Instance.GetComponent<AudioManager>());
        _audioManager = Instance.GetComponent<AudioManager>();
        Debug.Log(Instance);
        DontDestroyOnLoad(gameObject);
        Instance.SwitchState(GameState.Starting);       
    }

    //loads the first BedRoom screen and starts tasks off
    //starts of tasks
    //is triggered when clicking on the start button
    private void HandleNewGame()
    {
        Debug.Log("loading BedRoom");
        levelChanger.FadeToLevel("BedRoom");
        _currentTask = (int)Tasks.Coffee;
    }

    //called when changing to the good ending
    private void HandleGoodEnding()
    {
    levelChanger.FadeToLevel("GoodEnding");
    }

    public void HandleNextDay()
    {
        _dayCount += 1;
        Debug.Log("THIS IS THE CURRENT DAY: " + _dayCount);
        if (_dayCount == 2)
        {
            SceneManager.LoadScene(Scenes.GoodEnding.ToString());
        }
    }

    //go to bad ending call
    private void HandleBadEnding()
    {
        Debug.Log("loading Bad Ending");
        levelChanger.FadeToLevel("BadEnding");
    }

    #endregion

}