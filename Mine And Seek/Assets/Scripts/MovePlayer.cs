using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float xSpeed = 0;
    private float ySpeed = 0;
    public float moveSpeed = 10;
    public KeyCode leftKey, rightKey, upKey, downKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grab the Rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            xSpeed = -moveSpeed;
        }
        else if (Input.GetKey(rightKey))
        {
            xSpeed = moveSpeed;
        }
        else
        {
            xSpeed = 0;
        }

        if (Input.GetKey(upKey))
        {
            ySpeed = moveSpeed;
        }
        else if (Input.GetKey(downKey))
        {
            ySpeed = -moveSpeed;
        }
        else
        {
            ySpeed = 0;
        }
        rb2d.linearVelocity = new Vector2(xSpeed, ySpeed);
    }
}


