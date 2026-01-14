using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    public Transform startPos, endPos;
    public float time = 0;

    bool isForward = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isForward)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (time > 1)
            isForward = false;
        if (time < 0)
            isForward = true;

        transform.position = Vector2.Lerp(startPos.position, endPos.position, time);
    }
}
