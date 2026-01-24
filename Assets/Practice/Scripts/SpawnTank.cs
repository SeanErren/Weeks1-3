using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnTank : MonoBehaviour
{
    //Get's the prefab of the tank (never get a specific game object in the scene)
    public GameObject tankPrefab;
    public GameObject collisionObject; //Could have just gotten the transform of this object because I only need its position

    //A list for all of the spawned tanks
    public List<GameObject> spawnedTanks = new List<GameObject>();
    List<FirstScript> TanksMovementScript = new List<FirstScript>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //On left click generate a tank with a random position
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Assigning a random position to the new tank
            tankPrefab.transform.position = (Vector3)Random.insideUnitCircle * 2.5f;
            //Generating a new tank using the prefab
            Instantiate(tankPrefab);
        }

        //Alternative way of Instantiating a prefab with a different position
        //On right click generate a tank with a random position and then change its speed by using its script
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //Generating a random Vector around a Unit circle for the position
            Vector2 randomPos = Random.insideUnitCircle * 2.5f;

            
            //Assigning position and rotation using Instantiate's "overlaods" (The different constructors):
            //Quaternion.identity is the way of saying 0 rotation in Quaternions (Same as (0,0,0 in EulerAngles).
            spawnedTanks.Add(Instantiate(tankPrefab, randomPos, Quaternion.identity)); //Create and add the new tank object to the list
            //Adding the tank's movement script to the list (FirstScript moves the tank left and right to the edges of the screen)
            TanksMovementScript.Add(spawnedTanks[spawnedTanks.Count - 1].GetComponent<FirstScript>());

            //Adding a random speed to each tank created
            TanksMovementScript[spawnedTanks.Count - 1].forwardSpeed += Random.Range(-2, 5); //Default is 3 so after addition: 1 to 8
            TanksMovementScript[spawnedTanks.Count - 1].backwardSpeed += Random.Range(-5, 2); //Default is -3 so after addition: -8 to -1
        }

        //Instantiate with a prefab and a transform DOES NOT change the position, it tells it to make the prefab under the parent
        //Instantiate(tankPrefab, transform)

        destroyOnCollision();
    }

    void destroyOnCollision()
    {
        //Detecting collision with an object
        if (collisionObject != null && spawnedTanks.Count > 0) //If there is an object to hit and a tank to hit it
        {
            //Go through all the tanks and check their distance from the collision object
            for (int i = 0; i < spawnedTanks.Count; i++)
            {
                //If the distance between the tank and the collision object is < x
                if (Vector2.Distance(spawnedTanks[i].transform.position, collisionObject.transform.position) < 1)
                {
                    //Destroy the tank colliding with the object
                    Destroy(spawnedTanks[i]);

                    //Removes the tank at position i from the list (removes the empty slot)
                    spawnedTanks.RemoveAt(i);
                }
            }
        }
    }
}
