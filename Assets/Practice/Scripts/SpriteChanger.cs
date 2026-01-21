using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color c;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
            changeColor();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

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
}
