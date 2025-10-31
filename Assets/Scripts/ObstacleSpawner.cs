using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefubs;
    [SerializeField] private float obstacleSpeed;

    [SerializeField,Tooltip("Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌÅ¬ŠÔ")] private float minSpawnTime;
    [SerializeField,Tooltip("Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌÅ’·ŠÔ")] private float maxSpawnTime;
    private float nextSpawnTime = 0f;
    private float spawnTimer = 0f;

    [SerializeField] private float playTimer = 0f;
    [SerializeField] private float speedPreSet;

    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        playTimer += Time.deltaTime;

        SpawnSystem();
        ObstacleSpeedUpdate();
    }

    /// <summary> ¶¬ƒƒ\ƒbƒh‚ğ“Š‡‚µ‚Ä‚é‚Æ‚±‚ë </summary>
    private void SpawnSystem()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnObstacle();
            SetNextSpawnTime();
            spawnTimer = 0f;
        }
    }

    /// <summary> áŠQ•¨‚ğ¶¬ </summary>
    private void SpawnObstacle()
    {
        // áŠQ•¨‚ğƒ‰ƒ“ƒ_ƒ€‚É‘I‘ğ
        GameObject chooseObstacle = obstaclePrefubs[Random.Range(0, obstaclePrefubs.Length)];
        
        // áŠQ•¨‚ÌoŒ»êŠ‚ğİ’è
        Vector3 spawnPos = new Vector3(spawnPoint.position.x, chooseObstacle.transform.position.y, 0);

        // áŠQ•¨‚ğ¶¬
        GameObject obstacle = Instantiate(chooseObstacle, spawnPos, Quaternion.identity);

        obstacle.AddComponent<ObstacleMove>().speed = obstacleSpeed;
    }

    /// <summary> Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌŠÔ‚ğÄİ’è </summary>
    private void SetNextSpawnTime()
    {
        float t = Mathf.Clamp01((obstacleSpeed - speedPreSet) / speedPreSet);

        float currentMin = Mathf.Lerp(minSpawnTime, minSpawnTime / 2f, t);
        float currentMax = Mathf.Lerp(maxSpawnTime, maxSpawnTime / 3f, t);


        nextSpawnTime = Random.Range(currentMin, currentMax);
    }

    private void ObstacleSpeedUpdate()
    {
        obstacleSpeed = speedPreSet + (playTimer / 60f);
    }
}
