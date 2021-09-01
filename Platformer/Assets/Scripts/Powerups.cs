using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;
    public float powerupLength;
    private PowerupManager powerupManager;
    [SerializeField] private Color powerupColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        powerupManager = FindObjectOfType<PowerupManager>();
        // gameObject.GetComponent<Renderer>().material.color = powerupColor;

        if (Random.Range(0, 2) == 0){
            gameObject.GetComponent<Renderer>().material.color = powerupColor;
            safeMode = true;
        }
        else{
            doublePoints = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Powerup");
            powerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
        }
        Destroy(gameObject);
    }
}
