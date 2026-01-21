using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //degrees per second
    public float speed = 45f;

    public PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame.isPaused)
            return;

        //transform.rotation = Quaternion Angles which is complicated math using 4 dimension (4th one being time) to rotate better but is complicated.
        //transform.eulerAngles = Euler Angles simply looks for the x, y and z and converts it to Quaternion Angles behind the scenes.

        //Creating a Vector3 because transform.eulerAngles does not accept changes to z, only a Pvector.
        Vector3 rotation = new Vector3(0, 0, speed);
        //Adding the roation to the position;
        transform.eulerAngles += rotation * Time.deltaTime;
    }
}
