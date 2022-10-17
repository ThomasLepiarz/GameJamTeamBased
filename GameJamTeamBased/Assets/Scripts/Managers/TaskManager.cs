using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

using Enums;
using Everyday;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TaskManager : MonoBehaviour
{
    //This script is part of the GameManager
    //Manages Taskprogression, triggers-Task related voice lines and other Task functions

    #region Fields

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Button TaskObject_One;
    [SerializeField] private Button TaskObject_Two;
    [SerializeField] private Button TaskObject_Three;
    [SerializeField] private Button TaskObject_Four;
    [SerializeField] private AudioSource _workTaskFinished;
    [SerializeField] private AudioSource _coffeeTaskFinished;
    [SerializeField] private AudioSource _washTaskFinished;
    [SerializeField] private AudioSource _workTaskFinishedPlayer;
    [SerializeField] private AudioSource _coffeeSip;



    private int _clickedTask;

    #endregion

    #region Private Functions

    //Makes unique onclick events for the interactable objects
    //needs to be used to relate the task to the respective object
    private void Start()
    {
        if (TaskObject_One != null)
        {
            Button button1 = TaskObject_One.GetComponent<Button>();
            button1.onClick.AddListener(TaskOnClickOne);
        }
        
        if (TaskObject_Two != null)
        {
            Button button2 = TaskObject_Two.GetComponent<Button>();
            button2.onClick.AddListener(TaskOnClickTwo);
        }
        
        if (TaskObject_Three != null)
        {
            Button button3 = TaskObject_Three.GetComponent<Button>();
            button3.onClick.AddListener(TaskOnClickThree);
        }

        if (TaskObject_Four != null)
        {
            Button button4 = TaskObject_Four.GetComponent<Button>();
            button4.onClick.AddListener(TaskOnClickFour);
        }

    }

    //sets the respective TaskNumber
    private void TaskOnClickOne()
    {
        _clickedTask = 1;
        CheckTaskComplete();
    }

    private void TaskOnClickTwo()
    {
        _clickedTask = 2;
        CheckTaskComplete();
    }

    private void TaskOnClickThree()
    {
        _clickedTask = 3;
        CheckTaskComplete();
    }

    private void TaskOnClickFour()
    {
        _clickedTask = 4;

        if (GameManager.Instance.CurrentDay > 2)
        {
            GameManager.Instance.SwitchState(GameState.BadEnding);
        }
        else if (_clickedTask == GameManager.Instance.CurrentTask)
        {
            GameManager.Instance.SwitchState(GameState.NextDay);
        }
        else
        {
            CheckTaskComplete();
        }
    }
    #endregion

    //Switches to next task if correct task was done
    //also gives auditory feedback
    private void CheckTaskComplete()
    {
        Debug.Log("CheckTaskComplete Called: ");

        //correct task?
        if (_clickedTask == GameManager.Instance.CurrentTask)
        {
            audioManager.PlayCorrectTaskSound();
            switch (GameManager.Instance.CurrentTask)   
            {
                case 1: //Coffee
                    audioManager.PlayAudioSource(_coffeeSip);
                    audioManager.PlayAudioSource(_coffeeTaskFinished);
                    break;

                case 2: //work
                    audioManager.PlayAudioSource(_workTaskFinished);
                    audioManager.PlayAudioSource(_workTaskFinishedPlayer);
                    break;

                case 3: //sink
                    audioManager.PlayAudioSource(_washTaskFinished);
                    break;

                case 4: //bed
                    break;

                default:
                    break;
            }

            Debug.Log("Clicked on Object");
            Debug.Log("Assigned Tasknumber of Object: " + _clickedTask);
            Debug.Log("Before Update: " + GameManager.Instance.CurrentTask);
            GameManager.Instance.CurrentTask += 1;

            Debug.Log("After Update: " + GameManager.Instance.CurrentTask);            
        }
        //wrong task?
        else if (_clickedTask != GameManager.Instance.CurrentTask)
        {
            Debug.Log("Clicked on wrong task!");
            //error sound
            audioManager.PlayWrongTaskSound();
        }
    }
}