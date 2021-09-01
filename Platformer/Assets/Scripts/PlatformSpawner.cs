using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private const float minDistanceToPlatform = 20f;
    [SerializeField] private Transform platform_Start;
    [SerializeField] private List<GameObject> platformPrefabList;
    public List<float> platformLengthList;
    [SerializeField] private GameObject player;
    private Vector3 lastEndPosition;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float minHeight;
    public float maxHeigth;
    public float powerupHeight;
    public float enemyScoreThreshold;
    GameManager gameManager;


    private CoinSpawner coinSpawner;
    private SpikeSpawner spikeSpawner;
    private PowerupSpawner powerupSpawner;
    private EnemySpawner enemySpawner;
    private ScoreManager scoreManager;
    private int chosenPlatformNumber;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        spikeSpawner = FindObjectOfType<SpikeSpawner>();
        coinSpawner = FindObjectOfType<CoinSpawner>();
        powerupSpawner = FindObjectOfType<PowerupSpawner>();

        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnDeath += SetDefaultLastEndPosition;
        SetDefaultLastEndPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < minDistanceToPlatform)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        float distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
        float height = Random.Range(minHeight, maxHeigth);
        bool spikesSpawned = false;
        chosenPlatformNumber = Random.Range(0, platformPrefabList.Count);
        GameObject chosenPlatform = platformPrefabList[chosenPlatformNumber];
        Transform lastPlatformTransform = MakePlatform(chosenPlatform, lastEndPosition);

        SpawnCoins(lastPlatformTransform);
        // SpawnSpikes(lastPlatformTransform);
        if (Random.Range(0, 4) == 0)
        {
            SpawnSpikes(lastPlatformTransform);
            spikesSpawned = true;
        }
        if (!spikesSpawned && scoreManager.highInGameScoreCount > enemyScoreThreshold && Random.Range(0, 4) == 0){
            SpawnEnemy(lastPlatformTransform);
        }
        SpawnPowerups(lastPlatformTransform, distanceBetween);

        lastEndPosition = lastPlatformTransform.Find("EndPosition").position + new Vector3(distanceBetween, height, 0);
    }

    private Transform MakePlatform(GameObject platformPrefab, Vector3 spawnPosition)
    {
        spawnPosition = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        GameObject platformGameObject = (GameObject)Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        return platformGameObject.transform;
    }

    public void SetDefaultLastEndPosition()
    {
        lastEndPosition = platform_Start.Find("EndPosition").position;
    }

    private void SpawnCoins(Transform platformTransform)
    {
        coinSpawner.SpawnCoins(new Vector3(platformTransform.position.x, platformTransform.position.y + 1, 0));
    }

    private void SpawnSpikes(Transform platformTransform)
    {
        float spikeXPos = Random.Range(-platformLengthList[chosenPlatformNumber] / 2 + 1f, platformLengthList[chosenPlatformNumber] / 2 - 1f);
        spikeSpawner.SpawnSpikes(platformTransform.position + new Vector3(spikeXPos, 0.5f, 0));
    }

    private void SpawnPowerups(Transform platformTransform, float distanceBetween)
    {
        powerupSpawner.SpawnPowerups(platformTransform.position + new Vector3(distanceBetween / 2, Random.Range(powerupHeight / 2, powerupHeight), 0));
    }

    private void SpawnEnemy(Transform platformTransform)
    {
        enemySpawner.SpawnEnemy(platformTransform.position + new Vector3(platformLengthList[chosenPlatformNumber] / 2 - 1f, 1f, 0f));
    }
}
