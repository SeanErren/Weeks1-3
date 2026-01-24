using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float forwardSpeed = 3;
    public float backwardSpeed = -3;
    public float randomStartRangeMult = 2.5f;

    public bool isForward = true;

    public PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Randomize the starting position within a unit circle range
        transform.position = (Vector2)transform.position + Random.insideUnitCircle * randomStartRangeMult;
    }

    // Update is called once per frame
    void Update()
    {
        //Can't use pauseGame when generating an object from code as I don't know how to assign it a script from code yet
        //if (pauseGame.isPaused)
           // return;

        //Create a temporary Vector2 for the transform's position
        Vector2 newPos = transform.position, screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Change direction if the edge of the screen is reached
        if (screenPos.x < 0)
            isForward = true;
        if (screenPos.x > Screen.width)
            isForward = false;

        //Move according to the direction
        if (isForward)
            newPos.x += forwardSpeed * Time.deltaTime;
        else
            newPos.x += backwardSpeed * Time.deltaTime;

        //Set the new transform position to the temporary Vector2
        transform.position = newPos;
    }
}
