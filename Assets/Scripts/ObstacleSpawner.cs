using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefubs;

    [SerializeField,Tooltip("Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌÅ¬ŠÔ")] private float minSpawnTime;
    [SerializeField,Tooltip("Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌÅ’·ŠÔ")] private float maxSpawnTime;
    private float nextSpawnTime = 0f;
    private float timer = 0f;

    [SerializeField] private float speed;

    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnObstacle();
            SetNextSpawnTime();
            timer = 0f;
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

        //obstacle.AddComponent<MoveLeft>().speed = moveSpeed;
    }

    /// <summary> Ÿ‚ÌáŠQ•¨‚Ü‚Å‚ÌŠÔ‚ğÄİ’è </summary>
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
