using System.Collections;
using UnityEngine;

public class CharacterCont : MonoBehaviour
{
    private float speed = 120.0f;
    public float Speed { get { return speed; } set { speed = value; } }
    private float aheadSpeed = 100f;
    public float AheadSpeed { get { return aheadSpeed; } set { aheadSpeed = value; } }
    private float upBoundary = 100f;
    private float downBoundary = 0f;
    private float horizontal = 0;
    public  bool left;
    public  bool right;
    private void Start()
    {
        left = true;
        right = true;
    }
    private void Update()
    {
        if (gameObject != null)
        {
            MoveBird();
        }
    }

    private void MoveBird()
    {
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftArrow) && left)
        {
            horizontal = -1f;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && right)
        {
            horizontal  = 1f;
        }
        else 
        { 
            horizontal = 0f;
        }
        Vector3 newPosition = gameObject.transform.position + new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, AheadSpeed * Time.deltaTime);
        if (newPosition.y > upBoundary)
        {
            newPosition.y = upBoundary;
        }
        else if (newPosition.y < downBoundary)
        {
            newPosition.y = downBoundary;
        }
        gameObject.transform.position = newPosition;
    }
}