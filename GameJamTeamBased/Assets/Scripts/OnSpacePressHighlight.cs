using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpacePressHighlight : OnMouseOverHighlight
{
    /*
    private SpriteRenderer spriteR;
    private Sprite originalSprite;
    private bool isHighlighted;
    public Sprite highlighted;
    */

    // Start is called before the first frame update
    
    /*
    void Start()
    {
        //Fetch the sprites
        spriteR = GetComponent<SpriteRenderer>();
        originalSprite = spriteR.sprite;
        
        //ensure correct starting point for bool (prolly unnecessary)
        isHighlighted = false;
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHighlighted = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHighlighted = false;
        }

        if (isHighlighted)
        {
            highlightSprite();
        }
        else
        {
            resetSprite();
        }

    }
}