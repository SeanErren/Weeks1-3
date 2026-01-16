using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    float speed = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.right refers to to a Vector3 with the values (1,0,0) (same with .up and .forward for the different axis).
        //* -1 to go left (-1,-0,-0).
        //* speed to move at the desired speed (-2.5, -0, -0).
        //* Time.deltaTime for movement per time instead of per frame.
        transform.position += transform.right * -1 * speed * Time.deltaTime;
    }
}
