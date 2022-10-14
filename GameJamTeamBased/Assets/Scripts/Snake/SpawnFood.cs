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

    void Spawn()
    {
        //x position between left & right border
        float x = (float)Random.Range(borderLeft.position.x, borderRight.position.x);

        //y position between top & bottom border
        float y = (float)Random.Range(borderBottom.position.y, borderTop.position.y);

        //Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //default rotation
    }

    // Start is called before the first frame update
    void Start()
    {
        //Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    } 
}
