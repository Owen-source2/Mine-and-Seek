using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
    Vector2 facingDir = Vector2.right;
    bool onCooldown = false;
    public GameObject mine;
    public GameObject bullet;
    public float plantOffset = 1.5f;
    [SerializeField] float bulletSpeed = 150f; 
    [SerializeField] float plantTime;
    [SerializeField] float reloadTime;
    GameObject gameManager;
    UI_Manager uiManager;
    bool canMove = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        uiManager = GameObject.Find("UIManager").GetComponent<UI_Manager>();
        //Grab the Rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
        //Select fire button based on role
        switch (playerRole)
        {
            case Role.Gunner:
                fire = KeyCode.LeftShift;
                break;
            case Role.Trapper:
                fire = KeyCode.RightShift;
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
        if(canMove)
        {
            rb2d.linearVelocity = new Vector2(xSpeed, ySpeed);
        }
        //Determines facing direction based on the direction the player is moving. If they're not moving, it uses the previous direction
        if (rb2d.linearVelocity != Vector2.zero)
        {
            facingDir = rb2d.linearVelocity.normalized;
        }
        if (Input.GetKey(fire))
        {
            switch (playerRole)
            {
                case Role.Gunner:
                    if (!onCooldown)
                    {
                        StartCoroutine(Shoot());
                    }
                    break;
                case Role.Trapper:
                    if (!onCooldown)
                    {
                        StartCoroutine(SetTrap());
                    }
                    break;
            }
        }

    }
    IEnumerator Shoot()
    {
        onCooldown = true;
        //Creates a bullet a little in front of player, then speeds it up by bulletSpeed;
        Vector2 plantSpot = new Vector2(transform.position.x, transform.position.y) + (facingDir * plantOffset);
        GameObject bulletNew = Instantiate(bullet, plantSpot, transform.rotation);
        bulletNew.GetComponent<Rigidbody2D>().AddForce(facingDir * bulletSpeed);
        //Prevents another shot until cooldown passes
        yield return new WaitForSeconds(reloadTime);
        onCooldown = false;
    }
    IEnumerator SetTrap()
    {
        onCooldown = true;
        uiManager.currentPlantCooldown = plantTime;
        uiManager.StartCooldowm();
        Debug.Log("Planting Trap");
        Vector2 plantSpot = new Vector2(transform.position.x, transform.position.y) + (facingDir * plantOffset);
        canMove=false;
        yield return new WaitForSeconds(plantTime);
        Instantiate(mine, plantSpot, transform.rotation);
        canMove=true;
        onCooldown = false;
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}


