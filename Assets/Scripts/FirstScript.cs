using UnityEngine;

public class FirstScript : MonoBehaviour
{
    float speed = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position, screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0)
            speed = 0.01f;
        if (screenPos.x > Screen.width)
            speed = -0.1f;
        newPos.x += speed;
        transform.position = newPos;
    }
}
