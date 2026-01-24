using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTank : MonoBehaviour
{
    //Get's the prefab of the tank (never get a specific game object in the scene)
    public GameObject tankPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the mouse was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Assigning a random position to the new tank
            tankPrefab.transform.position = (Vector3)Random.insideUnitCircle * 2.5f;
            //Generating a new tank using the prefab
            Instantiate(tankPrefab);


        }

        //Alternative way of Instantiating a prefab with a different position
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //Generating a random Vector around a Unit circle for the position
            Vector2 randomPos = Random.insideUnitCircle * 2.5f;
            //Assigning position and rotation using Instantiate's "overlaods" (The different constructors):
            //Quaternion.identity is the way of saying 0 rotation in Quaternions (Same as (0,0,0 in EulerAngles).
            Instantiate(tankPrefab, randomPos, Quaternion.identity);
        }

        //Instantiate with a prefab and a transform DOES NOT change the position, it tells it to make the prefab under the parent
        //Instantiate(tankPrefab, transform)
    }
}
