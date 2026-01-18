using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public float movementSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //How to input to the log:
        //Debug.Log("Up is pressed");
    }

    // Update is called once per frame
    void Update()
    {
        //UP
        //If the up arrow was pressed, rotate the car to the up position (0 degrees, default position)
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        //If the up arrow is held, move the car up
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }

        //DOWN
        //If the down arrow was pressed, rotate the car to the down position (180 degrees)
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0,0,180);
        }
        //If the down arrow is held, move the car down
        if (Keyboard.current.downArrowKey.isPressed)
        {
            //Up is relative to the axis and the axis themselves rotate when the modal is rotated so up is always forward
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }

        //LEFT
        //If the left arrow was pressed, rotate the car to the left position (90 degrees)
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0,0,90);
        }
        //If the left arrow is held, move the car left
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            //Up is relative to the axis and the axis themselves rotate when the modal is rotated so up is always forward
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }

        //RIGHT
        //If the right arrow was pressed, rotate the car to the right position (-90 degrees)
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0,0,-90);
        }
        //If the right arrow is held, move the car right
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            //Up is relative to the axis and the axis themselves rotate when the modal is rotated so up is always forward
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
    }
}
