using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;
    private bool powerupActive;
    public float powerupCounter;
    private ScoreManager scoreManager;
    [SerializeField] private Color doubleScoreColor = Color.white;
    [SerializeField] private Color safeModeColor = Color.white;
    [SerializeField] private Color safeModeCountdownTextColor = Color.white;
    [SerializeField] private TextMeshProUGUI powerupCountdownText;
    [SerializeField] private TextMeshProUGUI powerupText;
    private PlayerMovement player;

    private SpikePowerup spikePowerup;

    private float defaultMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerMovement>();
        spikePowerup = FindObjectOfType<SpikePowerup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupCounter -= Time.deltaTime;
            GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");
            foreach (GameObject powerup in powerups){
                Destroy(powerup.gameObject);
            }
            if (doublePoints)
            {
                scoreManager.scoreMultiplier = 2;
                player.gameObject.GetComponent<Renderer>().material.color = doubleScoreColor;
                powerupCountdownText.color = doubleScoreColor;
                powerupText.color = doubleScoreColor;
                powerupText.text = "Double Points";
            }

            if (safeMode)
            {
                player.gameObject.GetComponent<Renderer>().material.color = safeModeColor;
                powerupCountdownText.color = safeModeCountdownTextColor;
                player.hitSpikes = false;
                spikePowerup.trigger = true;
                powerupText.text = "Safe Mode";
                powerupText.color = safeModeCountdownTextColor;
            }

            if (powerupCounter <= 0)
            {
                scoreManager.scoreMultiplier = defaultMultiplier;
                powerupActive = false;
                player.gameObject.GetComponent<Renderer>().material.color = Color.white;
                player.hitSpikes = true;
                spikePowerup.trigger = false;
                powerupText.text = "";
                powerupCountdownText.text = "";
            }
            else{
                ShowCountdown();
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupCounter = time;

        defaultMultiplier = scoreManager.scoreMultiplier;

        powerupActive = true;
    }

    private void ShowCountdown(){
        // if(Mathf.Round(powerupCounter) != 0){
            powerupCountdownText.text = Mathf.Round(powerupCounter).ToString();
        // }
    }
}
