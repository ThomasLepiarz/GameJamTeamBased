using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enums;
using Everyday;

public class GarageDoorHelper: MonoBehaviour
{
    #region Fields

    private int _garageDoorTries = 0;
    [SerializeField] private AudioSource _garageDoorFirstLine;
    [SerializeField] private AudioSource _garageDoorSecondLine;
    [SerializeField] private AudioSource _garageDoorThirdLine;
    [SerializeField] private AudioSource _garageDoorFourthLine;
    [SerializeField] private AudioManager _audioManager;

    #endregion

    #region Public Functions

    //Switches to next task if correct task was done
    //also gives auditory feedback
    public void CheckTaskCompleteGarageDoor()
    {
        if (!_garageDoorFirstLine.isPlaying && !_garageDoorSecondLine.isPlaying && !_garageDoorThirdLine.isPlaying && !_garageDoorFourthLine.isPlaying)
        {
            switch (_garageDoorTries)
            {
                case 0:
                    if (GameManager.Instance.CurrentTask != 1)
                    {
                        goto case 1;
                    }
                    _audioManager.PlayAudioSource(_garageDoorFirstLine);
                    _garageDoorTries++;
                    break;
                case 1:
                    _audioManager.PlayAudioSource(_garageDoorSecondLine);
                    _garageDoorTries = 2;
                    break;
                case 2:
                    _audioManager.PlayAudioSource(_garageDoorThirdLine);
                    _garageDoorTries++;
                    break;
                case 3:
                    _audioManager.PlayAudioSource(_garageDoorFourthLine);
                    _garageDoorTries++;
                    break;
                case 4:
                    GameManager.Instance.SwitchState(GameState.Garage);
                    break;

                default:
                    break;
            }
        }
    }

    #endregion
}
