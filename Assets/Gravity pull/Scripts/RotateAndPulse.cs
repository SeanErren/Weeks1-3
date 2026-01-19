using UnityEngine;

public class RotateAndPulse : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    float perlinTime = 0, perlinIncrement = 0.001f;
    bool turnRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Generates 50 50 chance for 0 and 1 (because converting to int drops the numbers after the dot)
        if ((int)Random.Range(0, 2) == 0) turnRight = true;
        else turnRight = false;

        if (!turnRight)
            rotationSpeed *= -1; //Change direction if the random number is 1

        perlinTime = Random.Range(0, 10); //Starts at a random point so that every black hole rotates differently
    }

    // Update is called once per frame
    void Update()
    {
        //Apply the rotation
        transform.eulerAngles += new Vector3(0, 0, rotationSpeed);

        //Apply the scale by generating a perlin noise from the perlin time float
        float randomScale = Mathf.PerlinNoise(perlinTime, perlinTime) + 0.5f;
        transform.localScale = new Vector2(randomScale, randomScale);

        //Up the perlin noise
        perlinTime += perlinIncrement;
    }
}
