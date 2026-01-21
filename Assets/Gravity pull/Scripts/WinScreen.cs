using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public Transform cornerBL, cornerTR;
    public Transform playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player's x and y are greater than the BOTTOM LEFT corner
        if (playerPos.position.x > cornerBL.position.x && playerPos.position.y > cornerBL.position.y
            //If the player's x and y are smaller than the TOP RIGHT corner
            && playerPos.position.x < cornerTR.position.x && playerPos.position.y < cornerTR.position.y)
            transform.localScale = new Vector2(1,1);
    }
}
