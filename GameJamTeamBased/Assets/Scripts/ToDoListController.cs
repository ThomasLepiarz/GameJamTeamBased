using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ToDoListController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    public int taskFinished;
    private int currentTask;

    private void Update() {

        currentTask = GameManager.Instance.currentTask;
        Debug.Log(currentTask);
        switch (currentTask)
    {
        case 1:
            myTextElement.text = "Kaffee";
            break;
        case 2:
            myTextElement.text = "Arbeit";
            break;
        case 3:
            myTextElement.text = "Waschen";
            break;
        case 4:
            myTextElement.text = "Schlafen";
            break;
        case 5:
            GameManager.Instance.ChangeState(GameManager.GameState.NextDay);
            break;
        case 0:
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(currentTask), currentTask, null);
    }
    }
     void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
             if (taskFinished == currentTask){
            Debug.Log("Clicked on Object");
            TaskDone(taskFinished);
        }
    }
    }
    
    public void TaskDone(int taskFinished)
    {
        if (taskFinished == currentTask)
        {       
            GameManager.Instance.currentTask += 1;
         }
        }

    }