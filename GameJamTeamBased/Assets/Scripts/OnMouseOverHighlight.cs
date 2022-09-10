using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverHighlight : MonoBehaviour
{

    private SpriteRenderer spriteR;
    private Sprite originalSprite;
    private bool isHighlighted;
    public Sprite highlightedSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the sprites
        spriteR = GetComponent<SpriteRenderer>();
        originalSprite = spriteR.sprite;

        //ensure correct starting point for bool (prolly unnecessary)
        isHighlighted = false;
    }

    void OnMouseOver()
    {
        isHighlighted = true;
    }

    void OnMouseExit()
    {
        isHighlighted = false;
    }
    
    private void highlightSprite()
    {
        spriteR.sprite = highlightedSprite;
    }

    private void resetSprite()
    {
        spriteR.sprite = originalSprite;
    }

    /*war wohl irgendwie notwendig, es direkt in 
     * den Funktionen oben zu machen hat die Sprite nicht neu gerendert 
     * -> es wurde einfach schwarz */
    void Update()
    {
        
        //Leertaste markiert alle Ojekte
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHighlighted = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHighlighted = false;
        }


        //Wechselt Sprites entsprechend bool value
        if (isHighlighted)
        {
            highlightSprite();
        } else
        {
            resetSprite();
        }
    }
}
