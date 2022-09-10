using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    //WILL MAYBE CHANGE
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State {get; private set; }

    // Start is called before the first frame update
    void Start() => ChangeState(GameState.Starting);
    

   public void ChangeState(GameState newState){
   
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
    
}
private void HandleChangeRoom() {


}
private void HandleLifeEvent(){
 // Add a Life Event
}

private void HandleBadEnding(){

    
}
private void HandleNextDay(){

}


public enum GameState {
    Starting = 0,
    ChangeRoom = 1,
    LifeEvent = 2,
    BadEnding = 3,
    NextDay = 4,
    GoodEnding = 5,
}
}