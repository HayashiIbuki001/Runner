using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -15f)
        {
            Destroy(gameObject);
        }
    }
}
