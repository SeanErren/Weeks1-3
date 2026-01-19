using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPull : MonoBehaviour
{
    public Transform bH1, bH2, bH3; //The black holes' positions.
    public float maxSpeed = 5; //The max speed the player is allowed to move towards their target.
    public float roomBoundrySize = 1;

    float speedMult = 0; //multiplies the normilized vector to create the speed at which the player is moving towards the target.
    Transform[] blackHoles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Testing the values returned from the conversion, only half of the size of the screen? Because below is -?
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));

        //Putting the black holes' positions into an arraylist so that I can go through them more easily.
        blackHoles  = new Transform[3] {bH1, bH2, bH3};
    }

    // Update is called once per frame
    void Update()
    {
        //Getting pulled towards the black holes.
        foreach (Transform blackHole in blackHoles)
        {
            //Only assigne a speed multiplier if the player is close enough.
            if ((blackHole.position - transform.position).magnitude < maxSpeed)
            {
                //Extracting the size of the hypotenuse (the vector, through the pythagorean theorem) to measure
                //the speed at which the player should be moving towards the black hole.
                //Inverting the speed so that the max speed allowed loses speed the bigger the magnitued (instead of more speed further away).
                speedMult = maxSpeed - (blackHole.position - transform.position).magnitude;
            }
            else
            {
                //Else there is no speed and therefore no movement.
                speedMult = 0;
            }

            //Adding the normalized vector (size 1 hypotenuse) times the speed to the position.
            transform.position += (blackHole.position - transform.position).normalized * speedMult * Time.deltaTime;
        }

        //Getting pulled towards the mouse.
        //Getting the mouse pos in pixels.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //If the distance between the mouse and the player is smaller than the max speed (max radius) allowed.
        if ((mousePos - (Vector2)transform.position).magnitude < maxSpeed)
        {
            //The speed is equal to the distance between the distance between the player and the mouse.
            speedMult = (mousePos - (Vector2)transform.position).magnitude;
            //Adding the normalized vector between the mouse and the player times the speedMult times the time (for consistency) to the position.
            transform.position += ((Vector3)mousePos - transform.position).normalized * speedMult * Time.deltaTime;
        }

        //Limiting the player to be within the bounderies of the room.
        //Getting the screen size in world units
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Removing half of the screen size (for some reason screenSize is half of the screen) to get to the -x and -y where the room starts.
        if (transform.position.x < roomBoundrySize - screenSize.x)
        {
            //If the position passes the lower x boundry, reset the x to that boundry (the start of the screen).
            transform.position = new Vector3(roomBoundrySize - screenSize.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > screenSize.x - roomBoundrySize)
        {
            //If the position passes the upper x boundry, reset the x to that boundry (the end of the screen).
            transform.position = new Vector3(screenSize.x - roomBoundrySize, transform.position.y, transform.position.z);
        }
        if (transform.position.y < roomBoundrySize - screenSize.y)
        {
            //If the position passes the lower y boundry, reset the y to that boundry (the start of the screen).
            transform.position = new Vector3(transform.position.x, roomBoundrySize - screenSize.y, transform.position.z);
        }
        else if (transform.position.y > screenSize.y - roomBoundrySize)
        {
            //If the position passes the upper y boundry, reset the y to that boundry (the end of the screen).
            transform.position = new Vector3(transform.position.x, screenSize.y - roomBoundrySize , transform.position.z);
        }
    }
}
