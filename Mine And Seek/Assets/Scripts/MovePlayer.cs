using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //PPuts dropdown in inspector to select player role
    public enum Role
    {
        Gunner,
        Trapper
    }
    public Role playerRole;
    private Rigidbody2D rb2d;
    private float xSpeed = 0;
    private float ySpeed = 0;
    public float moveSpeed = 10;
    public KeyCode leftKey, rightKey, upKey, downKey, fire;
    Vector2 facingDir = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grab the Rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
        //Select fire button based on role
        switch (playerRole)
        {
            case Role.Gunner:
                fire = KeyCode.LeftShift;
                break;
            case Role.Trapper:
                fire = KeyCode.Keypad0;
                break;
        }
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
        //Determines facing direction based on the direction the player is moving. If they're not moving, it uses the previous direction
        if (rb2d.linearVelocity != Vector2.zero)
        {
            facingDir = rb2d.linearVelocity;
        }
        if (Input.GetKey(fire))
        {
            switch (playerRole)
            {
                case Role.Gunner:
                    Shoot();
                    break;
                case Role.Trapper:
                    SetTrap();
                    break;
            }
        }

    }
    void Shoot()
    {
        //Creates a line starting at the player's position, in the direction they're facing. If it hits the other player, it destroys them.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDir);
        Debug.DrawRay(transform.position, facingDir);
        if (hit.transform.gameObject.tag == "Trapper"/*GetComponent<MovePlayer>().playerRole==Role.Trapper*/)
        {
            Debug.Log("Hit");
            hit.transform.gameObject.GetComponent<MovePlayer>().SelfDestruct();
        }

    }
    void SetTrap()
    {
        Debug.Log("Setting Trap");
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}


