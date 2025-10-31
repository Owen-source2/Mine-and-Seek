using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Triggered whenever the mine impacts an object
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the object hitting the mine is a player, kill that player
        if(collision.gameObject.GetComponent<MovePlayer>())
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Destroyed Target");
        //Destroy mine after killing player
        Destroy(gameObject);
        Debug.Log("Destroyed Self");
    }
    
}
