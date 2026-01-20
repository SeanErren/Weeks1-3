using UnityEngine;
using UnityEngine.InputSystem;

public class PowerBar : MonoBehaviour
{
    public Transform startPos, endPos; //The start and end points of the Lerp
    public Transform playerPos;

    public float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(((Vector2)playerPos.position - Mouse.current.position.ReadValue()).magnitude);
        //Debug.Log(Camera.main.WorldToScreenPoint((Vector2)playerPos.position));
        //Debug.Log(Mouse.current.position.ReadValue());

        //Time is euqal to the distance between the mouse's position and the player's position (in world space measurements)
        time = ((Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - (Vector2)playerPos.position).magnitude;
        //If time is out of the range of influence
        if (time > 5)
            time = 0;
        //dividing time by 5 so that it's always between 0 and 1
        transform.position = Vector2.Lerp(startPos.position, endPos.position, time / 5);    
    }
}
