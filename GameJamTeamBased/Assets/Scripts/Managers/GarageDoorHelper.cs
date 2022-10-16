using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enums;
using Everyday;

public class GarageDoorHelper: MonoBehaviour
{
    #region Fields

    private int _garageDoorTries = 0;

    #endregion

    #region Public Functions

    //Switches to next task if correct task was done
    //also gives auditory feedback
    public void CheckTaskCompleteGarageDoor()
    {
        switch (_garageDoorTries)
        {
            case 0:
                //PlayVoiceLine Garage1
                _garageDoorTries++;
                break;
            case 1:
                //PlayVoiceLine Garage2
                _garageDoorTries++;
                break;
            case 2:
                //PlayVoiceLine Garage3
                _garageDoorTries++;
                break;
            case 3:
                GameManager.Instance.SwitchState(GameState.Garage);
                break;
            default:
                break;
        }
    }

    #endregion
}
