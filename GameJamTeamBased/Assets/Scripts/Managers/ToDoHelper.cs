using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Enums;
using Everyday;
using UnityEngine.UI;

public class ToDoHelper : MonoBehaviour
{
    //this script is to be used in the "scene" canvases

    #region Fields
    [SerializeField] private TextMeshProUGUI _toDoText;
    private Task _currentTask;

    #endregion

    // Update is called once per frame
    void Update()
    {
        //Gets the currentTask as enum
        _currentTask = (Task)GameManager.Instance.CurrentTask;

        if (_toDoText != null)
        {
            //writes enum as string on the bubble
            _toDoText.text = _currentTask.ToString();
        }
    }
}
