using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 10;
    Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp)){
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,speed);
        }
        else if (Input.GetKey(moveDown)){
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,-speed);
        }
        else{
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,0);
        }
    }
}
