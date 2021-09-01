using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{

    Rigidbody2D ballRigidBody;
    AudioSource bounceSound;
    public Text countDownDisplay;
    bool setCD;
    // Start is called before the first frame update
    public void Start()
    {
        // countDownDisplay = GameObject.FindGameObjectWithTag("CountdownText").GetComponent<Text>();
        setCD = true;
        bounceSound = GetComponent<AudioSource>();
        ballRigidBody = GetComponent<Rigidbody2D>();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Game")
        {
            StartCoroutine(WaitBeforeGo(3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float velX = ballRigidBody.velocity.x;
        float velY = ballRigidBody.velocity.y;
        if ((Mathf.Abs(velX) < 13 || Mathf.Abs(velX) > 16) && velX != 0)
        {
            if (velX > 0)
            {
                ballRigidBody.velocity = new Vector2(16, ballRigidBody.velocity.y);
            }
            if (velX < 0)
            {
                ballRigidBody.velocity = new Vector2(-16, ballRigidBody.velocity.y);
            }
        }
        // print(ballRigidBody.velocity.y);
        // if (velX == 0 && velY != 0)
        // {
        //     ballRigidBody.velocity = new Vector2(20, 4);
        // }

        // if (velY == 0 && velX == 0 && Time.timeSinceLevelLoad > 4)
        // {
        //     ballRigidBody.velocity = new Vector2(20, 4);
        // }

    }

    void ResetBall()
    {
        ballRigidBody.velocity = new Vector2(0, 0);
        ballRigidBody.position = new Vector2(0, 0);

        StartCoroutine(WaitBeforeGo(1));
    }

    public IEnumerator WaitBeforeGo(int delay)
    {
        if (setCD)
        {
            while (delay > 0)
            {
                countDownDisplay.text = delay.ToString();
                yield return new WaitForSeconds(1);
                delay--;
            }
            setCD = false;
        }

        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1);
        if (countDownDisplay.gameObject.activeSelf)
        {
            countDownDisplay.gameObject.SetActive(false);
        }
        GoBall();
    }
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Player")
        {
            float newVelY = ballRigidBody.velocity.y / 2 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y / 3;
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, newVelY);
            bounceSound.pitch = Random.Range(0.8f, 1.2f);
            bounceSound.Play();

        }
    }

    public void GoBall()
    {
        float randomNumber = Random.Range(0, 4);
        int force = 80;
        // if (ballRigidBody.gameObject.tag == "Ball")
        // {
        //     force = 5;
        // }
        if (randomNumber == 0)
        {
            ballRigidBody.AddForce(new Vector2(force, force / 5));
        }
        else if (randomNumber == 1)
        {
            ballRigidBody.AddForce(new Vector2(-force, -force / 5));
        }
        else if (randomNumber == 2)
        {
            ballRigidBody.AddForce(new Vector2(-force, force / 5));
        }
        else
        {
            ballRigidBody.AddForce(new Vector2(force, -force / 5));
        }
    }


}
