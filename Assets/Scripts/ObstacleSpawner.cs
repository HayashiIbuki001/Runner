using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefubs;

    [SerializeField,Tooltip("���̏�Q���܂ł̍ŏ�����")] private float minSpawnTime;
    [SerializeField,Tooltip("���̏�Q���܂ł̍Œ�����")] private float maxSpawnTime;
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

    /// <summary> ��Q���𐶐� </summary>
    private void SpawnObstacle()
    {
        // ��Q���������_���ɑI��
        GameObject chooseObstacle = obstaclePrefubs[Random.Range(0, obstaclePrefubs.Length)];
        
        // ��Q���̏o���ꏊ��ݒ�
        Vector3 spawnPos = new Vector3(spawnPoint.position.x, chooseObstacle.transform.position.y, 0);

        // ��Q���𐶐�
        GameObject obstacle = Instantiate(chooseObstacle, spawnPos, Quaternion.identity);

        //obstacle.AddComponent<MoveLeft>().speed = moveSpeed;
    }

    /// <summary> ���̏�Q���܂ł̎��Ԃ��Đݒ� </summary>
    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
