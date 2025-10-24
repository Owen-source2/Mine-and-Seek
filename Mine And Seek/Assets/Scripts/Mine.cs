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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MovePlayer>())
        {
            Destroy(collision.gameObject);
        }
        Debug.Log("Destroyed Target");
        Destroy(gameObject);
        Debug.Log("Destroyed Self");
    }
}
