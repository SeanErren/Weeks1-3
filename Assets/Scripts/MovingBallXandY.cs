using UnityEngine;

public class MovingBallXandY : MonoBehaviour
{
    //The movement happens in pixels
    public int speedX = 50, speedY = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Can only change transform.position with a full Vector (can't change the x, y and z directly)
        //Getting the screen's position in pixels
        Vector2 posOnScreen = Camera.main.WorldToScreenPoint(transform.position);

        //Up the position by the speed * the time that passed (so that it's consistent with the time)
        posOnScreen.x += speedX * Time.deltaTime;
        posOnScreen.y += speedY * Time.deltaTime;

        //Flip direction if X
        if (posOnScreen.x < 0 || posOnScreen.x > Screen.width)
        {
            //Checking if x has reached the edges, if so, set the value to that edge (to not go beyond it)
            if (posOnScreen.x < 0)
                posOnScreen.x = 0;
            if (posOnScreen.x > Screen.width)
                posOnScreen.x = Screen.width;

            speedX *= -1;
        }
        if (posOnScreen.y < 0 || posOnScreen.y > Screen.height)
        {
            //Checking if y has reached the edges, if so, set the value to that edge (to not go beyond it)
            if (posOnScreen.y < 0)
                posOnScreen.y = 0;
            if (posOnScreen.y > Screen.height)
                posOnScreen.y = Screen.height;

            speedY *= -1;
        }

        //Returning the position back to meter units
        posOnScreen = Camera.main.ScreenToWorldPoint(posOnScreen);

        transform.position = posOnScreen;
    }
}
