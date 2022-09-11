﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentTask;
    

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
        //if(PauseMenu.isPaused)
    }

    //WILL MAYBE CHANGE
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; private set; }

    // Start is called before the first frame update
    void Start() => ChangeState(GameState.Starting);
    

   public void ChangeState(GameState newState){
   Debug.Log("This is the GameState: " + State);
    // prevents duplicate state changes;
    if (State == newState) return;
    // the T? syntactic means Nullable<T> which allows T to be null
    OnBeforeStateChanged?.Invoke(newState);

    State = newState;
    switch (newState)
    {
        case GameState.Starting:
            HandleStarting();
            break;
        case GameState.NewGame:
            HandleNewGame();
            break;
        case GameState.ChangeRoom:
            HandleChangeRoom();
            break;
        case GameState.LifeEvent:
            HandleLifeEvent();
            break;
        case GameState.BadEnding:
            HandleBadEnding();
            break;
        case GameState.NextDay:
            HandleNextDay();
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }
    OnAfterStateChanged?.Invoke(newState);

    Debug.Log($"New state: {newState}");
   }

private void HandleStarting() {
    // GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
   
}

private void HandleNewGame() {
    Debug.Log("loading BedRoom");
    UnityEngine.SceneManagement.SceneManager.LoadScene("BedRoom");
    currentTask = 1;
}
private void HandleChangeRoom() {


}
private void HandleLifeEvent(){
 // Add a Life Event
}

// [SerializeField] public TextMeshProUGUI myKaffe; 
// [SerializeField] public TextMeshProUGUI myArbeit; 
// [SerializeField] public TextMeshProUGUI myEssen; 

private void HandleBadEnding(){

    
}
private void HandleNextDay(){

}


public enum GameState {
    Starting = 0,
    NewGame = 1,
    ChangeRoom = 2,
    LifeEvent = 3,
    BadEnding = 4,
    NextDay = 5,
    GoodEnding = 6,
}
}