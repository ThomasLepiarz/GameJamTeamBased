using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleObjectVisibility : MonoBehaviour
{
    [SerializeField] private int objectOrder;
    [SerializeField] private GameObject GameObject;
    private int currentTask;

    void Update()
    {
        currentTask = GameManager.Instance.currentTask;
        if (objectOrder != currentTask){
            GameObject.SetActive(false);
        }
        else
        {
            GameObject.SetActive(true);
        }
        
        
    }
}
