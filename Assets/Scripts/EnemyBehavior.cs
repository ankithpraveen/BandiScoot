using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    void Start(){

    }

    void Update(){
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false){
            if (movingRight){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }
}
