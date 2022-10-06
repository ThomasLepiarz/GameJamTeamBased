using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

using Enums;


public class TaskManager : MonoBehaviour
{

    #region Fields

    [SerializeField] private TextMeshProUGUI toDoTask;
    [SerializeField] private int clickedTask;
    [SerializeField] private AudioSource wrongTask;
    [SerializeField] private AudioSource correctTask;

    #endregion

    #region Private Functions

    private void Update()
    {
        if (GameManager.Instance.DayCount != 2)
        {
            switch (GameManager.Instance.CurrentTask)
            {
                case 1:
                    toDoTask.text = "Kaffee";
                    break;
                case 2:
                    toDoTask.text = "Arbeit";
                    break;
                case 3:
                    toDoTask.text = "Waschen";
                    break;
                case 4:
                    toDoTask.text = "Schlafen";
                    break;
                case 5:
                    GameManager.Instance.HandleNextDay();
                    break;
                case 0:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(GameManager.Instance.CurrentTask), GameManager.Instance.CurrentTask, null);
            }
        }
    }

    //Switches to next task if correct task was done
    private void OnMouseDown()
    {
        //correct task?
        if (clickedTask == GameManager.Instance.CurrentTask)
        {
            Debug.Log("Clicked on Object");
            GameManager.Instance.CurrentTask += 1;
            //success sound
            correctTask.Play();
        }
        //wrong task?
        else if (clickedTask != GameManager.Instance.CurrentTask)
        {
            Debug.Log("Clicked on wrong task!");
            //error sound
            wrongTask.Play();
        }
        //dafuq is this?
        else if (clickedTask == 7)
        {
            SceneManager.LoadScene(Scenes.GoodEnding.ToString());
        }
    }

    #endregion
}