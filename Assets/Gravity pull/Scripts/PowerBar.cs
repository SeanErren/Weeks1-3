using UnityEngine;
using UnityEngine.InputSystem;

public class PowerBar : MonoBehaviour
{
    public Transform startPos, endPos;
    public Transform playerPos;

    public float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(((Vector2)playerPos.position - Mouse.current.position.ReadValue()).magnitude);
        Debug.Log((Vector2)playerPos.position);
        Debug.Log(Mouse.current.position.ReadValue());
        time = (Camera.main.WorldToScreenPoint(Mouse.current.position.ReadValue()) - Camera.main.WorldToScreenPoint(playerPos.position)).magnitude;
        transform.position = Vector2.Lerp(startPos.position, endPos.position, time);
    }
}
