using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ToDoListController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    [SerializeField] private int taskNumber;
    private int taskFinished;
    private int currentTask;

    private void Update() {
        currentTask = GameManager.Instance.currentTask;
        Debug.Log(currentTask);
        switch (currentTask)
    {
        case 1:
            myTextElement = GameManager.Instance.myKaffe;
            break;
        case 2:
            myTextElement = GameManager.Instance.myArbeit;
            break;
        case 3:
            myTextElement = GameManager.Instance.myEssen;
            break;
        case 0:
        break;
        default:
            throw new ArgumentOutOfRangeException(nameof(taskNumber), taskNumber, null);
    }
    }
    
    public void TaskDone(int taskFinished)
    {
        if (taskFinished == taskNumber)
        {
        myTextElement.fontStyle = FontStyles.Strikethrough;
        
        switch (taskNumber)
    {
        case 1:
            GameManager.Instance.myKaffe = myTextElement;
            GameManager.Instance.currentTask += 1;
            break;
        case 2:
            GameManager.Instance.myArbeit = myTextElement;
             GameManager.Instance.currentTask += 1;
            break;
        case 3:
            GameManager.Instance.myEssen = myTextElement;
            GameManager.Instance.currentTask += 1;
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(taskNumber), taskNumber, null);
    }
        }

    }
}