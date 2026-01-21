using UnityEngine;

public class WinScreenText : MonoBehaviour
{
    public Transform cornerBL, cornerTR;
    public Transform playerPos;

    public AnimationCurve curve;

    float time = 0, timeIncrement = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the win message reached the desired size
        if (transform.localScale.x >= 1 && transform.localScale.y >= 1)
        {
            //If the player's x and y are greater than the BOTTOM LEFT corner
            if (playerPos.position.x > cornerBL.position.x && playerPos.position.y > cornerBL.position.y
                //If the player's x and y are smaller than the TOP RIGHT corner
                && playerPos.position.x < cornerTR.position.x && playerPos.position.y < cornerTR.position.y)
            {
                //Assigning the scale to the time based on the curve
                transform.localScale = new Vector2(curve.Evaluate(time), curve.Evaluate(time));
                time += timeIncrement;
            }
        }
    }
}
