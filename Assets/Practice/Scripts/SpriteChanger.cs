using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color c;
    public Sprite spriteMoon,spriteSun;

    public Sprite[] barrels = new Sprite[3];

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
}
