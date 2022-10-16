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
        float x = (float)Random.Range(borderLeft.position.x + 0.05f, borderRight.position.x - 0.05f);

        //y position between top & bottom border
        float y = (float)Random.Range(borderBottom.position.y + 0.05f, borderTop.position.y - 0.05f);

        //Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //default rotation
    }

    // Start is called before the first frame update
    public void StartSpawn()
    {
        //Spawn food every 4 seconds, starting in 3
        InvokeRepeating(nameof(Spawn), 3, 4);
    } 
}
