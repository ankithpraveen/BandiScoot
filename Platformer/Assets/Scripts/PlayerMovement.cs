using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public float speedMultiplier;
    private float checkPointDistance;
    public float checkPointDistanceIncrease;
    private float defaultCheckPointDistanceIncrease;
    private float defaultRunSpeed;
    private float defaultCheckPointDistance;

    public GameObject killBox;

    float horizontalMove = 0f;
    bool jump;
    bool crouch;

    public GameManager gameManager;
    private ScoreManager scoreManager;

    public float direction = 1f;

    public bool hitSpikes = true;


    // Start is called before the first frame update
    void Start()
    {

        scoreManager = FindObjectOfType<ScoreManager>();

        checkPointDistance = checkPointDistanceIncrease;
        defaultCheckPointDistanceIncrease = checkPointDistanceIncrease;
        defaultRunSpeed = runSpeed;
        defaultCheckPointDistance = checkPointDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > checkPointDistance){
            checkPointDistance += checkPointDistanceIncrease;
            checkPointDistanceIncrease = checkPointDistanceIncrease * speedMultiplier;
            runSpeed = runSpeed * speedMultiplier;
        }

        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetAxisRaw("Horizontal") != 0){
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            direction = Input.GetAxisRaw("Horizontal");
            if (Input.GetAxisRaw("Horizontal") == -1){
                scoreManager.scoreIncreasing = false;
            }
            else{
                scoreManager.scoreIncreasing = true;
            }
        }
        else{
            horizontalMove = direction * runSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

        MoveKillBox();
    }

    public void OnLanding(){
        animator.SetBool("IsJumping",false);
    }

    public void OnCrouching(bool isCrouching){
        animator.SetBool("IsCrouching",isCrouching);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }



    private void OnCollisionEnter2D(Collision2D other) {
        bool collisionCondition = true;
        if (hitSpikes){
            collisionCondition = other.gameObject.tag == "KillBox" || other.gameObject.tag == "Spikes";
        }
        else{
            collisionCondition = other.gameObject.tag == "KillBox";
        };
        if (collisionCondition){
            checkPointDistance = defaultCheckPointDistance;
            checkPointDistanceIncrease = defaultCheckPointDistanceIncrease;
            runSpeed = defaultRunSpeed;
            gameManager.RestartGame();
            
        }
    }

    void MoveKillBox(){
        killBox.transform.position = new Vector3(transform.position.x, killBox.transform.position.y, killBox.transform.position.z);
    }


}
