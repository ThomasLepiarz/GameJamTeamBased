using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightSprites : MonoBehaviour
{

    private SpriteRenderer spriteR;
    private Sprite originalSprite;
    public Sprite highlightedSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the sprites
        spriteR = GetComponent<SpriteRenderer>();
        originalSprite = spriteR.sprite;
    }

    //ändert bool value nach Mauspositionsabfrage (erster Frame wo Maus Collider berührt)

    private void highlightSprite()
    {
        spriteR.sprite = highlightedSprite;
    }

    private void resetSprite()
    {
        spriteR.sprite = originalSprite;
    }

    void OnMouseOver()
    {
        highlightSprite();
    }

    void OnMouseExit()
    {
        resetSprite();
    }

}
