
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color c;
    public Sprite spriteMoon,spriteSun;

    public Sprite[] barrels = new Sprite[3];
    public List<Sprite> spriteList;

    bool hasSpriteChanged = false;
    int randomBarrel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Switch between sun and moon
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (hasSpriteChanged)
                spriteRenderer.sprite = spriteMoon;
            else
                spriteRenderer.sprite = spriteSun;

            hasSpriteChanged = !hasSpriteChanged;

            //changeColor();
        }

        //Change barrel
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            changeToRandomBarrel();
        }

        //Change from spriteList
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            //If there is a sprite within the list
            if (spriteList.Count > 0)
                changeToNextSprite();
            else
                Debug.Log("The list is empty, can't change sprite");
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //Change color on mouse hover
        //spriteRenderer.sprite.bounds refers to the bounds of the sprite but at 0,0
        if (spriteRenderer.bounds.Contains(mousePos))
        {
            spriteRenderer.color = c;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && spriteList.Count > 0)
        {
            spriteList.RemoveAt(0);
        }
    }

    void changeColor()
    {
        //Picking a random color to change the sprite to
       spriteRenderer.color = Random.ColorHSV();
    }

    //Picks a random barrel from the array
    void changeToRandomBarrel()
    {
        //Generate a random number (corrosponding with the amount of barrels)
        randomBarrel = Random.Range(0, barrels.Length);

        spriteRenderer.sprite = barrels[randomBarrel];
    }

    //Changes to the next sprite in the list
    void changeToNextSprite()
    {
        int randomSprite = Random.Range(0, spriteList.Count);
        spriteRenderer.sprite = spriteList[randomSprite];
    }
}
