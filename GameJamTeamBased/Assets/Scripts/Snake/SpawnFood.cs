using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //Food Prefab
    public GameObject foodPrefab;

    //Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    private bool _gameRuns;

    public bool GameRuns
    {
        get { return _gameRuns; }
        set { _gameRuns = value; }
    }


    void Spawn()
    {
        if (!_gameRuns)
        {
            CancelInvoke();
        }

        //x position between left & right border
        float x = (float)Random.Range(borderLeft.position.x + 0.1f, borderRight.position.x - 0.1f);

        //y position between top & bottom border
        float y = (float)Random.Range(borderBottom.position.y + 0.1f, borderTop.position.y - 0.1f);

        //Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //default rotation
       
    }

    // Start is called before the first frame update
    public void StartSpawn()
    {
        _gameRuns = true;
        //Spawn food every 4 seconds, starting in 3
        InvokeRepeating(nameof(Spawn), 3, 4);
    }
}
