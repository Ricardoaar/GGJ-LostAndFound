using _scripts;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class CircleCreator : MonoBehaviour
{
    private BoxCollider2D _spawnZone;
    [SerializeField] private CirclePool pool;
    [SerializeField, Range(1, 20)] private int maxAmountSpawned, minAmountSpawned;
    [SerializeField, Range(0, 2)] private float spawnRate;

    private void Awake()
    {
        _spawnZone = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCircle), 0, spawnRate);
    }

    private void SpawnCircle()
    {
        var amount = Random.Range(minAmountSpawned, maxAmountSpawned + 1);
        for (var i = 0; i < amount; i++)
        {
            var obj = pool.ExtractFromQueue();
            var randomY = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);

            obj.transform.position = new Vector3(transform.position.x, randomY);

            obj.SetActive(true);
        }
    }
}