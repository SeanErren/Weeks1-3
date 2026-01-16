using UnityEngine;
using UnityEngine.InputSystem;

public class pointToMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the mouse's position using the Mouse library, transforming its position from pixels to meters and assigning it to a Vector2.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //Remove transform.position from the mouse's position to get the distance (vector) between them and assign it to a new Vector2.
        Vector2 direction = mousePos - (Vector2)transform.position;

        //Change the pointer itself of the y axis based on the direction of the vector we got from
        //the distance between the triangle and the mouse's position (so that it points towards the mouse).
        transform.up = direction;
    }
}
