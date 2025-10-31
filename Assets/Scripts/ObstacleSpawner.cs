using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefubs;
    [SerializeField] private float obstacleSpeed;

    [SerializeField,Tooltip("���̏�Q���܂ł̍ŏ�����")] private float minSpawnTime;
    [SerializeField,Tooltip("���̏�Q���܂ł̍Œ�����")] private float maxSpawnTime;
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

    /// <summary> �������\�b�h�𓝊����Ă�Ƃ��� </summary>
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

    /// <summary> ��Q���𐶐� </summary>
    private void SpawnObstacle()
    {
        // ��Q���������_���ɑI��
        GameObject chooseObstacle = obstaclePrefubs[Random.Range(0, obstaclePrefubs.Length)];
        
        // ��Q���̏o���ꏊ��ݒ�
        Vector3 spawnPos = new Vector3(spawnPoint.position.x, chooseObstacle.transform.position.y, 0);

        // ��Q���𐶐�
        GameObject obstacle = Instantiate(chooseObstacle, spawnPos, Quaternion.identity);

        obstacle.AddComponent<ObstacleMove>().speed = obstacleSpeed;
    }

    /// <summary> ���̏�Q���܂ł̎��Ԃ��Đݒ� </summary>
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
