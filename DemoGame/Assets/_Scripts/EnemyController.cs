using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [FormerlySerializedAs("_enemyPrefab")] [SerializeField]
    private GameObject enemyPrefab;

    [FormerlySerializedAs("_enemyCount")] [SerializeField]
    private int enemyCount = 5;

    [FormerlySerializedAs("_spawnTopLeft")] [SerializeField]
    private Transform spawnTopLeft;

    [FormerlySerializedAs("_spawnTopRight")] [SerializeField]
    private Transform spawnTopRight;

    [FormerlySerializedAs("_spawnBottomLeft")] [SerializeField]
    private Transform spawnBottomLeft;

    [FormerlySerializedAs("_spawnBottomRight")] [SerializeField]
    private Transform spawnBottomRight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        var enemy = enemyObject.GetComponent<Enemy>();

        if (enemy is not null)
        {
            enemy.OnDeath += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int randomIndex = Random.Range(0, 4);

        switch ((Position)randomIndex)
        {
            case Position.TopLeft:
                selectedTransform = spawnTopLeft;
                break;
            case Position.TopRight:
                selectedTransform = spawnTopRight;
                break;
            case Position.BottomLeft:
                selectedTransform = spawnBottomLeft;
                break;
            case Position.BottomRight:
                selectedTransform = spawnBottomRight;
                break;
        }

        return selectedTransform!.position + Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private enum Position
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}