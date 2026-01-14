using UnityEngine;

public class MovingBallXandY : MonoBehaviour
{
    public float speedX = 0.1f, speedY = 0.1f;

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

        posOnScreen.x += speedX;
        posOnScreen.y += speedY;

        //Flip direction if X
        if (posOnScreen.x < 0 || posOnScreen.x > Screen.width)
            speedX *= -1;
        if (posOnScreen.y < 0 || posOnScreen.y > Screen.height)
            speedY *= -1;

        //Returning the position back to meter units
        posOnScreen = Camera.main.ScreenToWorldPoint(posOnScreen);

        transform.position = posOnScreen;
    }
}
