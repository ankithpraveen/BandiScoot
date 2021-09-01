using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPoints : MonoBehaviour
{
    public float pointsToGiveOnCoinPickup;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
        {
            scoreManager.AddOtherScore(pointsToGiveOnCoinPickup);
            FindObjectOfType<AudioManager>().PlaySound("Coin");
            Destroy(gameObject);
        }
    }
}
