using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public float forwardSpeed = 0.01f;
    public float backwardSpeed = -0.01f;

    public bool isForward = true;

    public PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = (Vector2)transform.position + Random.insideUnitCircle * 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame.isPaused)
            return;

        //Create a temporary Vector2 for the transform's position
        Vector2 newPos = transform.position, screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Change direction if the edge of the screen is reached
        if (screenPos.x < 0)
            isForward = true;
        if (screenPos.x > Screen.width)
            isForward = false;

        //Move according to the direction
        if (isForward)
            newPos.x += forwardSpeed;
        else
            newPos.x += backwardSpeed;

        //Set the new transform position to the temporary Vector2
        transform.position = newPos;
    }
}
