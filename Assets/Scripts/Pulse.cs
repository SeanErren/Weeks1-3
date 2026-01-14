using UnityEngine;

public class Pulse : MonoBehaviour
{
    public AnimationCurve curve;
    public float time = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
            time = 0;

        transform.localScale = Vector3.one * curve.Evaluate(time);
    }
}
