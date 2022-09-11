using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ToDoListController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    private int taskFinished;
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
            myTextElement.text = "Essen";
            break;
        case 0:
        break;
        default:
            throw new ArgumentOutOfRangeException(nameof(currentTask), currentTask, null);
    }
    }
    
    public void TaskDone(int taskFinished)
    {
        if (taskFinished == currentTask)
        {       
        switch (currentTask)
    {
        case 1:
            GameManager.Instance.currentTask += 1;
            break;
        case 2:
             GameManager.Instance.currentTask += 1;
            break;
        case 3:
            GameManager.Instance.currentTask += 1;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(currentTask), currentTask, null);
    }
        }

    }
}